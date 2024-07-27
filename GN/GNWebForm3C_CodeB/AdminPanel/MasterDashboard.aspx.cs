using GNForm3C;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using System.Data.SqlTypes;

public partial class AdminPanel_MasterDashboard : System.Web.UI.Page
{
    #region variable

    static Int32 PageRecordSize = CV.PageRecordSize;//Size of record per page

    #endregion variable

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.0 Check User Login

        if (!Page.IsPostBack)
        {
            #region 11.1 DropDown List Fill Section

            FillDropDownList();

            #endregion 11.1 DropDown List Fill Section

            #region 11.2 Set Default Value 
            lblSearchHeader.Text = CV.SearchHeaderText;

            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

            #endregion 11.2 Set Default Value 


            #region 11.3 Set Help Text
            ucHelp.ShowHelp("Help Text will be shown here");
            #endregion 12.3 Set Help Text
        }
    }


    #endregion 11.0 Page Load Event 

    #region 12.0 Search
    protected void Search(int page)
    {
        if (ddlHospitalID.SelectedIndex > 0)
        {
            upDashboard.Visible = true;
            BindIncome();
            BindExpense();

            MST_DSBBAL balMST_DSBBAL = new MST_DSBBAL();

            DataTable dtCount = balMST_DSBBAL.SelectCount((SqlInt32)(ddlHospitalID.SelectedIndex));

            lblIncomeCount.Text = string.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["IncomeCount"].ToString()));
            lblExpenseCount.Text = string.Format(GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint, Convert.ToDecimal(dtCount.Rows[0]["ExpenseCount"].ToString()));
            lblSubTreatmentCount.Text = dtCount.Rows[0]["SubTreatmentCount"].ToString();


            DataTable dtTreatmentSummary = balMST_DSBBAL.TreatmentSummaryList((SqlInt32)(ddlHospitalID.SelectedIndex));
            // Bind to Repeater
            if (dtTreatmentSummary.Rows.Count > 0)
            {
                rpTreatment.DataSource = dtTreatmentSummary;
                rpTreatment.DataBind();
                lblNoTreatmentSummaryRecords.Visible = false;
                TreatmentSummaryList.Visible = true;
            }

            else
            {
                lblNoTreatmentSummaryRecords.Visible = true;
                TreatmentSummaryList.Visible = false;
            }

        }

    }
    protected void displayChange(object sender, EventArgs e)
    {
        if (ddlHospitalID.SelectedIndex <= 0)
        {
            upDashboard.Visible = false;
        }
    }
    protected void btnShow_Click(object sender, EventArgs e)
    {
        //upDashboard.Visible = true;
        Search(1);

    }
    #endregion 12.0 Search

    #region 13.0 BindTable
    #region 13.1 BindIncome

    private void BindIncome()
    {
        #region Parameters

        // Get current year
        int currentYear = DateTime.Now.Year;
        SqlInt32 HospitalID = (SqlInt32)ddlHospitalID.SelectedIndex;
        SqlInt32 Year = (SqlInt32)currentYear;

        #endregion Parameters

        MST_DSBBAL balMST_DSBBAL = new MST_DSBBAL();
        DataTable result = balMST_DSBBAL.IncomeList(HospitalID, Year);

        if (result.Rows.Count > 0)
        {
            DataTable calenderDataTable = BindYearlyCalender();
            // Populate the income data into the DataTable

            foreach (DataRow incomeRow in result.Rows)
            {
                DateTime date = Convert.ToDateTime(incomeRow["IncomeDate"]);
                decimal amount = Convert.ToDecimal(incomeRow["Amount"].ToString());
                int day = date.Day;
                int month = date.Month;
                calenderDataTable.Rows[day - 1]["Month" + month] = amount;
            }

            // Bind to Repeater
            rpIncome.DataSource = calenderDataTable;
            rpIncome.DataBind();
            lblNoIncomeRecords.Visible = false;
            IncomeList.Visible = true;
        }
        else
        {
            lblNoIncomeRecords.Visible = true;
            IncomeList.Visible = false;

        }

    }
    #endregion 13.1 BindIncome
    #region 13.2 BindExpense
    private void BindExpense()
    {
        #region Parameters

        // Get current year
        int currentYear = DateTime.Now.Year;
        SqlInt32 HospitalID = (SqlInt32)ddlHospitalID.SelectedIndex;
        SqlInt32 Year = (SqlInt32)currentYear;

        #endregion Parameters

        MST_DSBBAL balMST_DSBBAL = new MST_DSBBAL();
        DataTable result = balMST_DSBBAL.ExpenseList(HospitalID, Year);
        if (result.Rows.Count > 0)
        {
            DataTable calenderDataTable = BindYearlyCalender();
            // Populate the income data into the DataTable
            foreach (DataRow dr in result.Rows)
            {
                DateTime date = Convert.ToDateTime(dr["ExpenseDate"]);
                decimal amount = Convert.ToDecimal(dr["Amount"].ToString());
                int day = date.Day;
                int month = date.Month;
                calenderDataTable.Rows[day - 1]["Month" + month] = amount;


            }

            // Bind to Repeater
            rpExpense.DataSource = calenderDataTable;
            rpExpense.DataBind();

            lblNoExpenseRecords.Visible = false;
            ExpenseList.Visible = true;
        }
        else
        {
            lblNoExpenseRecords.Visible = true;
            ExpenseList.Visible = false;
        }
    }

    #endregion 13.2 BindExpense

    #region 13.3 BindYearlyCalender
    private DataTable BindYearlyCalender()
    {
        // Create a DataTable to hold daily income data
        DataTable dt = new DataTable();
        dt.AcceptChanges();
        dt.Columns.Add("Day", typeof(int));

        for (int month = 1; month <= 12; month++)
        {
            dt.Columns.Add("Month" + month, typeof(decimal));
        }



        // Initialize rows for each day
        for (int day = 1; day <= 31; day++)
        {
            DataRow row = dt.NewRow();
            row["Day"] = day;

            // Initialize month columns with DBNull
            for (int month = 1; month <= 12; month++)
            {
                row["Month" + month] = 0;
            }

            dt.Rows.Add(row);
        }
        return dt;
    }
    #endregion 13.3 BindYearlyCalender

    #endregion BindTable

    #region 14.0 DropDownList

    #region 14.1 Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }
    #endregion 14.1 Fill DropDownList

    #endregion 14.0 DropDownList

}
