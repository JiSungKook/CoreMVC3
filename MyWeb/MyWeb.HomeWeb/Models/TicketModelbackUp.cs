//using MySqlConnector;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace MyWeb.HomeWeb.Models
//{
//    public class TicketModel
//    {

//        public int Ticket_Id { get; set; }

//        public string Title { get; set; }
//        public string Status { get; set; }

//        //클래스 라이브러리 사용전 
//        public static List<TicketModel> GetList(string status)
//        {
//            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
//            {
//                conn.Open();

//                string sql = @"
//            SELECT
//                A.ticket_id
//                , A.title
//                , A.status
//            FROM
//                t_ticket A
//            WHERE a.status = @status
//            ";

//                //IEnumerable 이니까 링큐를 통해서 ToList()로 List로 받자.


//                // viewdata는 일반적으로 데이터를 넘기는것이고
//                //뷰모델을 넘긴다 하면 아래와 같이 사용하면 된다.
//                return Dapper.SqlMapper.Query<TicketModel>(conn, sql, new { status = status }).ToList();
//            }
//        }

//        public int Update()
//        {
//            string sql = @"
//update t_ticket
//SET
//    title = @title
//WHERE ticket_id = @ticket_id
//";

//            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
//            {
//                conn.Open();

//                return Dapper.SqlMapper.Execute(conn, sql, this);
//            }
//        }

//    }
//}
