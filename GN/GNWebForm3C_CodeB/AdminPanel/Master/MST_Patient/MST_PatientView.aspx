<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageViewIFrame.master" AutoEventWireup="true" CodeFile="MST_PatientView.aspx.cs" Inherits="AdminPanel_Master_MST_Patient_MST_PatientView" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!-- BEGIN SAMPLE ' PORTLET-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <div class="portlet light">
        <div class="portlet-title">
            <div class="caption">
                <%--  <asp:Label SkinID="lblViewFormHeaderIcon" ID="lblViewFormHeaderIcon" runat="server"></asp:Label>
                <span class="caption-subject font-green-sharp bold uppercase">Income Type</span>--%>
            </div>
            <div class="tools">
                <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
            </div>
        </div>

        <ucPatient:ShowPatient ID="ucPatient" runat="server" />

    </div>

    <!-- END SAMPLE FORM PORTLET-->
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                ;
                $("#CloseButton").trigger("click");
            }
        });
    </script>
</asp:Content>
