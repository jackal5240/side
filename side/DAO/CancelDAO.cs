﻿using Newtonsoft.Json;
using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using side.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
        private static CancelDAO instance = new CancelDAO();
        public static CancelDAO getInstance()
        {
            return instance;
        }
        internal string getMemberShip2UserIdAndValue(string account)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 拿到 MemberId和 原始金額
                SqlCommand cmd = new SqlCommand("SELECT A.Id, B.Value " +
                    "FROM bu_test.dbo.MemberShip2_User A " +
                    "LEFT JOIN bu_test.dbo.Wallet_WalletItem B ON A.Id = B.MemberId " +
                    "WHERE A.Account = @account", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@account", account);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                int id = -1;
                string value = "-1";
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                    value = Convert.ToString(reader["Value"]);
                }
                conn.Close();
                reader.Close();

                return Convert.ToString(id) + "," + value;
            }
        }
        internal int UpdateWallet_WithdrawItem(int memberId, string startTime, string endTime)
        {
            int ans = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 更新提領狀態 [Wallet_WithdrawItem]
                SqlCommand cmd = new SqlCommand("update bu_test.dbo.Wallet_WithdrawItem " +
                    "set State = '已取消', UpdateTime = GETDATE() " +
                    "where memberId = @memberId AND State = '未處理'" +
                    "AND ( CreateTime between '" + startTime + "'" +
                    "and '" + endTime + "' ) " +
                    ";", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@memberId", memberId);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                ans = cmd.ExecuteNonQuery();
                conn.Close();

                return ans;
            }
        }
        internal int UpdateWallet_WalletItem(int memberId, string value)
        {
            int ans = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 更新原始金額 [Wallet_WithdrawItem]
                SqlCommand cmd = new SqlCommand("update bu_test.dbo.Wallet_WalletItem " +
                    "set Value = Value + CAST(" + Convert.ToInt32(value) + " AS DECIMAL(18, 2))" +
                    ", UpdateTime = GETDATE() " +
                    "where memberId = @memberId" + 
                    ";", conn);
                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@memberId", memberId);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                ans = cmd.ExecuteNonQuery();
                conn.Close();

                return ans;
            }
        }
        public int InsertWallet_WalletRecordItem(int memberId, string value, string startTime, string endTime, string editor)
        {
            int ans = 0;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // 記錄一筆 取消提領 [Wallet_WalletRecordItem]
                SqlCommand cmd = new SqlCommand("INSERT INTO bu_test.dbo.Wallet_WalletRecordItem " +
                    "(WalletId, Id, Reason, Old, Increment, New, Remark, IsHide, CreateTime, Editor, UpdateTime)" +
                    " select MemberId, (select MAX(Id) + 1 from bu_test.dbo.Wallet_WalletRecordItem), Type" +
                    ", (select Value from bu_test.dbo.Wallet_WalletItem where MemberId = @memberId) - CAST(" + Convert.ToInt32(value) + " AS DECIMAL(18, 2))" +
                    ", Value" +
                    ", (select Value from bu_test.dbo.Wallet_WalletItem where MemberId = @memberId)" +
                    ", Remark ,'0' ,GETDATE() ,'" + editor + "' ,UpdateTime " +
                    "from bu_test.dbo.Wallet_WithdrawItem " +
                    "where MemberId = @memberId AND State = '已處理' AND Type = '取消提領' " +
                    "AND ( CreateTime between '" + startTime + "'" +
                    "and '" + endTime + "' ); ", conn);

                // 將資料塞入 SQL 指令中
                cmd.Parameters.AddWithValue("@memberId", memberId);
                // cmd.Parameters.AddWithValue("@Increment", dataSet_CancelApplyVaule.withdrawData.value);

                // 開啟資料庫連線，並執行 SQL 指令
                conn.Open();
                ans = cmd.ExecuteNonQuery();
                conn.Close();

                return ans;
            }
        }
    }
}
