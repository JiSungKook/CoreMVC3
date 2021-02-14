using Microsoft.AspNetCore.Mvc;
using MyWeb.HomeWeb.Models.Member;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Controllers.Member
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult BoardList(string search)
        //{
        //    return View(BoardModel.GetList(search));
        //}

        public IActionResult MemberList()
        {
            //누겟을 통해 다운받음 : System.Data.SqlClient 
            //string Query = @"SELECT UserSeq, userId FROM dbo.tbUser where userId =@UserId and Pwd = @Pwd";
            string Query = @"SELECT userId, UserNm FROM dbo.tbUser";
            var dt = new DataTable();
            using (SqlConnection con = new SqlConnection())
            {

                con.ConnectionString = @" Data Source=desktop-5haqpo7;
                     Initial Catalog = MyFamily;
                    Integrated Security = True; ";
                con.Open();

                //[1] SqlCommand의 인스턴스 생성
                SqlCommand cmd = new SqlCommand();
                //[2] Connection 속성 지정
                cmd.Connection = con;
                //[3] CommandText 속성 설정

                cmd.CommandText = Query;
                //[4] CommandType 속성 지정
                cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@userId", UserId);
                //cmd.Parameters.AddWithValue("@Pwd", ConvertPassword(Pwd));
                //SqlDataReader dr = cmd.ExecuteReader();
                var reader = cmd.ExecuteReader();

                dt.Load(reader);
                con.Close();
            };

            var list = new List<MemberModel>();
            //DataRow로 형을 강제로 지정 하지않으면 데이터테이블의 로우즈를 반환할때 obj로 나온다.
            // ToString 과 as string 차이는? 
            foreach (DataRow row in dt.Rows)
            {
                var Member = new MemberModel();
                Member.UserId = row["UserId"] as string;
                Member.UserNm = row["UserNm"] as string;
                //ticket.Ticket_Id = Convert.ToInt32(row["ticket_id"]);

                list.Add(Member);

            }
            ViewData["MemberList"] = list;

            return View();
        }
    }
}
