using GNForm3C;
using GNForm3C.BAL;
using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlTypes;

public partial class UserControl_ucPatient : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            hlPrint.DataBind();

        }
    }

    public void ShowPatient(SqlInt32 PatientID)
    {
        MST_PatientBAL balMST_Patient = new MST_PatientBAL();
        System.Data.DataTable dtPatient = balMST_Patient.SelectView(PatientID);
        imhPatient.ImageUrl = CV.DefaultNoImagePath;

        if (dtPatient != null)
        {
            foreach (DataRow dr in dtPatient.Rows)
            {

                if (!dr["PatientID"].Equals(DBNull.Value))
                    ViewState["PatientID"] = dr["PatientID"].ToString();

                if (!dr["PatientName"].Equals(DBNull.Value))
                {
                    lblucPatientName.Text = Convert.ToString(dr["PatientName"]);
                    lblucTitle.Text = Convert.ToString(dr["PatientName"]);

                }

                if (!dr["Age"].Equals(DBNull.Value))
                    lblucPatietAge.Text = Convert.ToString(dr["Age"]);

                if (!dr["DOB"].Equals(DBNull.Value))
                    lblucDOB.Text = Convert.ToDateTime(dr["DOB"]).ToString(CV.DefaultDateFormat);

                if (!dr["MobileNo"].Equals(DBNull.Value))
                    lblucMobileNo.Text = Convert.ToString(dr["MobileNo"]);

                if (!dr["PrimaryDesc"].Equals(DBNull.Value))
                    lblucPrimaryDesc.Text = Convert.ToString(dr["PrimaryDesc"]);

                if (!dr["PatientPhotoPath"].Equals(DBNull.Value))
                    imhPatient.ImageUrl = dr["PatientPhotoPath"].ToString();



            }
        }

        mvwPatient.SetActiveView(vwPatient);
        mvwPatient.Visible = true;
    }
}