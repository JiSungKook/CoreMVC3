using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Services
{
    public class CustomCookieAuthenticationEvents : CookieAuthenticationEvents
    {

        public CustomCookieAuthenticationEvents()
        {
        }

        //요청이 로그인이 아니라 리퀘스트가 발생할때마다 (모든 클릭 순간마다)
        // 해당 인증하기 내용이 계속 실행된다.
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            var userPrincipal = context.Principal;

            //계속 DB 작업 한다던가 하며는 클릭할때마다 검증이 필요하니까 부하가 심해진다.


            //utc값이다. 왜냐하면 사용자환경에 따라 시간이 달라지기때문에 utc라는 고정적인 값으로 만들어준것이다.
            var checkClaim = userPrincipal.Claims.First(p => p.Type == "LastCheckDateTime");
            var lastCheckDateTime = DateTime.ParseExact(checkClaim.Value,"yyyyMMddHHmmss",CultureInfo.InvariantCulture);

            int intervalMin = 15;

            if (lastCheckDateTime.AddMinutes(15) < DateTime.UtcNow)
            {
                //인증하기
                // 이 사용자가 정상 사용자인지 검증
                if (1 == 1)
                {

                    //Claim은 여러개가 들어갈 수 있기때문에 일단 리무브 해주고 새로 추가해준다.
                 var identity = userPrincipal.Identity as ClaimsIdentity;
                    identity.RemoveClaim(checkClaim);
                    identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));


                    await context.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal);

                }
                else {
                    //권한을 리젝트하고 싸인아웃 시키기
                    context.RejectPrincipal();

                    await context.HttpContext.SignOutAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme);

                }
            }

            //var lastCheckDateTime = userPrincipal.Claims.Where(p => p.Type == "LastCheckDateTime").FirstOrDefault().Value;


            // Look for the LastChanged claim.
            //var lastChanged = (from c in userPrincipal.Claims
            //                   where c.Type == "LastChanged"
            //                   select c.Value).FirstOrDefault();

        
        }
    }
}
