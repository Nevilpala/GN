using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Demo_Demo_DemoAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "DemoAddEdit";

    #endregion 10.0 Variables 

    #region 11.0 Page Load Event 

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login 

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login 

        if (!Page.IsPostBack)
        {
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Menu";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtDemoName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 

            #region 11.6 Set Help Text 

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.6 Set Help Text 

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList 

    private void FillDropDownList()
    {
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["DemoID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Demo";
            DemoBAL balDemo = new DemoBAL();
            DemoENT entDemo = new DemoENT();
            entDemo = balDemo.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["DemoID"]));

            if (!entDemo.DemoName.IsNull)
                txtDemoName.Text = entDemo.DemoName.Value.ToString();

            if (!entDemo.DemoType.IsNull)
                txtDemoType.Text = entDemo.DemoType.Value.ToString();

           
        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                DemoBAL balDemo = new DemoBAL();
                DemoENT entDemo = new DemoENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtDemoName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Demo Name");
                
                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                
                if (txtDemoName.Text.Trim() != String.Empty)
                    entDemo.DemoName = txtDemoName.Text.Trim();

                if (txtDemoType.Text.Trim() != String.Empty)
                    entDemo.DemoType = txtDemoType.Text.Trim();
  
                 


                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["DemoID"] != null && Request.QueryString["Copy"] == null)
                {
                    entDemo.DemoID = CommonFunctions.DecryptBase64Int32(Request.QueryString["DemoID"]);
                    if (balDemo.Update(entDemo))
                    {
                        Response.Redirect("DemoList.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balDemo.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["DemoID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balDemo.Insert(entDemo))
                        {
                            ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                            ClearControls();
                        }
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void ClearControls()
    {
        
        txtDemoName.Text = String.Empty;
        txtDemoType.Text = String.Empty;
        
    }

    #endregion 16.0 Clear Controls 
}