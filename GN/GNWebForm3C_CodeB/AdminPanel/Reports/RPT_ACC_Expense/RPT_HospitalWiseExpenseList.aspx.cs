﻿using GNForm3C.BAL;
using GNForm3C;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class AdminPanel_Reports_RPT_ACC_Expense_RPT_HospitalWiseExpenseList : System.Web.UI.Page
{
    private DataTable dtACC_Expense = new DataTable("dtACC_Expense");
    private dsACC_Expense objdsACC_Expense = new dsACC_Expense();

    #region 12.0 Page Load Event

    protected void Page_Load(object sender, EventArgs e)
    {
        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 12.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 12.1 DropDown List Fill Section


            #region 12.2 Set Default Value

            lblSearchHeader.Text = CV.SearchHeaderText;
            lblSearchResultHeader.Text = CV.SearchResultHeaderText;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            SetDefaultDateTime();

            #endregion 12.2 Set Default Value
            Search(1);

            #region 12.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }

    #endregion 12.0 Page Load Event

    #region 13.0 FillLabels

    private void FillLabels(String FormName)
    {
    }

    #endregion

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList

    private void FillDropDownList()
    {

    }

    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

    #region 15.0 Search

    #region 15.1 Button Search Click Event

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search(1);
    }

    #endregion 15.1 Button Search Click Event

    #region 15.2 Search Function

    private void Search(int PageNo)
    {

        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;

        #endregion Parameters




        #region Gather Data

        if (dtpFromDate.Text.Trim() != String.Empty)
            FromDate = Convert.ToDateTime(dtpFromDate.Text);

        if (dtpFromDate.Text.Trim() != String.Empty)
            ToDate = Convert.ToDateTime(dtpToDate.Text);


        #endregion Gather Data

        #region Validation

        if (FromDate > ToDate)
        {
            Div_SearchResult.Visible = false;
            Div_ExportOption.Visible = false;

            rpData.DataSource = null;
            rpData.DataBind();
            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
            ucMessage.ShowError("FromDate Must Be Less than ToDate");
            return;
        }

        #endregion

        ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();

        dtACC_Expense = balACC_Expense.PP_HospitalWiseExpenseList(FromDate, ToDate, HospitalID);


        if (dtACC_Expense != null && dtACC_Expense.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            Div_ExportOption.Visible = true;
            rpData.DataSource = dtACC_Expense;
            rpData.DataBind();

            lblRecordInfoBottom.Text = String.Empty;
            lblRecordInfoTop.Text = String.Empty;

        }
        else
        {

            rpData.DataSource = null;
            rpData.DataBind();
            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
        ShowReport();
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event


    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events

    #region ItemDataBound Event

    #endregion ItemDataBound Event



    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();
        #region Parameters

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        SqlInt32 HospitalID = SqlInt32.Null;

        #endregion Parameters

        #region Gather Data

        if (dtpFromDate.Text.Trim() != String.Empty)
            FromDate = Convert.ToDateTime(dtpFromDate.Text);

        if (dtpFromDate.Text.Trim() != String.Empty)
            ToDate = Convert.ToDateTime(dtpToDate.Text);


        #endregion Gather Data

        ACC_ExpenseBAL balACC_Expense = new ACC_ExpenseBAL();

        dtACC_Expense = balACC_Expense.PP_HospitalWiseExpenseList(FromDate, ToDate, HospitalID);
        if (dtACC_Expense != null && dtACC_Expense.Rows.Count > 0)
        {
            ExportReport(ExportType);
        }
    }

    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Microsoft.Reporting.WebForms.Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvExpense.LocalReport.Render(format,
                                                        null,
                                                        out mimeType,
                                                        out encoding,
                                                        out extension,
                                                        out streamIds,
                                                        out warnings);

            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("Content-Disposition", "attachment; filename=report." + extension);
            Response.BinaryWrite(bytes);
            Response.End();

        }
        catch (Exception ex)
        {
            ucMessage.ShowError(format + " is Not Correct Format");
        }

    }

    #endregion 19.1 Excel Export Button Click Event

    #endregion 19.0 Export Data

    #region 20.0 Cancel Button Event

    protected void btnClear_Click(object sender, EventArgs e)
    {
        ClearControls();
    }

    #endregion 20.0 Cancel Button Event



    #region 22.0 ClearControls

    private void ClearControls()
    {

        dtpFromDate.Text = String.Empty;
        dtpToDate.Text = String.Empty;

        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();
    }

    #endregion 22.0 ClearControls


    #region 23.0 SetDefaultDateTime
    private void SetDefaultDateTime()
    {
        DateTime dateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

        dtpFromDate.Text = dateTime.Date.ToString("dd-MM-yyyy");
        dtpToDate.Text = Convert.ToDateTime(dateTime).AddMonths(1).AddDays(-1).Date.ToString("dd-MM-yyyy");
    }
    #endregion SetDefaultDateTime



    #region REPORT

    #region ShowReport

    protected void ShowReport()
    {
        FillDataSet();
    }

    #endregion ShowReport 

    #region FillDataSet

    protected void FillDataSet()
    {
        foreach (DataRow dr in dtACC_Expense.Rows)
        {
            dsACC_Expense.dtACC_ExpenseRow drACC_Expense = objdsACC_Expense.dtACC_Expense.NewdtACC_ExpenseRow();

            if (!dr["ExpenseID"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseID = Convert.ToInt32(dr["ExpenseID"]);

            if (!dr["ExpenseType"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseType = Convert.ToString(dr["ExpenseType"]);

            if (!dr["Amount"].Equals(System.DBNull.Value))
                drACC_Expense.Amount = Convert.ToDecimal(dr["Amount"]);

            if (!dr["ExpenseDate"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseDate = Convert.ToDateTime(dr["ExpenseDate"]);

            if (!dr["Note"].Equals(System.DBNull.Value))
                drACC_Expense.Note = Convert.ToString(dr["Note"]);

            if (!dr["Hospital"].Equals(System.DBNull.Value))
                drACC_Expense.Hospital = Convert.ToString(dr["Hospital"]);

            if (!dr["FinYearName"].Equals(System.DBNull.Value))
                drACC_Expense.FinYearName = Convert.ToString(dr["FinYearName"]);

            if (!dr["Remarks"].Equals(System.DBNull.Value))
                drACC_Expense.Remarks = Convert.ToString(dr["Remarks"]);

            if (!dr["ExpenseTypeID"].Equals(System.DBNull.Value))
                drACC_Expense.ExpenseTypeID = Convert.ToInt32(dr["ExpenseTypeID"]);

            if (!dr["TagName"].Equals(System.DBNull.Value))
                drACC_Expense.TagName = Convert.ToString(dr["TagName"]);

            if (!dr["HospitalID"].Equals(System.DBNull.Value))
                drACC_Expense.HospitalID = Convert.ToInt32(dr["HospitalID"]);

            if (!dr["FinYearID"].Equals(System.DBNull.Value))
                drACC_Expense.FinYearID = Convert.ToInt32(dr["FinYearID"]);

            objdsACC_Expense.dtACC_Expense.Rows.Add(drACC_Expense);

        }

        SetReportParamater();
        this.rvExpense.LocalReport.DataSources.Clear();
        this.rvExpense.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Expense", (DataTable)objdsACC_Expense.dtACC_Expense));
        this.rvExpense.LocalReport.Refresh();
    }
    #endregion FillDataSet

    #region SetReportParamater
    protected void SetReportParamater()
    {
        String ReportTitle = "Hospital Wise Expense Report";
        DateTime PrintDate = DateTime.Now;
        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvExpense.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptPrintDate });

    }
    #endregion SetReportParamater 

    #endregion REPORT
}