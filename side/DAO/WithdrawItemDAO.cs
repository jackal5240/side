using side.DataSet;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace side.DAO
{
    internal class WithdrawItemDAO
    {
        // 資料庫連接字串
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;

        private static readonly WithdrawItemDAO _instance = new WithdrawItemDAO();

        /// <summary>
        /// 取得執行實體。
        /// </summary>
        /// <returns><see cref="WithdrawItemDAO"/> 的執行實體。</returns>
        public static WithdrawItemDAO GetInstance()
        {
            return _instance;
        }

        public string GetNextCaseId()
        {
            return $"{DateTime.Now:yyyyMMddHHmmssfff}";
        }

        public DataSet_WithdrawItemQuerying GetDataByMonth(string date)
        {
            if (!DateTime.TryParse(date, out DateTime dt))
            {
                return null;
            }

            DateTime durationStart = new DateTime(dt.Year, dt.Month, 1);
            DateTime durationEnd = new DateTime(dt.Year + (dt.Month == 12 ? 1 : 0), dt.Month + 1, 1);

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText =
                        " SELECT *" +
                        " FROM Wallet_WithdrawItem" +
                        " WHERE CreateTime >= @Start" +
                        "   AND CreateTime < @End;";

                    cmd.Parameters.AddWithValue("@Start", durationStart);
                    cmd.Parameters.AddWithValue("@End", durationEnd);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    }
                }

                conn.Close();
            }

            return new DataSet_WithdrawItemQuerying
            {
                Duration = date,
            };
        }
    }
}
