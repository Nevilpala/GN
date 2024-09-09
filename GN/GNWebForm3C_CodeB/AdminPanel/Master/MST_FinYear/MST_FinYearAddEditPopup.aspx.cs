using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_FinYear_MST_FinYearAddEditPopup : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "MST_FinYearAddEdit";

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

            lblFormHeader.Text = CV.PageHeaderAdd + " Fin Year";
            txtModelFinYearName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 



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
        if (Request.QueryString["FinYearID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Fin Year ";
            MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
            MST_FinYearENT entMST_FinYear = new MST_FinYearENT();
            entMST_FinYear = balMST_FinYear.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]));

            if (!entMST_FinYear.FinYearName.IsNull)
                txtModelFinYearName.Text = entMST_FinYear.FinYearName.Value.ToString();

            if (!entMST_FinYear.FromDate.IsNull)
                dtpModelFromDate.Text = entMST_FinYear.FromDate.Value.ToString(CV.DefaultDateFormat);

            if (!entMST_FinYear.ToDate.IsNull)
                dtpModelToDate.Text = entMST_FinYear.ToDate.Value.ToString(CV.DefaultDateFormat);

            if (!entMST_FinYear.Remarks.IsNull)
                txtModelRemarks.Text = entMST_FinYear.Remarks.Value.ToString();
        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSaveModel_Click(object sender, EventArgs e)
    {
        Page.Validate("vgFinYear");
        
        if (Page.IsValid)
        {
            try
            {
                bool IsValidate = true;
                MST_FinYearBAL balMST_FinYear = new MST_FinYearBAL();
                MST_FinYearENT entMST_FinYear = new MST_FinYearENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtModelFinYearName.Text.Trim() == string.Empty || txtModelFinYearName.Text.Trim() == "a")
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Fin Year Name");
                if (dtpModelFromDate.Text.Trim() == string.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("From Date");
                if (dtpModelToDate.Text.Trim() == string.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("To Date");


                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    //ucMessage1.ShowError(ErrorMsg);
                    // Set the data-target attribute dynamically
                    btnSaveModel.Attributes["data-target"] = "#viewiFrameReg";
                    btnSaveModel.Attributes["data-toggle"] = "modal";

                    // Use JavaScript to show the modal again
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MasterPageView", "parent.$('#viewiFrameReg').modal('show');", true);

                    IsValidate = false; 

                    throw new Exception(ErrorMsg);

                }

                #endregion 15.1 Validate Fields

                if (IsValidate)
                {

                    #region 15.2 Gather Data 



                    if (txtModelFinYearName.Text.Trim() != String.Empty)
                        entMST_FinYear.FinYearName = txtModelFinYearName.Text.Trim();

                    if (dtpModelFromDate.Text.Trim() != String.Empty)
                        entMST_FinYear.FromDate = Convert.ToDateTime(dtpModelFromDate.Text.Trim());

                    if (dtpModelToDate.Text.Trim() != String.Empty)
                        entMST_FinYear.ToDate = Convert.ToDateTime(dtpModelToDate.Text.Trim());

                    if (txtModelRemarks.Text.Trim() != String.Empty)
                        entMST_FinYear.Remarks = txtModelRemarks.Text.Trim();



                    entMST_FinYear.UserID = Convert.ToInt32(Session["UserID"]);

                    entMST_FinYear.Created = DateTime.Now;

                    entMST_FinYear.Modified = DateTime.Now;

                    #endregion 15.2 Gather Data 


                    #region 15.3 Insert,Update,Copy 

                    if (Request.QueryString["FinYearID"] != null && Request.QueryString["Copy"] == null)
                    {
                        entMST_FinYear.FinYearID = CommonFunctions.DecryptBase64Int32(Request.QueryString["FinYearID"]);
                        if (balMST_FinYear.Update(entMST_FinYear))
                        {
                            // Use Response.Redirect with endResponse set to false
                            Response.Redirect("MST_FinYearList.aspx", false);

                            // Complete the request
                            Context.ApplicationInstance.CompleteRequest();
                        }
                        else
                        {
                            ucMessage1.ShowError(balMST_FinYear.Message);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "parent.$('#viewiFrameReg').modal('show');", true);
                        }
                    }

                    else
                    {
                        if (Request.QueryString["FinYearID"] == null || Request.QueryString["Copy"] != null)
                        {
                            if (balMST_FinYear.Insert(entMST_FinYear))
                            {
                                ucMessage1.ShowSuccess(CommonMessage.RecordSaved());
                                ClearControls();
                                Response.Redirect("MST_FinYearList.aspx");
                                Context.ApplicationInstance.CompleteRequest();

                            }
                            else
                            {
                                ucMessage1.ShowError(balMST_FinYear.Message);
                                ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#viewiFrameReg').modal('show');", true);
                            }
                        }
                    }

                    #endregion 15.3 Insert,Update,Copy
                }


            }
            catch (Exception ex)
            {
                ucMessage1.ShowError(ex.Message);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "MasterPageView", "$('#viewiFrameReg').modal('show');", true);
                //throw;
            }
        }
        else
        {
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "MasterPageView", "parent.$('#viewiFrameReg').modal('show');", true);


        }


    }


    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 
    private void ClearControls()
    {
        txtModelFinYearName.Text = String.Empty;
        dtpModelFromDate.Text = String.Empty;
        dtpModelToDate.Text = String.Empty;
        txtModelRemarks.Text = String.Empty;
        txtModelFinYearName.Focus();
    }


    #endregion 16.0 Clear Controls 
}