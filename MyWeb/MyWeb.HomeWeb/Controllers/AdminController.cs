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
    [Authorize]
    //관리자용 컨트롤러 만들어 보자
    // 해당 컨트롤러는 로그인 한 사용자만 들어올 수 있다.
    public class AdminController : Controller
    {

        public AdminController()
        {

        }

        //Role는 내부에서도 지정이 가능하다
        //[Authorize(Roles = "ADMIN")]
        //[Authorize(Roles = "ADMIN,USER")]
        //public IActionResult GetCheck()
        //{
        //        return Json(new { a = 9 });
        //}

        public IActionResult GetCheck()
        {

            //Admin 권한이 있으면 9, 없으면 1 반환

            //컨트롤러에서도 사용 가능하고 cshtml에서도 사용 가능하다.
            if (User.IsInRole("ADMIN"))
            { 
                return Json(new { a = 9 });
            }
            return Json(new { a = 1 });
        }

        // 로그인이 무조건 돼 있어야 하는데 왜 만들었냐면
        // 컨트롤러 전체에 로그인 검증을 하겠다. 
        //하지만 예외를 몇개 두기 위해서 사용한다.

        //특정부분은 익명사용자(로그인 되지 않은)를 받겠다.
        [AllowAnonymous]
        public IActionResult GetuserCheck()
        {
            //로그인이 돼 있으면 9, 없으면 1 반환
            if (User.Identity.IsAuthenticated)
            {
                return Json(new { a = 9 });
            }
            return Json(new { a = 1 });
        }
       
    }
}
