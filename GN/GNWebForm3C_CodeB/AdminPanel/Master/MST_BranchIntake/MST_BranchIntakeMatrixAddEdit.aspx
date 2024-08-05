<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_BranchIntakeMatrixAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_BranchIntake_MST_BranchIntakeMatrixAddEdit" %>

<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="BranchIntake " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>
        </small>
    </span>
</asp:Content>
<asp:Content ID="cntBreadcrumb" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
    <li>
        <i class="fa fa-home"></i>
        <asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/AdminPanel/Default.aspx" Text="Home"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li>
        <asp:HyperLink ID="hlExpenseType" runat="server" NavigateUrl="~/AdminPanel/Master/MST_BranchIntake/MST_BranchIntakeList.aspx" Text="BranchIntake List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Branch Intake Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_BranchIntake" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">

        <ContentTemplate>

            <asp:UpdatePanel ID="upList" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ShowMessage" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                            <div class="portlet light" runat="server" id="Div_ShowResult">
                                <div class="portlet-title">
                                    <div class="caption">
                                        <asp:Label SkinID="lblSearchResultHeaderIcon" runat="server"></asp:Label>
                                        <asp:Label ID="lblSearchResultHeader" SkinID="lblSearchResultHeaderText" runat="server"></asp:Label>
                                        <label class="control-label">&nbsp;</label>
                                    </div>

                                </div>

                                <div class="portlet-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                                            <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                                        </div>
                                    </div>
                                    <div class="row" runat="server">
                                        <div class="col-md-12">
                                            <div id="TableContent">

                                                <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                    <%-- Table Header --%>
                                                    <asp:Repeater ID="rpBranchIntake" runat="server" OnItemDataBound="rpBranchIntake_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <thead>
                                                                <tr class="TRDark">
                                                                    <th class="text-center">Branch</th>
                                                                    <%# GetColumnHeaders() %>
                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                        </HeaderTemplate>
                                                        <ItemTemplate> 
                                                           <%-- <tr>
                                                                <td>
                                                                    <asp:Label ID="lblBranch" runat="server" CssClass="form-control" Text='<%# Eval("Branch") %>' />
                                                                </td>
                                                                            <asp:PlaceHolder ID="phTextBoxes" runat="server"></asp:PlaceHolder>

                                                                <%--<%# GetRowValues(Container.DataItem) %>--%>
                                                          
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </tbody>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </div>
                                        </div>
                                        <div clasa="col-md-12">
                                            <div class="form-actions">
                                                <div class="row">
                                                    <div class="col-md-offset-3 col-md-9">
                                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx"></asp:HyperLink>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- Loading  --%>
    <asp:UpdateProgress ID="upr" runat="server">
        <ProgressTemplate>
            <div class="divWaiting">
                <asp:Label ID="lblWait" runat="server" Text="Please wait... " />
                <asp:Image ID="imgWait" runat="server" SkinID="UpdatePanelLoding" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <%-- END Loading  --%>
</asp:Content>

