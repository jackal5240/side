﻿using NiteenNity_Case_SQL_API.Mode.DataSet.DAO;
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
        public SQL_ExcuteResult UpdateWallet_WithdrawItem(int memberId, string date)
        {
            SQL_ExcuteResult result = new SQL_ExcuteResult();
            var aa = GetTimeRange(InputDateTimeFormat(date));
            try
            {
                int step = cancelDAO.UpdateWallet_WithdrawItem(memberId, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));

                if (step == 1)
                {
                    result.isSuccess = true;
                    result.FeedbackMsg = "Step1 更新成功 提領紀錄 Wallet_WithdrawItem";
                    result.ReturnDataJson = "{\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";
                }
                else
                {
                    result.isSuccess = false;
                    result.FeedbackMsg = "Step1 更新失敗 找不到資料 Wallet_WithdrawItem";
                    result.ReturnDataJson = "{\"functionEroor\":\"Step1 cancelServices.UpdateWallet_WithdrawItem\",\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";
                }

                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                result.isSuccess = false;
                result.FeedbackMsg = "Step1 更新失敗 提領紀錄 Wallet_WithdrawItem";
                result.ReturnDataJson = "{\"functionEroor\":\"Step1 cancelServices.UpdateWallet_WithdrawItem\",\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";

                return result;
            }
        }
        public SQL_ExcuteResult UpdateWallet_WalletItem(int memberId, string value)
        {
            SQL_ExcuteResult result = new SQL_ExcuteResult();
            try
            {
                int step = cancelDAO.UpdateWallet_WalletItem(memberId, value);

                if (step == 1)
                {
                    result.isSuccess = true;
                    result.FeedbackMsg = "Step2 更新成功 原始金額 Wallet_WalletItem";
                    result.ReturnDataJson = "{\"memeberId\":\"" + memberId + "\",\"value\":\"" + value + "\"}";
                }
                else
                {
                    result.isSuccess = false;
                    result.FeedbackMsg = "Step2 更新失敗 找不到資料 Wallet_WalletItem";
                    result.ReturnDataJson = "{\"functionEroor\":\"Step2 cancelServices.UpdateWallet_WalletItem\",\"memeberId\":\"" + memberId + "\",\"value\":\"" + value + "\"}";
                }

                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                result.isSuccess = false;
                result.FeedbackMsg = "Step2 更新失敗 原始金額 Wallet_WithdrawItem";
                result.ReturnDataJson = "{\"functionEroor\":\"Step2 cancelServices.UpdateWallet_WalletItem\",\"memeberId\":\"" + memberId + "\",\"value\":\"" + value + "\"}";

                return result;
            }
        }
        public SQL_ExcuteResult InsertWallet_WalletRecordItem(int memberId, string value, string date)
        {
            var aa = GetTimeRange(InputDateTimeFormat(date));
            SQL_ExcuteResult result = new SQL_ExcuteResult();
            try
            {
                int step = cancelDAO.InsertWallet_WalletRecordItem(memberId, value, aa.startTime.ToString("yyyy-MM-dd HH:mm:ss"), aa.endTime.ToString("yyyy-MM-dd HH:mm:ss"));

                if (step == 1)
                {
                    result.isSuccess = true;
                    result.FeedbackMsg = "Step3 新增成功 提領紀錄 Wallet_WalletRecordItem";
                    result.ReturnDataJson = "{\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";
                }
                else
                {
                    result.isSuccess = false;
                    result.FeedbackMsg = "Step3 新增失敗 找不到資料 Wallet_WalletRecordItem";
                    result.ReturnDataJson = "{\"functionEroor\":\"Step3 cancelServices.InsertWallet_WalletRecordItem\",\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";
                }

                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

                result.isSuccess = false;
                result.FeedbackMsg = "Step3 新增失敗 歷史紀錄 Wallet_WalletRecordItem";
                result.ReturnDataJson = "{\"functionEroor\":\"Step3 cancelServices.InsertWallet_WalletRecordItem\",\"memeberId\":\"" + memberId + "\",\"date\":\"" + date + "\"}";

                return result;
            }
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
