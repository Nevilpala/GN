using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_BranchIntakeBALBase
/// </summary>
/// 

namespace GNForm3C.BAL
{
    public abstract class MST_BranchIntakeBALBase
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

        public MST_BranchIntakeBALBase()
        {

        }

        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_BranchIntakeENT entMST_BranchIntake)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
            if (dalMST_BranchIntake.Insert(entMST_BranchIntake))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_BranchIntake.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_BranchIntakeENT entMST_BranchIntake)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
            if (dalMST_BranchIntake.Update(entMST_BranchIntake))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_BranchIntake.Message;
                return false;
            }
        }

        #endregion UpdateOperation


        #region DeleteOperation

        public Boolean Delete(SqlInt32 BranchIntakeID)
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
            if (dalMST_BranchIntake.Delete(BranchIntakeID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_BranchIntake.Message;
                return false;
            }
        }

        #endregion DeleteOperationa

        #region SelectOperation


        public DataTable SelectShow()
        {
            MST_BranchIntakeDAL dalMST_BranchIntake = new MST_BranchIntakeDAL();
            return dalMST_BranchIntake.SelectShow();
        }

        #endregion SelectOperation

        #region ComboBox  

        #endregion ComboBox
    }
}
