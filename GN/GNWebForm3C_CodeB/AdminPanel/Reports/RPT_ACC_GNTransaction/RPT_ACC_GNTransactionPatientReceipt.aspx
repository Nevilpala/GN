<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="RPT_ACC_GNTransactionPatientReceipt.aspx.cs" Inherits="AdminPanel_Reports_RPT_ACC_GNTransaction_RPT_ACC_GNTransactionPatientReceipt" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845DCD8080CC91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

 
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="scm" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvPatientReceipt" runat="server" Width="100%" Height="700px" >
                <LocalReport ReportPath="AdminPanel\Reports\RPT_ACC_GNTransaction\RPT_ACC_GNTransactionPatientReceipt.rdlc"></LocalReport>
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>


