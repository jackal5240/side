using Newtonsoft.Json;
using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace side.DAO
{
    internal class CancelDAO
    {
        // 資料庫連接字串
        private string _connectionString = ConfigurationManager.ConnectionStrings["local"].ConnectionString;
        public int CancelWallet_WalletRecordItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 取消提領 [Wallet_WalletRecordItem]
                SqlCommand cmd = new SqlCommand("update bu_test.dbo.Wallet_WalletRecordItem " +
                    "set Reason = '取消提領', Old = New" +
                    ", Increment = CASE WHEN Increment > 0 THEN Increment * -1 ELSE Increment END" +
                    ", New = Old" +
                    ", Editor = 'Leo'" +
                    ", UpdateTime = GETDATE()" +
                    "where Id = @ID ;", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@ID", dataSet_CancelApplyVaule.id);
                // cmd.Parameters.AddWithValue("@Increment", dataSet_CancelApplyVaule.withdrawData.value);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        internal int Wallet_WithdrawItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 更新狀態 [Wallet_WithdrawItem]
                SqlCommand cmd = new SqlCommand("update bu_test.dbo.Wallet_WithdrawItem " +
                    "set Type = '取消提領', State = '已處理', UpdateTime = GETDATE()" +
                    "where Id = @ID ;", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@ID", dataSet_CancelApplyVaule.id);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
