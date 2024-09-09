<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_LedgerIncomeExpense.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_Ledger_RPT_LedgerIncomeExpense" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Account"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Account Ledger"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income/Expence Ledger"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <rsweb:ReportViewer ID="rvIncomeExpenseList" runat="server" Width="100%" Height="600px" Visible="false">
        <LocalReport ReportPath="AdminPanel\Reports\RPT_ACC_Ledger\RPT_LedgerIncomeExpense.rdlc"></LocalReport>
    </rsweb:ReportViewer>
    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblSearchHeaderIcon" runat="server"></asp:Label>
                        <asp:Label ID="lblSearchHeader" SkinID="lblSearchHeaderText" runat="server"></asp:Label>
                    </div>
                    <div class="tools">
                        <a href="javascript:;" class="collapse pull-right"></a>
                    </div>
                </div>
                <div class="portlet-body form">
                    <div role="form">
                        <div class="form-body">

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:DropDownList ID="ddlFinYearID" CssClass="form-control select2me" runat="server"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <%-- <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpFromDate" CssClass="form-control" runat="server" placeholder="From Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="input-group date date-picker" data-date-format="dd-mm-yyyy">
                                            <span class="input-group-btn">
                                                <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                            </span>
                                            <asp:TextBox ID="dtpToDate" CssClass="form-control" runat="server" placeholder="To Date"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Show" OnClick="btnSearch_Click" />
                                    <asp:Button ID="btnClear" runat="server" SkinID="btnClear" Text="Clear" OnClick="btnClear_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>

    <%-- List --%>
    <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <!-- BEGIN EXAMPLE TABLE PORTLET-->
                    <div class="portlet light">
                        <div class="portlet-title">
                            <div class="caption">
                                <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                <label class="control-label">&nbsp;</label>
                                <label class="control-label pull-right">
                                    <asp:Label ID="lblRecordInfoTop" Text="No entries found" CssClass="pull-right" runat="server"></asp:Label>
                                </label>
                            </div>
                            <div class="tools">
                                <div>
                                    <%--<asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Account/ACC_Expense/ACC_ExpenseAddEdit.aspx" runat="server"></asp:HyperLink>--%>
                                    <div class="btn-group" runat="server" id="Div_ExportOption" visible="false">
                                        <button class="btn dropdown-toggle" data-toggle="dropdown">
                                            Export <i class="fa fa-angle-down"></i>
                                        </button>
                                        <ul class="dropdown-menu pull-right">
                                            <li>
                                                <asp:LinkButton ID="lbtnExportPDF" runat="server" CommandArgument="PDF" OnClick="lbtnExport_Click">PDF</asp:LinkButton>
                                            </li>
                                            <li>
                                                <asp:LinkButton ID="lbtnExportExcel" runat="server" CommandArgument="Excel" OnClick="lbtnExport_Click">Excel</asp:LinkButton>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row" runat="server" id="Div_SearchResult" visible="false">
                                <div class="col-md-12">
                                    <div id="TableContent">
                                        <table class="table table-bordered table-advanced " id="sample_1" >
                                            <%-- Table Header --%>
                                            <thead>

                                                <tr class="TRDark" >
                                                    <th class="text-center align-middle" rowspan="2" style="vertical-align:middle;">
                                                        <asp:Label ID="lbhDate" runat="server" Text="Date "></asp:Label>

                                                    </th>
                                                    <th class="text-center" colspan="2">
                                                        <asp:Label ID="lbhParticular" runat="server" Text="Particular"></asp:Label>
                                                    </th> 
                                                    <th class="text-right" rowspan="2"  style="vertical-align:middle;">
                                                        <asp:Label ID="lbhAmount" runat="server" Text="Balance"></asp:Label>

                                                    </th>

                                                </tr>
                                                <tr class="TRDark"> 
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhIncome" runat="server" Text="Income"></asp:Label>
                                                    </th>
                                                    <th class="text-center">
                                                        <asp:Label ID="lbhExpense" runat="server" Text="Expense"></asp:Label>
                                                    </th> 
                                                </tr>
                                            </thead>
                                            <%-- END Table Header --%>

                                            <tbody>
                                                <tr class="">
                                                    <th class="text-right" colspan="3">Opening Balance  
                                                    </th>
                                                    <th class="text-right">
                                                        <asp:Label ID="lblOpeningBalance" runat="server" Text="0"></asp:Label>
                                                    </th>

                                                </tr>
                                                <asp:Repeater ID="rpData" runat="server" OnItemCommand="rpData_ItemCommand" OnItemDataBound="rpData_ItemDataBound">
                                                    <ItemTemplate>
                                                        <%-- Table Rows --%>
                                                        <tr id="trRow" class="odd gradeX">
                                                            <td class="text-center">
                                                                <strong><%#Convert.ToDateTime(Eval("ACC_LedgerDate")).ToString(GNForm3C.CV.DefaultDateFormat) %></strong>
                                                            </td>
                                                            <%-- <td class="text-center">
                                                                <%#Eval("ACC_LedgerType") %>
                                                            </td>--%>
                                                            <td class="text-center">
                                                                <%#Eval("ACC_LedgerType").ToString() == "Income" ?"<strong>"+ Eval("Particular").ToString()+ "</strong><br />(" +Eval("ACC_LedgerAmount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPointCulture)+ ")" : "" %>
                                                            </td>

                                                            <td class="text-center">
                                                                <%#Eval("ACC_LedgerType").ToString() != "Income" ? "<strong>"+Eval("Particular").ToString() + "</strong><br />(" +Eval("ACC_LedgerAmount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPointCulture)+ ")": "" %>
                                                            </td>

                                                            <td class="text-right" style='<%# Eval("ACC_LedgerType").ToString() == "Income" ? "background-color: lightgreen;": "background-color: lightcoral;" %>'>
                                                                <asp:Label ID="lblBalance" runat="server" Text="0"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <%-- END Table Rows --%>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                                <tr>
                                                    <th colspan="3" class="text-right">Closing Balance
                                                    </th>
                                                    <th class="text-right">
                                                        <asp:Label ID="lblTotalAmount" runat="server" />
                                                    </th>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>

                                    <%-- Pagination --%>
                                    <div class="row">
                                        <div class="col-md-4">
                                            <label class="control-label">
                                                <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label>

                                            </label>
                                        </div>
                                    </div>
                                    <div class="row">
                                    </div>
                                    <%-- END Pagination --%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END EXAMPLE TABLE PORTLET-->
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSearch" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />
            <asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />
        </Triggers>
    </asp:UpdatePanel>
    <%-- END List --%>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text=" Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>

     <%--   $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });--%>

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);

    </script>
</asp:Content>
