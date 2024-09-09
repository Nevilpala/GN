using GNForm3C.BAL;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Reports_RPT_ACC_Ledger_RPT_FinYearWiseHospitalWiseIncomeExpenseMatrix : System.Web.UI.Page
{
    #region Private Variable
    private DataTable dtACC_IncomeExpense = new DataTable("dtACC_IncomeExpense");
    private dsACC_IncomeExpense objdsACC_IncomeExpense = new dsACC_IncomeExpense();

    #endregion
    #region Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ShowReport();
        }

    }
    #endregion Page Load Event

    #region Show Report
    protected void ShowReport()
    {
        try
        {
            ACC_ExpInm_LedgerBAL balACC_ExpInm_Ledger = new ACC_ExpInm_LedgerBAL();
            dtACC_IncomeExpense = balACC_ExpInm_Ledger.RPT_FinYearWiseHospitalWiseIncomeExpense();
            FillDataSet();
        }
        catch (Exception ex)
        {

        }

    }
    #endregion Show Report

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_IncomeExpense.Rows)
        {
            dsACC_IncomeExpense.dtACC_IncomeExpenseRow drACC_IncomeExpense = objdsACC_IncomeExpense.dtACC_IncomeExpense.NewdtACC_IncomeExpenseRow();

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_IncomeExpense.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_IncomeExpense.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["TotalIncome"].Equals(System.DBNull.Value))
                drACC_IncomeExpense.TotalIncome = Convert.ToDecimal(dr["TotalIncome"]);

            if (!dr["TotalExpense"].Equals(System.DBNull.Value))
                drACC_IncomeExpense.TotalExpense = Convert.ToDecimal(dr["TotalExpense"]);

            if (!dr["TotalPatients"].Equals(System.DBNull.Value))
                drACC_IncomeExpense.TotalPatients = Convert.ToInt32(dr["TotalPatients"]);


            objdsACC_IncomeExpense.dtACC_IncomeExpense.Rows.Add(drACC_IncomeExpense);
        }

        SetReportParameters();
        this.rvIncomeExpenseList.LocalReport.DataSources.Clear();
        this.rvIncomeExpenseList.LocalReport.DataSources.Add(new ReportDataSource("dtACC_IncomeExpense", (DataTable)objdsACC_IncomeExpense.dtACC_IncomeExpense));
        this.rvIncomeExpenseList.LocalReport.Refresh();
    }
    #endregion FillDataSet


    #region SetReportParameter
    private void SetReportParameters()
    {
        String ReportTitle = "FinYear Wise Hospital Wise Income | Expense ";
        String ReportSubTitle = "Ledger Report";

        DateTime PrintDate = DateTime.Now;

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);

        ReportParameter rptFooterDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvIncomeExpenseList.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, rptFooterDate });
    }
    #endregion SetReportParameter

}