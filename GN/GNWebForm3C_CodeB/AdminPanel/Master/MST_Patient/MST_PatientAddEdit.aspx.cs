using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class AdminPanel_Master_MST_Patient_MST_PatientAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "MST_PatientAddEdit";

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

            lblFormHeader.Text = CV.PageHeaderAdd + " Patient";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtPatientName.Focus();

            imgPatientPhotoPath.ImageUrl = CV.DefaultNoImagePath;

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
        if (Request.QueryString["PatientID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Patient";
            MST_PatientBAL balMST_Patient = new MST_PatientBAL();
            MST_PatientENT entMST_Patient = new MST_PatientENT();
            entMST_Patient = balMST_Patient.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["PatientID"]));

            if (!entMST_Patient.PatientName.IsNull)
                txtPatientName.Text = entMST_Patient.PatientName.Value.ToString();

            if (!entMST_Patient.MobileNo.IsNull)
                txtMobileNo.Text = entMST_Patient.MobileNo.Value.ToString();

            if (!entMST_Patient.Age.IsNull)
                txtAge.Text = entMST_Patient.Age.Value.ToString();

            if (!entMST_Patient.DOB.IsNull)
                dtpDOB.Text = Convert.ToDateTime(entMST_Patient.DOB.Value.ToString()).ToString(CV.DefaultDateFormat);

            if (!entMST_Patient.PrimaryDesc.IsNull)
                txtPrimaryDesc.Text = entMST_Patient.PrimaryDesc.Value.ToString();

            if (!entMST_Patient.PatientPhotoPath.IsNull)
            {
                hfPatientPhotoPath.Value = entMST_Patient.PatientPhotoPath.Value.ToString();
                imgPatientPhotoPath.ImageUrl = entMST_Patient.PatientPhotoPath.Value.ToString();

            }


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
                MST_PatientBAL balMST_Patient = new MST_PatientBAL();
                MST_PatientENT entMST_Patient = new MST_PatientENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtPatientName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Patient");

                if (txtAge.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Age");

                if (txtMobileNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Mobile No");

                if (dtpDOB.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("DOB");


                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                if (txtPatientName.Text.Trim() != String.Empty)
                    entMST_Patient.PatientName = txtPatientName.Text.Trim();

                if (txtMobileNo.Text.Trim() != String.Empty)
                    entMST_Patient.MobileNo = txtMobileNo.Text.Trim();

                if (txtAge.Text.Trim() != String.Empty)
                    entMST_Patient.Age = Convert.ToInt32(txtAge.Text.Trim());

                if (dtpDOB.Text.Trim() != String.Empty)
                    entMST_Patient.DOB = Convert.ToDateTime(dtpDOB.Text.Trim());


                if (txtPrimaryDesc.Text.Trim() != String.Empty)
                    entMST_Patient.PrimaryDesc = txtPrimaryDesc.Text.Trim();

                if (hfPatientPhotoPath.Value.Trim() != String.Empty)
                    entMST_Patient.PatientPhotoPath = hfPatientPhotoPath.Value.Trim();

                if (fuPatientPhotoPath.HasFile)
                {
                    //if (entMST_Patient.PatientPhotoPath.ToString().Trim() != String.Empty && !entMST_Patient.PatientPhotoPath.Equals(DBNull.Value))
                    //{
                    //    string physicalPath = Server.MapPath(entMST_Patient.PatientPhotoPath.ToString());
                    //    if (File.Exists(physicalPath))
                    //    {
                    //        try
                    //        {
                    //            // Delete the file
                    //            File.Delete(physicalPath); 
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            // Handle any errors that occur during the deletion 
                    //        }
                    //    }  
                    //}

                    string PhotoPath = "~/Default/Images/Patient/";
                    string AbsoutePath = Server.MapPath(PhotoPath);
                    string UniqueID = DateTime.Now.ToString();
                    if (!Directory.Exists(AbsoutePath))
                        Directory.CreateDirectory(AbsoutePath);
                    fuPatientPhotoPath.SaveAs(AbsoutePath + fuPatientPhotoPath.FileName.ToString().Trim());


                    entMST_Patient.PatientPhotoPath = PhotoPath + fuPatientPhotoPath.FileName.ToString().Trim();

                }


                entMST_Patient.UserID = Convert.ToInt32(Session["UserID"]);

                entMST_Patient.Created = DateTime.Now;

                entMST_Patient.Modified = DateTime.Now;


                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["PatientID"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Patient.PatientID = CommonFunctions.DecryptBase64Int32(Request.QueryString["PatientID"]);
                    if (balMST_Patient.Update(entMST_Patient))
                    {
                        Response.Redirect("MST_PatientList.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balMST_Patient.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["PatientID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Patient.Insert(entMST_Patient))
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
        txtPatientName.Text = String.Empty;
        txtMobileNo.Text = String.Empty;
        txtAge.Text = String.Empty;
        dtpDOB.Text = String.Empty;
        imgPatientPhotoPath.ImageUrl = String.Empty;
    }

    #endregion 16.0 Clear Controls 

}