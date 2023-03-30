using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace side.ServicesImpl
{
    internal interface ICancelServices
    {
        int UpdateWallet_WithdrawItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule);
        int UpdateWallet_WalletItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule);
        int InsertWallet_WalletRecordItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule);
    }
}
