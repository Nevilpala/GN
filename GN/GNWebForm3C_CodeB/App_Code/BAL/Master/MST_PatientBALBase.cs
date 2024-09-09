using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_PatientBALBase
/// </summary>

namespace GNForm3C.BAL
{
    public abstract class MST_PatientBALBase
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

        public MST_PatientBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public SqlInt32 InsertPatient(MST_PatientENT entMST_Patient)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            SqlInt32 PatientID = dalMST_Patient.InsertPatient(entMST_Patient);

            if (PatientID > 0)
            {
                return PatientID;
            }
            else
            {
                this.Message = dalMST_Patient.Message;
                return PatientID;
            }
        }

        public Boolean Insert(MST_PatientENT entMST_Patient)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            if (dalMST_Patient.Insert(entMST_Patient))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Patient.Message;
                return false;
            }
        }




        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_PatientENT entMST_Patient)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            if (dalMST_Patient.Update(entMST_Patient))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Patient.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            if (dalMST_Patient.Delete(PatientID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Patient.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_PatientENT SelectPK(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectPK(PatientID);
        }
        public DataTable SelectView(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectView(PatientID);
        }
        public DataTable SelectAll()
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectAll();
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString PatientName, SqlInt32 Age, SqlString MobileNo, SqlDateTime DOB)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectPage(PageOffset, PageSize, out TotalRecords, PatientName, Age, MobileNo, DOB);
        }

        #endregion SelectOperation

        #region ComboBox


        public DataTable SelectComboBox()
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectComboBox();
        }


        #endregion ComboBox

        #region REPORT
        public DataTable RPT_MST_PatientIDCard(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.RPT_MST_PatientIDCard(PatientID);
        }
        #endregion REPORT

        #region AutoComplete
        public DataTable AutoComplete(SqlString prefixText, SqlString contextText)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.AutoComplete(prefixText, contextText);
        }
        #endregion AutoComplete
    }


}