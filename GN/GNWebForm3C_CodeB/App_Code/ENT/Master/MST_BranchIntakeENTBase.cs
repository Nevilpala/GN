using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_BranchIntakeENTBase
/// </summary>
/// 
namespace GNForm3C.ENT
{
    public abstract class MST_BranchIntakeENTBase
    {
        #region Properties 

        protected SqlInt32 _BranchIntakeID;
        public SqlInt32 BranchIntakeID
        {
            get
            {
                return _BranchIntakeID;
            }
            set
            {
                _BranchIntakeID = value;
            }
        }

        protected SqlString _Branch;
        public SqlString Branch
        {
            get
            {
                return _Branch;
            }
            set
            {
                _Branch = value;
            }
        }

        protected SqlInt32 _AdmissionYear;
        public SqlInt32 AdmissionYear
        {
            get
            {
                return _AdmissionYear;
            }
            set
            {
                _AdmissionYear = value;
            }
        }
 

        protected SqlInt32 _Intake;
        public SqlInt32 Intake
        {
            get
            {
                return _Intake;
            }
            set
            {
                _Intake = value;
            }
        }


        #endregion Properties

        #region Constructor

        public MST_BranchIntakeENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String MST_BranchIntakeENT_String = String.Empty;

            if (!BranchIntakeID.IsNull)
                MST_BranchIntakeENT_String += " MST_BranchIntakeID = " + BranchIntakeID.Value.ToString();

            if (!Branch.IsNull)
                MST_BranchIntakeENT_String += "| Branch = " + Branch.Value;

            if (!AdmissionYear.IsNull)
                MST_BranchIntakeENT_String += "| AdmissionYear = " + AdmissionYear.Value.ToString();

            if (!Intake.IsNull)
                MST_BranchIntakeENT_String += "| Intake = " + Intake.Value.ToString(); 

             MST_BranchIntakeENT_String = MST_BranchIntakeENT_String.Trim();

            return MST_BranchIntakeENT_String;
        }

        #endregion ToString
    }
}
