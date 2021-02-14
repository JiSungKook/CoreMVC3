using MySqlConnector;
using MyWeb.Lib.DataBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Models
{
    public class TicketModel
    {
        //Ticket_Id 는 ticketId로 변환해줘서
        //ticketId로 호출해도 Ticket_Id 로 인식한다.
        [JsonProperty("ticketId")]
        public int Ticket_Id { get; set; }

        public string Title { get; set; }

        //반환을 안하고 싶을때 쓰는 어노테이션(Newtonsoft를 쓰기때문에 JsonIgnore를 쓴다)
        //[JsonIgnore]
        public string Status { get; set; }

        public static List<TicketModel> GetList(string status)
        {
            using (var db = new MySqlDapperHelper())
            {

                string sql = @"
            SELECT
                A.ticket_id
                , A.title
                , A.status
            FROM
                t_ticket A
            WHERE a.status = @status
            ";

                // viewdata는 일반적으로 데이터를 넘기는것이고
                //뷰모델을 넘긴다 하면 아래와 같이 사용하면 된다.
                return db.Query<TicketModel>(sql, new { status = status });
            }
        }


        public int Update()
        {
            string sql = @"
        update t_ticket
        SET
            title = @title
        WHERE ticket_id = @ticket_id
        ";

            using (var db = new MySqlDapperHelper())
            {
                return db.Execute(sql, this);
            }
        }

        //여러가지 작업이 들어갈시 아래와 같은 형태로 하면 된다.
        //트랜젝션 사용 예
        //public int Update()
        //{
        //    using (var db = new MySqlDapperHelper())
        //    {

        //        db.BeginTransation();
        //        try
        //        {
        //            int r = 0;

        //            string sql = @"
        //    update t_ticket
        //    SET
        //        title = @title
        //    WHERE ticket_id = @ticket_id
        //    ";




        //            r += db.Execute(sql, this);

        //            sql = @"
        //    다른쿼리~
        //    ";
        //            r += db.Execute(sql, this);
        //            db.Commit();
        //            return r;
        //        }
        //        catch (Exception ex)
        //        {
        //            db.Rollback();
        //            throw ex;
        //        }


        //        //return db.Execute(sql, this);
        //    }
        //}

    }
}
