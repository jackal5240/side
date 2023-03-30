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
        public SQL_ExcuteResult CancelApplyValue(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            SQL_ExcuteResult result = new SQL_ExcuteResult();

            DateTime input = new DateTime(Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(0, 4))
                , Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(5, 2))
                , Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(8, 2))
                , Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(11, 2))
                , Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(14, 2))
                , Convert.ToInt32(dataSet_CancelApplyVaule.submissionTime.Substring(17, 2)));
            var aa = GetTimeRange(input);
            // Console.WriteLine($"StartTime: {aa.startTime}, EndTime: {aa.endTime}");

            cancelDAO.UpdateWallet_WithdrawItem(dataSet_CancelApplyVaule, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            cancelDAO.InsertWallet_WalletRecordItem(dataSet_CancelApplyVaule, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));
            
            return result;
        }
        public static (DateTime startTime, DateTime endTime) GetTimeRange(DateTime time)
        {
            var startTime = new DateTime(time.Year, time.Month, time.Day, time.Hour, time.Minute, time.Second);
            var endTime = startTime.AddSeconds(1);

            return (startTime, endTime);
        }

    }
}
