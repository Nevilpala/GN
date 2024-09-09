using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_ExpInm_LedgerBALBase
/// </summary>
/// 
namespace GNForm3C.BAL
{
    public class ACC_ExpInm_LedgerBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor

        public ACC_ExpInm_LedgerBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation
 

        #endregion InsertOperation

        #region UpdateOperation
 
        #endregion UpdateOperation

        #region UpsertOperation
 
        #endregion UpsertOperation


        #region DeleteOperation

         
        #endregion DeleteOperation

        #region SelectOperation

       
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate)
        {
            ACC_ExpInm_LedgerDAL dalACC_ExpInm_Ledger = new ACC_ExpInm_LedgerDAL();
            return dalACC_ExpInm_Ledger.SelectPage(PageOffset, PageSize, out TotalRecords, FromDate, ToDate);
        }

        #endregion SelectOperation

        #region ComboBox



        #endregion ComboBox


        #region Report
        public DataTable RPT_FinYearWiseHospitalWiseIncomeExpense()
        {
            ACC_ExpInm_LedgerDAL dalACC_Expense = new ACC_ExpInm_LedgerDAL();
            return dalACC_Expense.RPT_FinYearWiseHospitalWiseIncomeExpense();
        }


        public DataTable RPT_LedgerIncomeExpense(SqlInt32 HospitalID, SqlInt32 FinYearID, SqlDateTime FromDate, SqlDateTime ToDate)
        {
            ACC_ExpInm_LedgerDAL dalACC_Expense = new ACC_ExpInm_LedgerDAL();
            return dalACC_Expense.RPT_LedgerIncomeExpense(HospitalID,FinYearID,FromDate,ToDate);
        }

        #endregion Report
    }
}