using Newtonsoft.Json;
using side.Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace side
{
    public partial class Requirement5 : Form
    {
        private readonly WithdrawItemController controller = WithdrawItemController.GetInstance();

        public Requirement5()
        {
            InitializeComponent();
        }

        private void BtnGetNewCaseId_Click(object sender, EventArgs e)
        {
            string newCaseId = controller.GetNewCaseId();

            TxtNewCaseId.Text = newCaseId;
        }

        private void BtnCopyCaseId_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNewCaseId.Text))
            {
                Clipboard.SetText(TxtNewCaseId.Text);

                MessageBox.Show("已複製");
            }
        }

        private void BtnQuery_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtMonth.Text) || !DateTime.TryParse(TxtMonth.Text, out DateTime _))
            {
                MessageBox.Show("請輸入正確的年月");
                return;
            }

            if (string.IsNullOrEmpty(TxtAccount.Text))
            {
                MessageBox.Show("請輸入帳號");
                return;
            }

            var result = controller.GetQuerying(TxtAccount.Text, TxtMonth.Text);

            TxtResult.Text = JsonConvert.SerializeObject(result, Formatting.Indented);
        }

        private void BtnETL_Click(object sender, EventArgs e)
        {
            try
            {
                controller.ETL();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
