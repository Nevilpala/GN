<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPageView.master" AutoEventWireup="true" CodeFile="MST_FinYearAddEditPopup.aspx.cs" Inherits="AdminPanel_Master_MST_FinYear_MST_FinYearAddEditPopup" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="upMST_FinYear" runat="server" UpdateMode="Conditional" EnableViedwState="true">
        <triggers>
            <asp:AsyncPostBackTrigger ControlID="btnSaveModel" EventName="Click" />
        </triggers>
        <contenttemplate>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                    <div class="tools">
                        <asp:HyperLink ID="CloseButton" SkinID="hlClosemymodal" runat="server" ClientIDMode="Static"></asp:HyperLink>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <ucMessage:ShowMessage ID="ucMessage1" runat="server" />
                        <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblFinYearName_XXXXX" runat="server" Text="Fin Year Name"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtModelFinYearName" ValidationGroup="vgFinYear" CssClass="form-control" runat="server" PlaceHolder="Enter Fin Year Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvFinYearName" SetFocusOnError="True" Display="Dynamic" runat="server" ValidationGroup="vgFinYear" ControlToValidate="txtModelFinYearName" ErrorMessage="Enter Fin Year Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblFromDate_XXXXX" runat="server" Text="From Date"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpModelFromDate" CssClass="form-control" runat="server" placeholder="From Date" ValidationGroup="vgFinYear"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" ValidationGroup="vgFinYear" ControlToValidate="dtpModelFromDate" ErrorMessage="Enter From Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblToDate_XXXXX" runat="server" Text="To Date"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpModelToDate" CssClass="form-control" runat="server" placeholder="To Date" ValidationGroup="vgFinYear"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvToDate" runat="server" ValidationGroup="vgFinYear" ControlToValidate="dtpModelToDate" ErrorMessage="Enter To Date" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <asp:Label ID="lblRemarks_XXXXX" runat="server" Text="Remarks"></asp:Label>
                                </label>
                                <div class="col-md-6">
                                    <asp:TextBox ID="txtModelRemarks" CssClass="form-control" runat="server" TextMode="MultiLine" PlaceHolder="Enter Remarks"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-offset-3 col-md-9">
                                    <asp:Button ID="btnSaveModel" runat="server" SkinID="btnSave" OnClick="btnSaveModel_Click" ValidationGroup="vgFinYear" />
                                    <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_FinYear/MST_FinYearList.aspx"></asp:HyperLink>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </contenttemplate>
    </asp:UpdatePanel>
     
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
    <script>
        $(document).keyup(function (e) {
            if (e.keyCode == 27) {
                $("#CloseButton").trigger("click");
            }
        });
    </script>
    <script>

</script>
</asp:Content>
