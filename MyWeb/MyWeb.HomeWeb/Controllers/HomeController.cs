using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using MyWeb.HomeWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Controllers
{
    public class HomeController : Controller
    {
        // ILogger는 asp.net core에 기본 종속성으로 생성됨
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }



        //이런 방법은 기존 asp나 asp.net 웹폼 사용자에겐 매우 익숙하다.
        //asp.net 방식
        //하지만 우리가 할건 MVC이다.
        //        public IActionResult TicketList()
        //        {

        //            var dt = new DataTable();
        //            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
        //            {
        //                conn.Open();

        //                //                //다음과 같이 쓰면 SQL 인젝션 공격당할 확률이 크다.
        //                //                //해커가 status = "' OR '1' =' 1";
        //                //                string status = "In Progress";

        //                //                using (var cmd = new MySqlCommand())
        //                //                {
        //                //                    cmd.Connection = conn;
        //                //                    cmd.CommandText = @"
        //                //SELECT
        //                //    A.ticket_id
        //                //    , A.title
        //                //    , A.status
        //                //FROM
        //                //    t_ticket A
        //                //WHERE a.status = '" + status + @"'
        //                //";


        //                using (var cmd = new MySqlCommand())
        //                {
        //                    string status = "In Progress";
        //                    cmd.Connection = conn;
        //                    cmd.CommandText = @"
        //SELECT
        //    A.ticket_id
        //    , A.title
        //    , A.status
        //FROM
        //    t_ticket A
        //WHERE a.status = @status
        //";

        //                    cmd.Parameters.AddWithValue("@status", status);  //@를 넣어도 되고 안 넣어도되고
        //                    //select
        //                    var reader = cmd.ExecuteReader();

        //                    dt.Load(reader);

        //                    //인서트, 업데이트, 델리트 등
        //                    //cmd.ExecuteNonQuery();

        //                }
        //            }

        //            ViewData["dt"] = dt;
        //            return View();
        //        }

        //        public IActionResult TicketChange(int ticket_id, string title)
        //        {
        //            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
        //            {
        //                conn.Open();

        //                using (var cmd = new MySqlCommand())
        //                {
        //                    cmd.Connection = conn;
        //                    cmd.CommandText = @"
        //update t_ticket
        //SET
        //    title = @title
        //WHERE ticket_id = @ticket_id
        //";

        //                    cmd.Parameters.AddWithValue("@ticket_id", ticket_id);
        //                    cmd.Parameters.AddWithValue("@title", title);

        //                    cmd.ExecuteNonQuery();

        //                }
        //            }

        //            //변환값은 일반적으로 Json을 사용한다.
        //            //return Json(new { msg = "OK" });
        //            return Redirect("/home/ticketList");
        //        }


        //dapper 사용 전 mvc
        //public IActionResult TicketList()
        //{
        //    var dt = new DataTable();
        //    using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
        //    {
        //        conn.Open();

        //        //dapper를 사용하면 아래 구문을 제거할 수있다.

        //            using (var cmd = new MySqlCommand())
        //            {
        //                string status = "In Progress";
        //                cmd.Connection = conn;
        //                cmd.CommandText = @"
        //        SELECT
        //            A.ticket_id
        //            , A.title
        //            , A.status
        //        FROM
        //            t_ticket A
        //        WHERE a.status = @status 
        //        ";

        //                cmd.Parameters.AddWithValue("@status", status);  //@를 넣어도 되고 안 넣어도되고
        //                                                                 //select
        //                var reader = cmd.ExecuteReader();

        //                dt.Load(reader);

        //            }
        //        }
        //        //select 된 데이터테이블을 가지고 모델을 만드는 방법도 있다. 좀 극단적이지만.

        //        // 아래 문구는 단순 노가다라는 생각이 들어서 dapper 라는 orm을 사용한다.
        //        var list = new List<TicketModel>();
        //        //DataRow로 형을 강제로 지정 하지않으면 데이터테이블의 로우즈를 반환할때 obj로 나온다.
        //        // ToString 과 as string 차이는? 
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            var ticket = new TicketModel();
        //            ticket.Ticket_Id = Convert.ToInt32(row["ticket_id"]);
        //            ticket.Title = row["title"] as string;
        //            ticket.Status = row["status"] as string;

        //            list.Add(ticket);

        //        }
        //        ViewData["ticketList"] = list;



        //        return View();
        //    }
        //}

        //dapper 사용
        //public IActionResult TicketList()
        //{
        //모델을 만들때 아래와 같이 만들면 불편하니 티켓모델에 넣어보자.
        //    string status = "In Progress";
        //    using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
        //    {
        //        conn.Open();

        //        string sql = @"
        //    SELECT
        //        A.ticket_id
        //        , A.title
        //        , A.status
        //    FROM
        //        t_ticket A
        //    WHERE a.status = @status
        //    ";

        //        //IEnumerable 이니까 링큐를 통해서 ToList()로 List로 받자.

        //        ViewData["ticketList"] = Dapper.SqlMapper.Query<TicketModel>(conn, sql, new { status = status }).ToList();

        //    }

        //    return View();

        //}


        //mvc에 맞게 모델로빼보자.
        //public IActionResult TicketChange(int ticket_id, string title)
        //{
        //    var model = new TicketModel();
        //    model.Ticket_Id = ticket_id;
        //    model.Title = title;
        //    model.Update();

        //    return Redirect("/home/ticketList");
        //}

        //모델 형태로 데이터를 받아보자.
        //보안에는 좋지는 않다.!
        //public IActionResult TicketChange([FromForm]TicketModel model)
        //{

        //    //request.form["title"] 뭐 이렇게 받는다.
        //    model.Update();

        //    //return Redirect("/home/ticketList");
        //    //model.Title은 그냥 찍어봄
        //    return Json(new { msg = "OK", msg2 = model.Title });


        //}

        //모델로 던져봄
        //public IActionResult TicketChange(TicketModel model, int num)
        //{
        //    model.Update();
        //request.form["title"] 로 못받는다.
        //request.model["title"] 로 받나?
        //model[""]
        //    //return Redirect("/home/ticketList");
        //    //model.Title은 그냥 찍어봄
        //    return Json(new { msg = "OK", msg2 = model.Title });

        //}


        //엑시오스로 던져봄
        public IActionResult TicketChange([FromBody]TicketModel model)
        {
            //[FromBody] 넣기 전
            //폼데이터에 값이 들어오지 않기때문에 바디 데이터를 읽어보다.
            // 해당 객체는 무조건 비동기(async)로 하자.
            //json 형태로 바디에 데이터가 들어간걸 볼 수 있다.
            //var sr = new StreamReader(Request.Body);
            ////비동기로 안 만들었기때문에 일단 getawaiter로 받아보자.
            //var body = sr.ReadToEndAsync().GetAwaiter().GetResult();
            //[FromBody] 넣기 전


            model.Update();
            //return Json(new { msg = model.Title});
            return Json(model);

        }


        //모델화
        //로그인 한 사용자만 접근하는 방식
        //1.방법 [Authorize] 어노테이션을 쓴다.
        //[Authorize]
        //[Authorize(Roles = "ADMIN")]
        public IActionResult TicketList()
        {
            //2.방법

            //로그인 여부 판단
            //if (User.Identity.IsAuthenticated)
            //{

            //}
            string status = "In Progress";
           return View(TicketModel.GetList(status));
        }
        public IActionResult Test()
        {
            return PartialView();
        }

        public IActionResult BoardList(string search)
        {
            return View(BoardModel.GetList(search));
        }

        public IActionResult BoardView(uint idx)
        {
            return View(BoardModel.Get(idx));
        }

        [Authorize]
        public IActionResult BoardWrite()
        {
            return View();
        }

        [Authorize]
        public IActionResult BoardWrite_Input(string title, string contents)
        {
            var model = new BoardModel();
            

            model.Title = title;
            model.Contents = contents;
            model.Reg_User = Convert.ToUInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            model.Reg_Username = User.Identity.Name;
            model.Insert();
            return Redirect("/home/boardlist");
        }



        [Authorize]
        public IActionResult BoardEdit(uint idx, string type)
        {
            var model = BoardModel.Get(idx);
            var userSeq = Convert.ToUInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (model.Reg_User != userSeq)
            {
                throw new Exception("수정 할 수 없습니다.");
            }

            if (type == "U")
            {
                return View(model);
            }
            else if (type == "D")
            {
                model.Delete();
                return Redirect("/home/boardlist");
            }

            throw new Exception("잘못된 요청입니다.");
        }

        [Authorize]
        public IActionResult BoardEdit_Input(uint idx, string title, string contents)
        {
            var model = BoardModel.Get(idx);
            var userSeq = Convert.ToUInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (model.Reg_User != userSeq)
            {
                throw new Exception("수정 할 수 없습니다.");
            }

            model.Title = title;
            model.Contents = contents;
            model.Update();
            return Redirect("/home/boardlist");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        // error() 는 View >Shared> Error.cshtml 가 있다.
        // 기본폴더에 없으면(ex : index, privacy) shared를 뒤진다.
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
