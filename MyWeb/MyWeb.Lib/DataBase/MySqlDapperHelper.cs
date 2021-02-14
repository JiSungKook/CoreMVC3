using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyWeb.Lib.DataBase
{
    public class MySqlDapperHelper : IDisposable
    {
        MySqlConnection _conn;
        MySqlTransaction _trans =null;
        public MySqlDapperHelper()
        {
            _conn = new MySqlConnection("Server=127.0.0.1;Port=3306;Database=myweb;Uid=root;Pwd=wltjdrnr1!;");
            
        }

        public void BeginTransation()
        {
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }
            _trans = _conn.BeginTransaction();
        }

        public void Commit()
        {
            _trans.Commit();
            _trans = null;
        }

        public void Rollback()
        {
            _trans.Rollback();
            _trans = null;
        }

        public List<T> Query<T>(string sql, object param)
        {
            //Open을 안하면 Dapper에서 자동으로 Open을 해주긴 한다.
            //_conn.Open();
            //IEnumerable 이니까 링큐를 통해서 ToList()로 List로 받자.
            // viewdata는 일반적으로 데이터를 넘기는것이고
            //뷰모델을 넘긴다 하면 아래와 같이 사용하면 된다.
            return Dapper.SqlMapper.Query<T>(_conn, sql, param, _trans).ToList();
        }

        public  T QuerySingle<T>(string sql, object param)
        {
            return Dapper.SqlMapper.QuerySingleOrDefault<T>(_conn, sql, param,_trans);
        }

        public int Execute(string sql, object param)
        {
            return Dapper.SqlMapper.Execute(_conn, sql, param, _trans);
        }


        #region Dispose 관련
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                    //메모리를 해제하는 시점을 만든것이다.
                    //향후에 관리되어야 하는 멤버변수가 추가되면 여기에서 관리하자.
                    _conn.Dispose();
                    if (_trans != null)
                    {
                        _trans.Rollback();
                        _trans.Dispose();
                    }
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                // TODO: 큰 필드를 null로 설정합니다.
                disposedValue = true;
            }


        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~MySqlDapperHelper()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
