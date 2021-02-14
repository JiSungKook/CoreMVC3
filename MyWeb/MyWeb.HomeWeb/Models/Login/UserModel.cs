using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeb.HomeWeb.Models.Login
{
    public class UserModel
    {
        //부호없음은 uint라고 하는데 
        public uint User_Seq { get; set; }
        public string User_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public void ConvertPassword()
        {
            var sha = new System.Security.Cryptography.HMACSHA512();
            sha.Key = System.Text.Encoding.UTF8.GetBytes(this.Password.Length.ToString());
            // hash값은 byte 배열이니까 base64로 인코딩 하자
            var hash = sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(this.Password));
            this.Password = System.Convert.ToBase64String(hash);
            
        }


        internal int Register()
        {
            // 중복 user_name이 있는지
            //중복 email 있는지 체크 등등


            string sql = @"
            insert INTO t_user (
             user_name
            , email
            , password
            )
            select 
            @user_name
            , @email
            , @password
            ";
            
            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
            {
                conn.Open();

                return Dapper.SqlMapper.Execute(conn, sql, this);
            }

        }

        internal UserModel GetLoginUser()
        {
            //this.User_Name
            //                this.Password

            string sql = @"
SELECT
user_seq
, user_name
, email
, password
from
t_user
where
user_name = @user_name
            ";
            UserModel user;
            using (var conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;"))
            {
                conn.Open();

                user = Dapper.SqlMapper.QuerySingleOrDefault<UserModel>(conn, sql, this);
            }

            if (user == null)
            {
                throw new Exception ("사용자가 존재하지 않습니다." );
            }

            if (user.Password != this.Password)
            {
                throw new Exception("비밀번호가 틀립니다.");

                // 비밀번호 틀린횟수 -- update
            }

            return user;

        }
    }
}
