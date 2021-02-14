using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using MyWeb.HomeWeb.Models;
using MyWeb.HomeWeb.Models.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MyWeb.HomeWeb.Controllers
{
    public class LoginController : Controller
    {

        public LoginController()
        {

        }

        public IActionResult Index()
        {
            return Redirect("/login/login");
        }


        #region 회원가입

        public IActionResult Register(string msg)
        {
            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        [Route("/login/register")] // RegisterProc login/register 입니다.
        public IActionResult RegisterProc([FromForm] UserModel input)
        {
            try
            {
                string password2 = Request.Form["password2"];

                if (input.Password != password2)
                {
                    throw new Exception("password와 password2가 다릅니다.");
                }

                input.ConvertPassword();


                input.Register();

                // 성공
                return Redirect("/login/login");
            }
            catch (Exception ex)
            {
                //실패
                // 로그인 실패에 대해 답을 알려주자
                // 근데 url 방식으로 해야되니까 httputility.urlencode로 만들어서 메시지를 던져주자
                return Redirect($"/login/register?msg={HttpUtility.UrlEncode(ex.Message)}");
            }
        }

        #endregion

        //회원가입시 submait action을 /login/login으로 연결해주었다.
        // 그러므로 회원 가입 및 로그인 페이지로 이동을 분기해준다


        #region 로그인
        [HttpGet]
        public IActionResult Login(string msg)
        {
            //회원가입시 submait action을 /login/login으로 연결해주었다.
            // 그러므로 회원 가입 및 로그인 페이지로 이동을 분기해준다

            ViewData["msg"] = msg;
            return View();
        }

        [HttpPost]
        [Route("/login/login")] // LoginProc는 login/login 입니다.
        public async Task<IActionResult> LoginProc([FromForm] UserModel input)
        {
            try
            {
                input.ConvertPassword();
                var user = input.GetLoginUser();


                //로그인 작업

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.User_Seq.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.User_Name));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email));
                identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));

                //db에 Role를 넣지만 일단 특정사용자에 Admin을 준다
                if (user.User_Name == "ji")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "ADMIN"));

                    //여러개도 ,로 넣을 수 있다.
                    // identity.AddClaim(new Claim(ClaimTypes.Role, ",,,,"));
                }

                

                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
                {
                    // 브라우져를 껐을시 로그인을 유지할것인지
                    // 브라우져끄면 쿠키 삭제되도록 하자
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddHours(4),
                    AllowRefresh = true
                });


                return Redirect("/");
            }
            catch (Exception ex)
            {

                //실패
                return Redirect($"/login/login?msg={HttpUtility.UrlEncode(ex.Message)}");
            }

        }

        #endregion

        //로그인이된 사람만 로그아웃을 할 수있다.
        [Authorize]
        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
