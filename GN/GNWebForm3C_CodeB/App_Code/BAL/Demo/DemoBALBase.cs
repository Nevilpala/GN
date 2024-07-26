using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Data; 

/// <summary>
/// Summary description for DemoBALBase
/// </summary>
/// 

namespace GNForm3C.ENT
{
    public abstract class DemoBALBase
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

        public DemoBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(DemoENT entDemo)
        {
            DemoDAL dalDemo = new DemoDAL();
            if (dalDemo.Insert(entDemo))
            {
                return true;
            }
            else
            {
                this.Message = dalDemo.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(DemoENT entDemo)
        {
            DemoDAL dalDemo = new DemoDAL();
            if (dalDemo.Update(entDemo))
            {
                return true;
            }
            else
            {
                this.Message = dalDemo.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 DemoID)
        {
            DemoDAL dalDemo = new DemoDAL();
            if (dalDemo.Delete(DemoID))
            {
                return true;
            }
            else
            {
                this.Message = dalDemo.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public DemoENT SelectPK(SqlInt32 DemoID)
        {
            DemoDAL dalDemo = new DemoDAL();
            return dalDemo.SelectPK(DemoID);
        }
        public DataTable SelectView(SqlInt32 DemoID)
        {
            DemoDAL dalDemo = new DemoDAL();
            return dalDemo.SelectView(DemoID);
        }
        public DataTable SelectAll()
        {
            DemoDAL dalDemo = new DemoDAL();
            return dalDemo.SelectAll();
        }
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString DemoName, SqlString DemoType)
        {
            DemoDAL dalDemo = new DemoDAL();
            return dalDemo.SelectPage(PageOffset, PageSize, out TotalRecords,DemoName,DemoType);
        }

        #endregion SelectOperation

        #region ComboBox

        public DataTable SelectComboBox()
        {
            DemoDAL dalDemo = new DemoDAL();
            return dalDemo.SelectComboBox();
        }

        #endregion ComboBox

    }
}