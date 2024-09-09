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

/// <summary>
/// Summary description for MST_Hospital_DataTreeDALBase
/// </summary>
/// .
/// 
namespace GNForm3C.DAL
{

    public class MST_Hospital_DataTreeDALBase : DataBaseConfig
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

        public MST_Hospital_DataTreeDALBase()
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
   
        public DataTable SelectPage(SqlInt32 HospitalID, SqlInt32 FinYearID, SqlDateTime OneDateOfMonth)
        { 
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Hospital_SelectPageDataTree"); 
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID); 
                sqlDB.AddInParameter(dbCMD, "@FinYearID", SqlDbType.Int, FinYearID);
                sqlDB.AddInParameter(dbCMD, "@OneDateOfMonth", SqlDbType.DateTime, OneDateOfMonth);    

                DataTable dtMST_Hospital = new DataTable("PR_MST_Hospital_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);
                  
                return dtMST_Hospital;
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
    }
}