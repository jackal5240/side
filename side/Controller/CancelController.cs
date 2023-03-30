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
            CancelServices cancelServices = new CancelServices();
            
            int step1 = cancelServices.UpdateWallet_WithdrawItem(dataSet_CancelApplyVaule);

            if (step1 == 1)
            {
                cancelServices.UpdateWallet_WalletItem(dataSet_CancelApplyVaule);
                cancelServices.InsertWallet_WalletRecordItem(dataSet_CancelApplyVaule);
            }
            
            SQL_ExcuteResult result = new SQL_ExcuteResult();
            return result;
        }
        
    }
}
