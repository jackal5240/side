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
            cancelDAO.CancelWallet_WalletRecordItem(dataSet_CancelApplyVaule);
            cancelDAO.Wallet_WithdrawItem(dataSet_CancelApplyVaule);
            return result;
            /*
            try
            {
                
                
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("取消提領 [Wallet_WalletRecordItem] " + ex.Message);

                result.isSuccess = false;
                result.ReturnDataJson = null;
                result.FeedbackMsg = ex.Message;

                return result;
            }
            */
        }
    }
}
