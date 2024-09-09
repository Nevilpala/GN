using GNForm3C.DAL;
using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_ExpInm_LedgerDALBase
/// </summary>'
/// 

namespace GNForm3C.DAL
{
    public class ACC_ExpInm_LedgerDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
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

        #endregion Properties

        #region Constructor

        public ACC_ExpInm_LedgerDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation


        #endregion InsertOperation

        #region UpdateOperation

        #endregion UpdateOperation

        #region DeleteOperation

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_ACC_ExpInm_Ledger_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);

                DataTable dtACC_Expense = new DataTable("PR_ACC_ExpInm_Ledger_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtACC_Expense;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }



        #endregion SelectOperation

        #region ComboBox


        #endregion ComboBox

        #region AutoComplete


        #endregion AutoComplete

        #region Report 

        public DataTable RPT_LedgerIncomeExpense(SqlInt32 HospitalID, SqlInt32 FinYearID,SqlDateTime FromDate,SqlDateTime ToDate )
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_ACC_LedgerList");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
                sqlDB.AddInParameter(dbCMD, "@FromDate", SqlDbType.DateTime, FromDate);
                sqlDB.AddInParameter(dbCMD, "@ToDate", SqlDbType.DateTime, ToDate);

                DataTable dtACC_Expense = new DataTable("PP_ACC_LedgerList");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

                return dtACC_Expense;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        public DataTable RPT_FinYearWiseHospitalWiseIncomeExpense()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_FinYearWise_HospitalWise_IncomeExpenseList");

                DataTable dtACC_Expense = new DataTable("PP_FinYearWise_HospitalWise_IncomeExpenseList");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_Expense);

                return dtACC_Expense;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion Report

    }
}