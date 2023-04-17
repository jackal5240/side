using NiteenNity_Case_SQL_API.Mode.Abstract;
using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using side.Services;
using side.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace side.Controller
{
    internal class CancelController
    {
        CancelServices cancelServices = CancelServices.getInstance();
        private static CancelController instance = new CancelController();
        public static CancelController getInstance()
        {
            return instance;
        }
        internal SQL_ExcuteResult CancelApplyValue(DataSet_CancelApplyValue dataSet_CancelApplyVaule, string account, string editor)
        {
            SQL_ExcuteResult result = new SQL_ExcuteResult
            {
                isSuccess = false,
                FeedbackMsg = "",
                ReturnDataJson = ""
            };
            /*
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["local"].ConnectionString);
            ImplmentSQL sql = ImplmentSQL.getInstance();
            sql.GetMemberShipID(conn, account);
            */
            // 先索取 原始金額，拿到 MemberId和 原始金額 和 比例手續費，固定手續費
            string userIdAndValue = cancelServices.getMemberShip2UserIdAndValue(account);
            int userId = Convert.ToInt32(Regex.Split(userIdAndValue, ",")[0]);
            string oldValue = Regex.Split(userIdAndValue, ",")[1];
            string withdrawFeeRatio = Regex.Split(userIdAndValue, ",")[2];
            string withdrawFee = Regex.Split(userIdAndValue, ",")[3];
            string remark = "";

            if (userId != -1)
            {
                // 銀行：004-台灣銀行<br/>分行：123456<br/>戶名：1231<br/>帳號：123456564654<br/>虛擬錢包地址：asdasdassdad
                // 提領至 004 - 台灣銀行 - 123456 123456564654 < br /> 提領額度1,000，手續費率0 % 0，固定手續費0，實際提領額度1,000 < br />
                string test = cancelServices.getWallet_WithdrawItem_Remark(userId, dataSet_CancelApplyVaule.submissionTime, withdrawFeeRatio, withdrawFee);
                // 銀行
                string bank = Regex.Split(Regex.Split(test, "：")[1], "<br/>")[0];
                // 分行
                string branch = Regex.Split(Regex.Split(test, "：")[2], "<br/>")[0];
                // 戶名
                //string accountName = Regex.Split(Regex.Split(test, "：")[3], "<br/>")[0];
                // 帳號
                string accountNumber = Regex.Split(Regex.Split(test, "：")[4], "<br/>")[0];
                // 提領額度
                string value = Regex.Split(test, ",")[2];
                // 手續費率
                string ratio = Regex.Split(test, ",")[3];
                // 固定手續費
                string fee = Regex.Split(test, ",")[4];
                remark = "提領至 " + bank + "-" + branch + " " + accountNumber + "<br/>提領額度" + value + "，手續費率" + ratio + "% " + Convert.ToString(Convert.ToDecimal(value) * Convert.ToDecimal(ratio) / 100) + "，固定手續費" + fee + "，實際提領額度" + Convert.ToString(Convert.ToDecimal(value) - Convert.ToDecimal(value) * Convert.ToDecimal(ratio) / 100 - Convert.ToDecimal(fee)) + "<br/>";

                // 更新 提領紀錄
                result = cancelServices.CancelApplyValue_UpdateWallet_WithdrawItem(userId, oldValue, dataSet_CancelApplyVaule.withdrawData.value, dataSet_CancelApplyVaule.submissionTime, withdrawFeeRatio, withdrawFee);

                if (result.isSuccess)
                {
                    // 更新 原始金額
                    result = cancelServices.CancelApplyValue_UpdateWallet_WalletItem(userId, oldValue, dataSet_CancelApplyVaule.withdrawData.value, withdrawFeeRatio, withdrawFee);

                    // 新增 歷史紀錄
                    result = cancelServices.CancelApplyValue_InsertWallet_WalletRecordItem(userId, oldValue, dataSet_CancelApplyVaule.withdrawData.value, dataSet_CancelApplyVaule.submissionTime, editor, withdrawFeeRatio, withdrawFee, remark);
                }
            }

            return result;
        }
        
    }
}
