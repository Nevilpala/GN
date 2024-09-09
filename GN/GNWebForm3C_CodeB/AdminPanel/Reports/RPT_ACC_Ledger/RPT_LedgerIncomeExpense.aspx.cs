using GNForm3C.BAL;
using GNForm3C;
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

public partial class AdminPanel_Reports_RPT_ACC_Ledger_RPT_LedgerIncomeExpense : System.Web.UI.Page
{
    #region 11.0 Variables

    String FormName = "ACC_LedgerList";
    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page
    Int32 PageDisplaySize = CV.PageDisplaySize;
    Int32 DisplayIndex = CV.DisplayIndex;
    decimal totalAmount = 0;


    private DataTable dtACC_Ledger = new DataTable();
    private dsACC_IncomeExpense objdsACC_Ledger = new dsACC_IncomeExpense();
    #endregion 11.0 Variables

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
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
        CommonFillMethods.FillDropDownListFinYearID(ddlFinYearID);
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
        SqlInt32 HospitalID = SqlInt32.Null;
        SqlInt32 FinYearID = SqlInt32.Null;

        SqlDateTime FromDate = SqlDateTime.Null;
        SqlDateTime ToDate = SqlDateTime.Null;
        lblOpeningBalance.Text = "0";

        #endregion Parameters

        #region Gather Data

        if (ddlHospitalID.SelectedIndex > 0)
            HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

        if (ddlFinYearID.SelectedIndex > 0)
            FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);

        //if (dtpFromDate.Text.Trim() != String.Empty)
        //    FromDate = Convert.ToDateTime(dtpFromDate.Text.Trim());


        //if (dtpToDate.Text.Trim() != String.Empty)
        //    ToDate = Convert.ToDateTime(dtpToDate.Text.Trim());

        #endregion Gather Data

        ACC_ExpInm_LedgerBAL balACC_ExpInm_Ledger = new ACC_ExpInm_LedgerBAL();

        DataTable dt = balACC_ExpInm_Ledger.RPT_LedgerIncomeExpense(HospitalID, FinYearID, FromDate, ToDate);
 

        if (dt != null && dt.Rows.Count > 0)
        {
            Div_SearchResult.Visible = true;
            Div_ExportOption.Visible = true;
           

            if (!dt.Rows[0]["OpeningBalance"].Equals(DBNull.Value))
            {
                totalAmount = Convert.ToDecimal(dt.Rows[0]["OpeningBalance"]);
                lblOpeningBalance.Text = string.Format(CV.DefaultCurrencyFormatWithDecimalPoint, totalAmount);

            }


            lblRecordInfoBottom.Text = string.Empty;
            lblRecordInfoTop.Text = string.Empty;

            lbtnExportExcel.Visible = true;

            rpData.DataSource = dt;
            rpData.DataBind();

            lblTotalAmount.Text = string.Format(CV.DefaultCurrencyFormatWithDecimalPoint,totalAmount);

        }
        else
        {
            Div_SearchResult.Visible = false;
            lbtnExportExcel.Visible = false;


            rpData.DataSource = null;
            rpData.DataBind();

            lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
            lblRecordInfoTop.Text = CommonMessage.NoRecordFound();


            ucMessage.ShowError(CommonMessage.NoRecordFound());
        }
        ShowReport(dt);
    }

    #endregion 15.2 Search Function

    #endregion 15.0 Search

    #region 16.0 Repeater Events

    #region 16.1 Item Command Event

    protected void rpData_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
    protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        String ledgerTypes = Convert.ToString(DataBinder.Eval(e.Item.DataItem, "ACC_LedgerType"));
        decimal ledgerAmount = Convert.ToDecimal(DataBinder.Eval(e.Item.DataItem, "ACC_LedgerAmount"));
        Label lblBalance = e.Item.FindControl("lblBalance") as Label;


        if (ledgerTypes == "Income")
        {
            totalAmount += ledgerAmount;
        }
        else if (ledgerTypes == "Expence")
        {
            totalAmount -= ledgerAmount;
        }

         lblBalance.Text = string.Format(CV.DefaultCurrencyFormatWithDecimalPoint, totalAmount);

    }


    #endregion 16.1 Item Command Event

    #endregion 16.0 Repeater Events


    #region 18.0 Button Delete Click Event


    #endregion 18.0 Button Delete Click Event

    #region 19.0 Export Data

    #region 19.1 Excel Export Button Click Event

    protected void lbtnExport_Click(object sender, EventArgs e)
    {
        LinkButton lbtn = (LinkButton)(sender);
        String ExportType = lbtn.CommandArgument.ToString();

        ExportReport(ExportType);
    }


    private void ExportReport(string format)
    {
        try
        {
            string mimeType, encoding, extension;
            Warning[] warnings;
            string[] streamIds;

            byte[] bytes = rvIncomeExpenseList.LocalReport.Render(format,
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
        ddlHospitalID.SelectedIndex = 0;
        ddlFinYearID.SelectedIndex = 0;

        CommonFunctions.BindEmptyRepeater(rpData);
        Div_SearchResult.Visible = false;
        Div_ExportOption.Visible = false;
        lblRecordInfoBottom.Text = CommonMessage.NoRecordFound();
        lblRecordInfoTop.Text = CommonMessage.NoRecordFound();

        //dtpFromDate.Text = string.Empty;
        //dtpToDate.Text = string.Empty;


    }

    #endregion 22.0 ClearControls
 
    #region 21.0 Report

    #region 21.1 ShowReport
    protected void ShowReport(DataTable dt)
    {
        FillDataSet(dt);
    }

    #endregion 21.1 ShowReport 

    #region 21.2 FillDataSet
    protected void FillDataSet(DataTable dt)
    {
        foreach (DataRow dr in dt.Rows)
        {
            dsACC_IncomeExpense.dtACC_Ledger_IncomeExpenseRow drACC_Ledger = objdsACC_Ledger.dtACC_Ledger_IncomeExpense.NewdtACC_Ledger_IncomeExpenseRow();

            if (!dr["ACC_LedgerID"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerID = Convert.ToInt32(dr["ACC_LedgerID"]);

            if (!dr["ACC_LedgerType"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerType = Convert.ToString(dr["ACC_LedgerType"]);

            if (!dr["Particular"].Equals(System.DBNull.Value))
                drACC_Ledger.Particular = Convert.ToString(dr["Particular"]);

            if (!dr["ACC_LedgerAmount"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerAmount = Convert.ToDecimal(dr["ACC_LedgerAmount"]);

            if (!dr["ACC_LedgerDate"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerDate = Convert.ToDateTime(dr["ACC_LedgerDate"]);

            if (!dr["ACC_LedgerNote"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerNote = Convert.ToString(dr["ACC_LedgerNote"]);

            if (!dr["OpeningBalance"].Equals(System.DBNull.Value))
                drACC_Ledger.OpeningBalance = Convert.ToDecimal(dr["OpeningBalance"]);

            if (!dr["ACC_LedgerBalance"].Equals(System.DBNull.Value))
                drACC_Ledger.ACC_LedgerBalance = Convert.ToDecimal(dr["ACC_LedgerBalance"]);

            objdsACC_Ledger.dtACC_Ledger_IncomeExpense.Rows.Add(drACC_Ledger);

        }

        SetReportParamater();
        this.rvIncomeExpenseList.LocalReport.DataSources.Clear();
        this.rvIncomeExpenseList.LocalReport.DataSources.Add(new ReportDataSource("dtACC_Ledger", (DataTable)objdsACC_Ledger.dtACC_Ledger_IncomeExpense));
        this.rvIncomeExpenseList.LocalReport.Refresh();
    }
    #endregion 21.2 FillDataSet

    #region 21.3 SetReportParamater
    protected void SetReportParamater()
    {
        DateTime PrintDate = DateTime.Now;

        String ReportTitle = "Ledger Report";
        if (ddlHospitalID.SelectedIndex > 0)
            ReportTitle +=" - " +ddlHospitalID.SelectedItem + " Hospital";

        String ReportSubTitle = string.Empty;

        if (ddlFinYearID.SelectedIndex > 0)
            ReportSubTitle += ddlFinYearID.SelectedItem;
        else
            ReportSubTitle += "Report";

        ReportParameter rptReportTitle = new ReportParameter("ReportTitle", ReportTitle); 
        ReportParameter rptReportSubTitle = new ReportParameter("ReportSubTitle", ReportSubTitle);
        ReportParameter rptPrintDate = new ReportParameter("PrintDate", PrintDate.ToString());

        this.rvIncomeExpenseList.LocalReport.SetParameters(new ReportParameter[] { rptReportTitle, rptReportSubTitle, rptPrintDate });

    }
    #endregion 21.3 SetReportParamater 

    #endregion 21.0 REPORT
}