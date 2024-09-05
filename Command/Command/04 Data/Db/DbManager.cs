using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;

namespace Command
{
    public class DbManager
    {
        private const string ECOUNT_TEST_CONNECTION = "host=10.10.10.108;port=45111;username=ecount_user;password=1q2w3e4r;database=ecount";
        private const string LOCAL_TEST_CONNECTION = "host=127.0.0.1;port=5432;username=postgres;password=postgres;database=postgres";
        private const string _connectionString = ECOUNT_TEST_CONNECTION;

        public DbManager()
        {

        }

        public int Execute(string sql, Dictionary<string, object> parameters)
        {

            // using var com = new NpgsqlConnection(_connectionString)
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new NpgsqlParameter(param.Key, param.Value));
                    }

                    return cmd.ExecuteNonQuery(); // 영향받은 row의 수
                }
            }
        }

        //ActionDbDataReader : 여러 DBMS dbReader들의 상위 리더 
        public List<T> Query<T>(string sql, Dictionary<string, object> parameters, Action<DbDataReader, T> mapper)
        where T : new()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new NpgsqlParameter(param.Key, param.Value));
                    }
                    var result = new List<T>();
                    // 서버 메모리 한계로 데이터를 한줄씩 읽기 위한 리더
                    using (var reader = cmd.ExecuteReader())
                    {
                        // 한줄씩 읽어옴. 마지막이면 false 반환
                        while (reader.Read())
                        {
                            var data = new T();
                            //var a = reader("com_code");
                            mapper(reader, data);
                            result.Add(data);
                        }
                        return result;
                    }
                }
            }
        }

        public object Scalar(string sql, Dictionary<string, object> parameters)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Open();

                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;

                    foreach (var param in parameters)
                    {
                        cmd.Parameters.Add(new NpgsqlParameter(param.Key, param.Value));
                    }

                    return cmd.ExecuteScalar(); // 단일값을 반환
                }
            }
        }

        // Query : 여러건 조회
        // Fetch : 단건 조회 (결과값이 하나)
        // Execute : 실행 (Insert Update 등)
        // Scalar : 단일값을 가져올때 (ex. row count 등)
    }
}
