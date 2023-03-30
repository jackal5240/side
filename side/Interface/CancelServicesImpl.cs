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
        SQL_ExcuteResult UpdateWallet_WithdrawItem(int memeberId, string date);
        SQL_ExcuteResult UpdateWallet_WalletItem(int memeberId, string value);
        SQL_ExcuteResult InsertWallet_WalletRecordItem(int memeberId, string value, string date);
    }
}
