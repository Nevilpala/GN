using GNForm3C;
using GNForm3C.BAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_BranchIntake_MST_BranchIntakeMatrixAddEdit : System.Web.UI.Page
{

    public DataTable dtBranchIntake;
    string FormName = "Branch Intake";
    protected void Page_Load(object sender, EventArgs e)
    {

        #region 12.0 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 12.0 Check User Login

        if (!Page.IsPostBack)
        {
            BindData();

            lblSearchResultHeader.Text = FormName;
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;

        }

    }

    private void BindData()
    { 
            MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
            dtBranchIntake = balMST_BranchIntake.SelectShow(); 
            rpBranchIntake.DataSource = dtBranchIntake;
            rpBranchIntake.DataBind();
         

    }

    public string GetColumnHeaders()
    {
        if (dtBranchIntake == null || dtBranchIntake.Columns.Count == 0)
            return "";

        string headers = "";
        foreach (DataColumn column in dtBranchIntake.Columns)
        {
            if (column.ColumnName != "Branch")
            {
                headers += "<th class='text-center'>" + column.ColumnName + "</th>";
            }
        }
        return headers;
    }

    public string GetRowValues(object dataItem)
    {
        DataRowView row = (DataRowView)dataItem;
        string values = "";

        foreach (DataColumn column in row.Row.Table.Columns)
        {
            if (column.ColumnName != "Branch")
            {
                string cellHtml = "<td><asp:TextBox ID='txt" + column.ColumnName + "' runat='server' Text='" + row[column.ColumnName] + "' CssClass='form-control' EnableViewState='true' /></td>";
                values += cellHtml;
            }
        }

        return values;
    }

    protected void rpBranchIntake_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
       
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            // Bind data dynamically
            BindDynamicData(e);
        }
    }

    private void BindDynamicData(RepeaterItemEventArgs e)
    {
        // Get the DataRow for the current item
        DataRowView dataRowView = e.Item.DataItem as DataRowView;

        if (dataRowView != null)
        {
            // Find the row in the Repeater
            TableRow dataRow = new TableRow();
            DataTable dataTable = rpBranchIntake.DataSource as DataTable;
            if (dataTable != null)
            {
                foreach (DataColumn column in dataTable.Columns)
                {


                    //Label lblBranch = e.Item.FindControl("lblBranch") as Label;
                    //lblBranch.Text = dataRowView["Branch"].ToString();

                    TableCell dataCell = new TableCell();

                    if (column.ColumnName != "Branch")
                    {
                        
                        int intake = dataRowView[column.ColumnName] != DBNull.Value ? Convert.ToInt32(dataRowView[column.ColumnName]) : 0;

                        // Create a TextBox for editable fields, or display data directly
                        TextBox txtDynamic = new TextBox
                        {
                            ID = "txt" + column.ColumnName + "_" + e.Item.ItemIndex,
                            Text = intake.ToString(),
                            CssClass = "form-control"

                        };
                        dataCell.Controls.Add(txtDynamic);

                    }
                    else
                    {
                        Label txtDynamic = new Label
                        {
                            ID = "lblBranch" + "_" + e.Item.ItemIndex,
                            Text = dataRowView[column.ColumnName].ToString(),
                            CssClass = "form-control" 
                        };
                        dataCell.Controls.Add(txtDynamic);
                    }
                    dataRow.Cells.Add(dataCell);

                }

                // Add the TableRow to the current Repeater item
                e.Item.Controls.Add(dataRow);
            }
        }

    }


    protected void btnSave_Click(object sender, EventArgs e)
    {  
        if (Page.IsValid)
        {
            try
            {
                MST_BranchIntakeBAL balMST_BranchIntake = new MST_BranchIntakeBAL();
                MST_BranchIntakeENT entMST_BranchIntake = new MST_BranchIntakeENT();

                #region 15.1 Validate Fields 

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 

                foreach (RepeaterItem items in rpBranchIntake.Items)
                {
                    if (items.ItemType == ListItemType.Item || items.ItemType == ListItemType.AlternatingItem)
                    {
                        string branchtext = "lblBranch" + "_" + items.ItemIndex;
                        Label BranchLabel = items.FindControl(branchtext) as Label;
                         

                        if (BranchLabel != null)
                        { 
                            DataRow row = dtBranchIntake.Rows[items.ItemIndex];

                            foreach (DataColumn column in dtBranchIntake.Columns)
                            {

                                if (column.ColumnName != "Branch" && row[column.ColumnName] != DBNull.Value)
                                {
                                    TextBox textBox = items.FindControl("txt" + column.ColumnName + "_" + items.ItemIndex) as TextBox;

                                    if (textBox != null)
                                    {
                                        string value = textBox.Text;
                                        // Update the DataRow with the new value from the TextBox
                                        //row[column.ColumnName] = textBox.Text.Trim();
                                    }
                                }
                            }

                        }

                    }



                } 

                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 


                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }


}