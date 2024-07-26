using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ACC_ExpInm_LedgerENTBase
/// </summary>
/// 


namespace GNForm3C.ENT
{
    public class ACC_ExpInm_LedgerENTBase
    {
        #region Properties


        protected SqlInt32 _ACC_ExpInm_LedgerID;
        public SqlInt32 ACC_ExpInm_LedgerID
        {
            get
            {
                return _ACC_ExpInm_LedgerID;
            }
            set
            {
                _ACC_ExpInm_LedgerID = value;
            }
        }

       

        protected SqlDecimal _ACC_ExpInm_LedgerAmount;
        public SqlDecimal ACC_ExpInm_LedgerAmount
        {
            get
            {
                return _ACC_ExpInm_LedgerAmount;
            }
            set
            {
                _ACC_ExpInm_LedgerAmount = value;
            }
        }

        protected SqlDateTime _ACC_ExpInm_LedgerDate;
        public SqlDateTime ACC_ExpInm_LedgerDate
        {
            get
            {
                return _ACC_ExpInm_LedgerDate;
            }
            set
            {
                _ACC_ExpInm_LedgerDate = value;
            }
        }

        protected SqlString _ACC_ExpInm_LedgerNote;
        public SqlString ACC_ExpInm_LedgerNote
        {
            get
            {
                return _ACC_ExpInm_LedgerNote;
            }
            set
            {
                _ACC_ExpInm_LedgerNote = value;
            }
        }

        protected SqlString _ACC_ExpInm_LedgerType;
        public SqlString ACC_ExpInm_LedgerType
        {
            get
            {
                return _ACC_ExpInm_LedgerType;
            }
            set
            {
                _ACC_ExpInm_LedgerType = value;
            }
        }

        #endregion Properties

        #region Constructor
        public ACC_ExpInm_LedgerENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String ACC_ExpInm_LedgerENT_String = String.Empty;

            if (!ACC_ExpInm_LedgerID.IsNull)
                ACC_ExpInm_LedgerENT_String += " ACC_ExpInm_LedgerID = " + ACC_ExpInm_LedgerID.Value.ToString();

            if (!ACC_ExpInm_LedgerType.IsNull)
                ACC_ExpInm_LedgerENT_String += "| ACC_ExpInm_LedgerType = " + ACC_ExpInm_LedgerType.Value.ToString();

            if (!ACC_ExpInm_LedgerAmount.IsNull)
                ACC_ExpInm_LedgerENT_String += "| ACC_ExpInm_LedgerAmount = " + ACC_ExpInm_LedgerAmount.Value.ToString();

            if (!ACC_ExpInm_LedgerDate.IsNull)
                ACC_ExpInm_LedgerENT_String += "| ACC_ExpInm_LedgerDate = " + ACC_ExpInm_LedgerDate.Value.ToString("dd-MM-yyyy");

            if (!ACC_ExpInm_LedgerNote.IsNull)
                ACC_ExpInm_LedgerENT_String += "| ACC_ExpInm_LedgerNote = " + ACC_ExpInm_LedgerNote.Value;
             

            ACC_ExpInm_LedgerENT_String = ACC_ExpInm_LedgerENT_String.Trim();

            return ACC_ExpInm_LedgerENT_String;
        }

        #endregion ToString
    }
}
