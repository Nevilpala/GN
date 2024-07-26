using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using GNForm3C;
using GNForm3C.DAL;
using GNForm3C.ENT;

namespace GNForm3C.BAL
{
    public class  MST_DSBBALBase
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

        public MST_DSBBALBase()
        {

        }

        #endregion Constructor

        #region Select
        public DataTable SelectCount(SqlInt32 HospitalID)
        {
            MST_DSBDAL dalMST_DSBDAL = new MST_DSBDAL(); 
            return dalMST_DSBDAL.SelectCount(HospitalID);
        }

        public DataTable IncomeList(SqlInt32 HospitalID, SqlInt32 Year)
        {
            MST_DSBDAL dalMST_DSBDAL = new MST_DSBDAL();
            return dalMST_DSBDAL.IncomeList(HospitalID, Year);
        }

        public DataTable ExpenseList(SqlInt32 HospitalID, SqlInt32 Year)
        {
            MST_DSBDAL dalMST_DSBDAL = new MST_DSBDAL();
            return dalMST_DSBDAL.ExpenseList(HospitalID, Year);
        }

        public DataTable TreatmentSummaryList(SqlInt32 HospitalID)
        {
            MST_DSBDAL dalMST_DSBDAL = new MST_DSBDAL();
            return dalMST_DSBDAL.TreatmentSummaryList(HospitalID);
        }

        #endregion Select

    }
}