using side.DAO;
using side.DataSet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace side.Controller
{
    public class WithdrawItemController
    {
        private readonly WithdrawItemDAO _withdrawItemInstance = WithdrawItemDAO.GetInstance();

        private readonly static WithdrawItemController _instance = new WithdrawItemController();

        public static WithdrawItemController GetInstance()
        {
            return _instance;
        }

        public string GetNewCaseId()
        {
            return _withdrawItemInstance.GetNextCaseId();
        }

        public DataSet_WithdrawItemQuerying GetQuerying(string date)
        {
            return _withdrawItemInstance.GetDataByMonth(date);
        }
    }
}
