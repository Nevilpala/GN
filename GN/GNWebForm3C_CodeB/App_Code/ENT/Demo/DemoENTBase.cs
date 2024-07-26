using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DemoENTBase
/// </summary>
/// 


namespace GNForm3C.ENT
{
    public abstract class DemoENTBase
    {

        #region Properties


        protected SqlInt32 _DemoID;
        public SqlInt32 DemoID
        {
            get
            {
                return _DemoID;
            }
            set
            {
                _DemoID = value;
            }
        }

        protected SqlString _DemoName;
        public SqlString DemoName
        {
            get
            {
                return _DemoName;
            }
            set
            {
                _DemoName = value;
            }
        }

        protected SqlString _DemoType;
        public SqlString DemoType
        {
            get
            {
                return _DemoType;
            }
            set
            {
                _DemoType = value;
            }
        }
        #endregion Properties

        #region Constructor

        public DemoENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String DemoENT_String = String.Empty;

            if (!DemoID.IsNull)
                DemoENT_String += " DemoID = " + DemoID.Value.ToString();

            if (!DemoName.IsNull)
                DemoENT_String += "| DemoName = " + DemoName.Value;

            if (!DemoType.IsNull)
                DemoENT_String += "| DemoType = " + DemoType.Value;


            DemoENT_String = DemoENT_String.Trim();

            return DemoENT_String;
        }

        #endregion ToString


    }
}