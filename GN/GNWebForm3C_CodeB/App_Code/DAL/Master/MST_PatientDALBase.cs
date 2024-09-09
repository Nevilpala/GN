using GNForm3C.ENT;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_PatientDALBas
namespace GNForm3C.DAL
{
    public abstract class MST_PatientDALBase : DataBaseConfig
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

        public MST_PatientDALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation 

        public Boolean Insert(MST_PatientENT entMST_Patient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Insert");
                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_Patient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Patient.PatientID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PatientID"].Value);

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

        public SqlInt32 InsertPatient(MST_PatientENT entMST_Patient)
        {
            SqlInt32 PatientID = -1;

            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Insert");

                sqlDB.AddOutParameter(dbCMD, "@PatientID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_Patient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Patient.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                if (!(dbCMD.Parameters["@PatientID"].Value).Equals(DBNull.Value))
                {
                    entMST_Patient.PatientID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@PatientID"].Value);
                    PatientID = entMST_Patient.PatientID;
                }

                return PatientID;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return PatientID;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return PatientID;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_PatientENT entMST_Patient)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Update");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, entMST_Patient.PatientID);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, entMST_Patient.PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, entMST_Patient.Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, entMST_Patient.MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, entMST_Patient.DOB);
                sqlDB.AddInParameter(dbCMD, "@PrimaryDesc", SqlDbType.NVarChar, entMST_Patient.PrimaryDesc);
                sqlDB.AddInParameter(dbCMD, "@PatientPhotoPath", SqlDbType.NVarChar, entMST_Patient.PatientPhotoPath);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Patient.UserID);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Patient.Modified);

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

        public Boolean Delete(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_Delete");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

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

        public MST_PatientENT SelectPK(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                MST_PatientENT entMST_Patient = new MST_PatientENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["PatientID"].Equals(System.DBNull.Value))
                            entMST_Patient.PatientID = Convert.ToInt32(dr["PatientID"]);

                        if (!dr["PatientName"].Equals(System.DBNull.Value))
                            entMST_Patient.PatientName = Convert.ToString(dr["PatientName"]);

                        if (!dr["Age"].Equals(System.DBNull.Value))
                            entMST_Patient.Age = Convert.ToInt32(dr["Age"]);

                        if (!dr["MobileNo"].Equals(System.DBNull.Value))
                            entMST_Patient.MobileNo = Convert.ToString(dr["MobileNo"]);

                        if (!dr["DOB"].Equals(System.DBNull.Value))
                            entMST_Patient.DOB = Convert.ToDateTime(dr["DOB"]);

                        if (!dr["PrimaryDesc"].Equals(System.DBNull.Value))
                            entMST_Patient.PrimaryDesc = Convert.ToString(dr["PrimaryDesc"]);

                        if (!dr["PatientPhotoPath"].Equals(System.DBNull.Value))
                            entMST_Patient.PatientPhotoPath = Convert.ToString(dr["PatientPhotoPath"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_Patient.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Patient.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Patient.Modified = Convert.ToDateTime(dr["Modified"]);

                    }
                }
                return entMST_Patient;
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

        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectAll");

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString PatientName, SqlInt32 Age, SqlString MobileNo, SqlDateTime DOB)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@PatientName", SqlDbType.NVarChar, PatientName);
                sqlDB.AddInParameter(dbCMD, "@Age", SqlDbType.Int, Age);
                sqlDB.AddInParameter(dbCMD, "@MobileNo", SqlDbType.NVarChar, MobileNo);
                sqlDB.AddInParameter(dbCMD, "@DOB", SqlDbType.DateTime, DOB);

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtMST_Patient;
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

        public DataTable SelectView(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectView");

                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                DataTable dtACC_GNTransaction = new DataTable("PR_MST_Patient_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtACC_GNTransaction);

                return dtACC_GNTransaction;
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

        public DataTable SelectComboBox()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_SelectComboBox");

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_SelectComboBox");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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
        #endregion ComboBox

        #region AutoComplete

        public DataTable AutoComplete(SqlString TxtSearch, SqlString TxtContext)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Patient_AutoComplete");
                sqlDB.AddInParameter(dbCMD, "@TxtSearch", SqlDbType.NVarChar, TxtSearch);
                sqlDB.AddInParameter(dbCMD, "@TxtContext", SqlDbType.NVarChar, TxtContext);

                DataTable dtMST_Patient = new DataTable("PR_MST_Patient_AutoComplete");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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
        #endregion AutoComplete

        #region REPORT
        public DataTable RPT_MST_PatientIDCard(SqlInt32 PatientID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PP_MST_PatientList");
                sqlDB.AddInParameter(dbCMD, "@PatientID", SqlDbType.Int, PatientID);

                DataTable dtMST_Patient = new DataTable("PP_MST_PatientList");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Patient);

                return dtMST_Patient;
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

        #endregion REPORT
    }
}