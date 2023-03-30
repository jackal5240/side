using NiteenNity_Case_SQL_API.Controller;
using NiteenNity_Case_SQL_API.Mode.Abstract;
using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.Controller;
using side.DataSet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace side
{
    public partial class Form1 : Form
    {
        DataSet_WithdrawDetail dataSet_WithdrawDetail;
        private const string WithdrawApiUrl = "http://localhost:5000/withdrawal/withdraw";
        private const string CancelApiUrl = "http://localhost:5000/withdrawal/cancel";

        public Form1()
        {
            InitializeComponent();
        }
        private void detailButton_Click(object sender, EventArgs e)
        {
            dataSet_WithdrawDetail = new DataSet_WithdrawDetail
            {
                id = 2,
                name = "cas1",
                bankData = new DataSet_WithdrawDetail.BankData
                {
                    bankName = "004-台灣銀行",
                    branch = "100101",
                    passbookName = "10101010",
                    account = "101010101010101010"
                },
                withdrawData = new DataSet_WithdrawDetail.WithdrawData
                {
                    value = "1000",
                    feeRatio = "0",
                    fee = "50",
                    available = "950"
                },
                submissionTime = new DateTime().ToString()
            };
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            SQL_ExcuteResult result = new SQL_ExcuteResult();

            DataSet_CancelApplyValue dataSet_CancelApplyVaule = Init();

            CancelController cancelController = new CancelController();

            result = cancelController.CancelApplyValue(dataSet_CancelApplyVaule);

            MessageBox.Show("");
        }

        private DataSet_CancelApplyValue Init()
        {
            DataSet_CancelApplyValue dataSet_CancelApplyVaule = new DataSet_CancelApplyValue
            {
                id = dataSet_WithdrawDetail.id,
                name = dataSet_WithdrawDetail.name,
                bankData = new DataSet_CancelApplyValue.BankData
                {
                    bankName = dataSet_WithdrawDetail.bankData.bankName,
                    branch = dataSet_WithdrawDetail.bankData.branch,
                    passbookName = dataSet_WithdrawDetail.bankData.passbookName,
                    account = dataSet_WithdrawDetail.bankData.account
                },
                withdrawData = new DataSet_CancelApplyValue.WithdrawData
                {
                    value = dataSet_WithdrawDetail.withdrawData.value,
                    feeRatio = dataSet_WithdrawDetail.withdrawData.feeRatio,
                    fee = dataSet_WithdrawDetail.withdrawData.fee,
                    available = dataSet_WithdrawDetail.withdrawData.available
                },
                submissionTime = dataSet_WithdrawDetail.submissionTime
            };

            return dataSet_CancelApplyVaule;
        }
    }
}
