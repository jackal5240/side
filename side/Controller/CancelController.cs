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
            // 先索取 原始金額
            string userIdAndValue = cancelServices.getMemberShip2UserIdAndValue(account);
            int userId = Convert.ToInt32(Regex.Split(userIdAndValue, ",")[0]);
            string value = Regex.Split(userIdAndValue, ",")[1];

            if (userId != -1)
            {
                // 更新 提領紀錄
                result = cancelServices.CancelApplyValue_UpdateWallet_WithdrawItem(userId, value, dataSet_CancelApplyVaule.withdrawData.value, dataSet_CancelApplyVaule.submissionTime);

                if (result.isSuccess)
                {
                    // 更新 原始金額
                    result = cancelServices.CancelApplyValue_UpdateWallet_WalletItem(userId, value, dataSet_CancelApplyVaule.withdrawData.value);
                    // 新增 歷史紀錄
                    result = cancelServices.CancelApplyValue_InsertWallet_WalletRecordItem(userId, value, dataSet_CancelApplyVaule.withdrawData.value, dataSet_CancelApplyVaule.submissionTime, editor);
                }
            }

            return result;
        }
        
    }
}
