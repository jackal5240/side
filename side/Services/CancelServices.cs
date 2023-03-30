using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DAO;
using side.DataSet;
using side.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;

namespace side.Services
{
    internal class CancelServices : ICancelServices
    {
        CancelDAO cancelDAO = new CancelDAO();
        public int UpdateWallet_WithdrawItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            var aa = GetTimeRange(InputDateTimeFormat(dataSet_CancelApplyVaule.submissionTime));

            return cancelDAO.UpdateWallet_WithdrawItem(dataSet_CancelApplyVaule, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public int UpdateWallet_WalletItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            return cancelDAO.UpdateWallet_WalletItem(dataSet_CancelApplyVaule.memberId, dataSet_CancelApplyVaule.withdrawData.value);
        }
        public int InsertWallet_WalletRecordItem(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            var aa = GetTimeRange(InputDateTimeFormat(dataSet_CancelApplyVaule.submissionTime));

            return cancelDAO.InsertWallet_WalletRecordItem(dataSet_CancelApplyVaule, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        private DateTime InputDateTimeFormat(string date)
        {
            return new DateTime(Convert.ToInt32(date.Substring(0, 4))
               , Convert.ToInt32(date.Substring(5, 2))
               , Convert.ToInt32(date.Substring(8, 2))
               , Convert.ToInt32(date.Substring(11, 2))
               , Convert.ToInt32(date.Substring(14, 2))
               , Convert.ToInt32(date.Substring(17, 2)));
        }
        public static (DateTime startTime, DateTime endTime) GetTimeRange(DateTime time)
        {
            var startTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            var endTime = startTime.AddSeconds(1);

            return (startTime, endTime);
        }
    }
}
