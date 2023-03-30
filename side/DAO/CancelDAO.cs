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

        internal int UpdateWallet_WithdrawItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule, string startTime, string endTime)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 更新狀態 [Wallet_WithdrawItem]
                SqlCommand cmd = new SqlCommand("update bu_test.dbo.Wallet_WithdrawItem " +
                    "set Type = '取消提領', State = '已處理', UpdateTime = GETDATE() " +
                    "where memberId = @ID AND State = '未處理'" +
                    "AND ( CreateTime between '" + startTime + "'" +
                    "and '" + endTime + "' ) " +
                    ";", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@ID", dataSet_CancelApplyVaule.memberId);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
        public int InsertWallet_WalletRecordItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule, string startTime, string endTime)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 記錄一筆 取消提領 [Wallet_WalletRecordItem]
                SqlCommand cmd = new SqlCommand("INSERT INTO bu_test.dbo.Wallet_WalletRecordItem " +
                    "(WalletId, Id, Reason, Old, Increment, New, Remark, IsHide, CreateTime, Editor, UpdateTime)" +
                    " select MemberId, (select MAX(Id) + 1 from bu_test.dbo.Wallet_WalletRecordItem), Type," + dataSet_CancelApplyVaule.withdrawData.value + ", Value, '-999'" +
                    ", Remark ,'0' ,GETDATE() ,'LEO' ,UpdateTime " +
                    "from bu_test.dbo.Wallet_WithdrawItem " +
                    "where MemberId = @ID AND State = '已處理' AND Type = '取消提領' " +
                    "AND ( CreateTime between '" + startTime + "'" +
                    "and '" + endTime + "' ); ", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@ID", dataSet_CancelApplyVaule.memberId);
                // cmd.Parameters.AddWithValue("@Increment", dataSet_CancelApplyVaule.withdrawData.value);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
