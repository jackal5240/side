using Newtonsoft.Json;
using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
using side.DAO;
using side.Interface;
using System;

namespace side.Controller
{
    public class WithdrawItemController : IConnStrSingleton
    {
        private readonly WithdrawItemDAO _withdrawItemInstance = WithdrawItemDAO.GetInstance();

        private readonly static WithdrawItemController _instance = new WithdrawItemController();

        public static WithdrawItemController GetInstance()
        {
            return _instance;
        }

        /// <summary>
        /// 設定資料庫連線字串。
        /// </summary>
        /// <param name="connectionString">與資料庫的連線字串。</param>
        public void SetConnectionString(string connectionString)
        {
            _withdrawItemInstance._connectionString = connectionString;
        }

        public string GetNewCaseId()
        {
            return _withdrawItemInstance.GetNextCaseId();
        }

        /// <summary>
        /// 取得查詢結果。
        /// </summary>
        /// <param name="CaseId">單號</param>
        /// <returns><see cref="SQL_ExcuteResult"/> 類別物件。</returns>
        public SQL_ExcuteResult GetQuerying(string CaseId)
        {
            bool isSucc = false;
            string feedback;
            string dataJson = "";
            try
            {
                feedback = "Success";
                isSucc = true;

                var data = _withdrawItemInstance.GetDataByCaseId(CaseId);
                dataJson = JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                feedback = $"Fail，{ex.Message}";
            }

            return new SQL_ExcuteResult
            {
                isSuccess = isSucc,
                FeedbackMsg = feedback,
                ReturnDataJson = dataJson,
            };
        }

        /// <summary>
        /// 取得查詢結果。
        /// </summary>
        /// <param name="account">帳號</param>
        /// <param name="date">日期(西元年/月)</param>
        /// <returns><see cref="SQL_ExcuteResult"/> 類別物件。</returns>
        public SQL_ExcuteResult GetQuerying(string account, string date)
        {
            bool isSucc = false;
            string feedback;
            string dataJson = "";
            try
            {
                feedback = "Success";
                isSucc = true;

                var data = _withdrawItemInstance.GetDataByAccountAndMonth(account, date);
                dataJson = JsonConvert.SerializeObject(data);
            }
            catch (Exception ex)
            {
                feedback = $"Fail，{ex.Message}";
            }

            return new SQL_ExcuteResult
            {
                isSuccess = isSucc,
                FeedbackMsg = feedback,
                ReturnDataJson = dataJson,
            };
        }

        public void ETL()
        {
            try
            {
                _withdrawItemInstance.InitializeCaseId();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
