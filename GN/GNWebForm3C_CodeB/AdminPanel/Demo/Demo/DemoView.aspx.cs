using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.ENT;

public partial class AdminPanel_Demo_Demo_DemoView : System.Web.UI.Page
{

    #region Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 10.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 10.1 Check User Login 

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["DemoID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["DemoID"] != null)
        {
            DemoBAL balDemo = new DemoBAL();
            DataTable dtDemo = balDemo.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["DemoID"]));
            if (dtDemo != null)
            {
                foreach (DataRow dr in dtDemo.Rows)
                { 
                    if (!dr["DemoName"].Equals(DBNull.Value))
                        lblDemoName.Text = Convert.ToString(dr["DemoName"]);

                    if (!dr["DemoType"].Equals(DBNull.Value))
                        lblDemoType.Text = Convert.ToString(dr["DemoType"]);

                }
            }
        }
    }
    #endregion FillControls
}