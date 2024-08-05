using GNForm3C.DAL;
using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;
 

namespace GNForm3C.DAL
{
    public class MST_BranchIntakeDALBase : DataBaseConfig
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

        public MST_BranchIntakeDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation
        public Boolean Insert(MST_BranchIntakeENT entMST_BranchIntake)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_Insert");

                //sqlDB.AddOutParameter(dbCMD, "@BranchIntakeID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@Branch", SqlDbType.NVarChar, entMST_BranchIntake.Branch);
                sqlDB.AddInParameter(dbCMD, "@AdmissionYear", SqlDbType.Int, entMST_BranchIntake.AdmissionYear);
                sqlDB.AddInParameter(dbCMD, "@Intake", SqlDbType.NVarChar, entMST_BranchIntake.Intake); 

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                //entMST_BranchIntake.BranchIntakeID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@BranchIntakeID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_BranchIntakeENT entMST_BranchIntake)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_Update");
                 
                sqlDB.AddInParameter(dbCMD, "@Branch", SqlDbType.NVarChar, entMST_BranchIntake.Branch);
                sqlDB.AddInParameter(dbCMD, "@AdmissionYear", SqlDbType.Int, entMST_BranchIntake.AdmissionYear);
                sqlDB.AddInParameter(dbCMD, "@Intake", SqlDbType.NVarChar, entMST_BranchIntake.Intake);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 BranchIntakeID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_BranchIntake_Delete"); 
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DataTable SelectShow()
        {

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("GetBranchIntakeMatrix"); 
                
                DataTable dtMST_BranchIntakeShow = new DataTable("GetBranchIntakeMatrix");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_BranchIntakeShow);

                return dtMST_BranchIntakeShow;
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


    }
}
