using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DataSet;
using side.Services;
using side.ServicesImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace side.Controller
{
    internal class CancelController
    {
        internal SQL_ExcuteResult CancelApplyValue(DataSet_CancelApplyValue dataSet_CancelApplyVaule)
        {
            CancelServices cancelServices = new CancelServices();
            return cancelServices.CancelApplyValue(dataSet_CancelApplyVaule);
        }
    }
}
