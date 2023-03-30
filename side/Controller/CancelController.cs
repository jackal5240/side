using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using side.Services;
using side.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace side.Controller
{
    internal class CancelController
    {
        internal SQL_ExcuteResult CancelApplyValue(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            SQL_ExcuteResult result;
            CancelServices cancelServices = new CancelServices();

            // 更新 提領紀錄
            result = cancelServices.UpdateWallet_WithdrawItem(dataSet_CancelApplyVaule.memberId, dataSet_CancelApplyVaule.submissionTime);

            if (result.isSuccess)
            {
                // 更新 原始金額
                result = cancelServices.UpdateWallet_WalletItem(dataSet_CancelApplyVaule.memberId, dataSet_CancelApplyVaule.withdrawData.value);
                // 新增 歷史紀錄
                result = cancelServices.InsertWallet_WalletRecordItem(dataSet_CancelApplyVaule.memberId, dataSet_CancelApplyVaule.withdrawData.value, dataSet_CancelApplyVaule.submissionTime);
            }
            
            return result;
        }
        
    }
}
