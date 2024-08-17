<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="RPT_HospitalWiseIncomeTypeWiseData.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_Income_RPT_HospitalWiseIncomeTypeWiseData" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
    <rsweb:reportviewer id="rvIncome" runat="server" width="100%" height="700px">
        <localreport reportpath="AdminPanel\Reports\RPT_ACC_Income\RPT_HospitalWiseIncomeTypeWiseData.rdlc"></localreport>
    </rsweb:reportviewer>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

