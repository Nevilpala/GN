using GNForm3C.BAL;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_Reports_RPT_ACC_Income_RPT_HospitalWiseIncomeTypeWiseData : System.Web.UI.Page
{

    #region Private Variable

    private DataTable dtACC_Income = new DataTable("dtACC_Income");
    private dsACC_Income objdsACC_Income = new dsACC_Income();
    #endregion Private Variable

    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowReport();
        }
    }
    #endregion Page Load Event

    #region ShowReport

    protected void ShowReport()
    {
        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
        dtACC_Income = balACC_Income.Report_ACC_Income_ByFinYear();
        FillDataSet();
    }

    #endregion ShowReport


    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Income.Rows)
        {
            dsACC_Income.dtACC_IncomeRow drACC_Income = objdsACC_Income.dtACC_Income.NewdtACC_IncomeRow();

            if (!dr["IncomeID"].Equals(System.DBNull.Value))
                drACC_Income.IncomeID = Convert.ToInt32(dr["IncomeID"]);

            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drACC_Income.FinYearID = Convert.ToInt32(dr["FinYearID"]);

            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drACC_Income.HospitalID = Convert.ToInt32(dr["HospitalID"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_Income.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_Income.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["IncomeType"].Equals(System.DBNull.Value))
                drACC_Income.IncomeType = Convert.ToString(dr["IncomeType"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drACC_Income.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["IncomeDate"].Equals(System.DBNull.Value))
                drACC_Income.IncomeDate = Convert.ToDateTime(dr["IncomeDate"]).ToString(CV.DefaultDateFormat);


            objdsACC_Income.dtACC_Income.Rows.Add(drACC_Income);

        }

        SetReportParamater();
        this.rvIncome.LocalReport.DataSources.Clear();
        this.rvIncome.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Income", (DataTable)objdsACC_Income.dtACC_Income));
        this.rvIncome.LocalReport.Refresh();
    }
    #endregion FillDataSet


    #region SetReportParamater
    protected void SetReportParamater()
    {
        String ReportTitle = "Income Report (Hospital & IncomeType)";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvIncome.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptPrintDate });

    }
    #endregion SetReportParamater

}