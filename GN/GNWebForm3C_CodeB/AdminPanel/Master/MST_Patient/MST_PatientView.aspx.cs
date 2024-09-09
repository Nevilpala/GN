using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Patient_MST_PatientView : System.Web.UI.Page
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
            if (Request.QueryString["PatientID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["PatientID"] != null)
        {

            ucPatient.ShowPatient(CommonFunctions.DecryptBase64Int32(Request.QueryString["PatientID"]));
            //MST_PatientBAL balMST_Patient = new MST_PatientBAL();
            //DataTable dtMST_Patient = balMST_Patient.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["PatientID"]));
            //if (dtMST_Patient != null)
            //{
            //    foreach (DataRow dr in dtMST_Patient.Rows)
            //    {

            //        if (!dr["Patient"].Equals(DBNull.Value))
            //            lblPatient.Text = Convert.ToString(dr["Patient"]);

            //        if (!dr["Hospital"].Equals(DBNull.Value))
            //            lblHospitalID.Text = Convert.ToString(dr["Hospital"]);

            //        if (!dr["Remarks"].Equals(DBNull.Value))
            //            lblRemarks.Text = Convert.ToString(dr["Remarks"]);

            //        if (!dr["UserName"].Equals(DBNull.Value))
            //            lblUserID.Text = Convert.ToString(dr["UserName"]);

            //        if (!dr["Created"].Equals(DBNull.Value))
            //            lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

            //        if (!dr["Modified"].Equals(DBNull.Value))
            //            lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

            //    }
            //}
        }
    }
    #endregion FillControls
}