<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_FinYearWiseHospitalWiseIncomeExpenseMatrix.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_Ledger_RPT_FinYearWiseHospitalWiseIncomeExpenseMatrix" %>
 
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Income"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Account"></asp:Label></small>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Income/Expense"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" Runat="Server">
    <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
     <rsweb:ReportViewer ID="rvIncomeExpenseList" runat="server" Width="100%" Height="600px">
           <LocalReport ReportPath="AdminPanel\Reports\RPT_ACC_Ledger\RPT_FinYearWiseHospitalWiseIncomeExpenseMatrix.rdlc"></LocalReport>
     </rsweb:ReportViewer>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" Runat="Server">
</asp:Content>