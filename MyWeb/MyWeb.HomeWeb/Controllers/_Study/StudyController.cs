using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Controllers._Study
{
    public class StudyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        //데이타 테이블로 던지기..
        //이런 방법은 기존 asp나 asp.net 웹폼 사용자에겐 매우 익숙하다.
        public IActionResult DataTableList()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            
            //[1] 필드정의
            dt.Columns.Add(new DataColumn("UserId", typeof(string)));
            dt.Columns.Add("UserNm", typeof(string));


            dr = dt.NewRow();
            dr["UserId"] = "stonehead22";
            dr["UserNm"] = "지성국";
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["UserId"] = "hansese";
            dr["UserNm"] = "한세영";
            dt.Rows.Add(dr);
            ViewData["dt"] = dt;

            return View();

        }
    }
}
