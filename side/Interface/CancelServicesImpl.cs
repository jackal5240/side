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
        string getMemberShip2UserIdAndValue(string account);
        SQL_ExcuteResult CancelApplyValue_UpdateWallet_WithdrawItem(int memberId, string oldValue, string increment, string date);
        SQL_ExcuteResult CancelApplyValue_UpdateWallet_WalletItem(int memberId, string oldValue, string value);
        SQL_ExcuteResult CancelApplyValue_InsertWallet_WalletRecordItem(int memberId, string oldValue, string value, string date, string editor);
    }
}
