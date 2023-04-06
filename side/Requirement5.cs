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
            if (string.IsNullOrEmpty(TxtMonth.Text) || !int.TryParse(TxtMonth.Text, out int month))
            {
                MessageBox.Show("請輸入正確的月份數字");
                return;
            }

            var result = controller.GetQuerying(month);

            TxtResult.Text = JsonConvert.SerializeObject(result);
        }
    }
}
