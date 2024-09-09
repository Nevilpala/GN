<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_DataTree_Hospital.aspx.cs" Inherits="AdminPanel_Master_DataTree_MST_DataTree_Hospital" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" runat="server" Text="Hospital"></asp:Label>
    <small>
        <asp:Label ID="lblPageHeaderInfo_XXXXX" runat="server" Text="Master"></asp:Label></small>
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
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Hospital"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>

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
                                            <asp:TextBox ID="txtHospital" CssClass="First form-control" runat="server" PlaceHolder="Enter Hospital"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintName" CssClass="form-control" runat="server" PlaceHolder="Enter Print Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine1" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line1"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine2" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line2"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtPrintLine3" CssClass="form-control" runat="server" PlaceHolder="Enter Print Line3"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtFooterName" CssClass="form-control" runat="server" PlaceHolder="Enter Footer Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <div class="input-group">
                                            <span class="input-group-addon">
                                                <i class="fa fa-search"></i>
                                            </span>
                                            <asp:TextBox ID="txtReportHeaderName" CssClass="form-control" runat="server" PlaceHolder="Enter Report Header Name"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <div class="row">
                                <div class="col-md-9">
                                    <asp:Button ID="btnSearch" SkinID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
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
                                    <asp:HyperLink SkinID="hlAddNew" ID="hlAddNew" NavigateUrl="~/AdminPanel/Master/MST_Hospital/MST_HospitalAddEdit.aspx" runat="server"></asp:HyperLink>
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
                                        <div class="" id="HospitalDetail">
                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                <%-- Table Header --%>
                                                <thead>
                                                    <tr class="TRDark">
                                                        <th class="text-center">
                                                            <asp:Label ID="Label1" runat="server" Text="#"></asp:Label>
                                                        </th>
                                                        <th>
                                                            <asp:Label ID="lbhHospital" runat="server" Text="Hospital"></asp:Label>
                                                        </th>
                                                        <th>
                                                            <asp:Label ID="lbhPrintName" runat="server" Text="Print Name"></asp:Label>
                                                        </th>

                                                        <th>
                                                            <asp:Label ID="lbhFooterName" runat="server" Text="Footer Name"></asp:Label>
                                                        </th>
                                                        <th>
                                                            <asp:Label ID="lbhReportHeaderName" runat="server" Text="Report Header Name"></asp:Label>
                                                        </th>
                                                        <th>
                                                            <asp:Label ID="lblCount" runat="server" Text="ExpenseType Count"></asp:Label>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <%-- END Table Header --%>

                                                <tbody>
                                                    <asp:Repeater ID="rptHospitals" runat="server" OnItemDataBound="rptHospitals_OnItemDataBound" OnItemCommand="rptHospitals_ItemCommand">
                                                        <ItemTemplate>
                                                            <%-- Table Rows --%>
                                                            <tr class="odd gradeX">
                                                                <td class="text-center" style="width: 5%;">
                                                                    <i
                                                                        class="collapse-icon fa fa-plus-circle text-info"
                                                                        data-toggle="collapse"
                                                                        data-target="subFinYear<%# Container.ItemIndex %>"
                                                                        aria-expanded="false"></i>
                                                                </td>
                                                                <td>
                                                                    <asp:HyperLink ID="hlViewHospitalID" NavigateUrl='<%# "~/AdminPanel/Master/MST_Hospital/MST_HospitalView.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("HospitalID").ToString()) %>' data-target="#viewiFrameReg" CssClass="modalButton" data-toggle="modal" runat="server"><%#Eval("Hospital") %></asp:HyperLink>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("PrintName") %>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("FooterName") %>
                                                                </td>
                                                                <td>
                                                                    <%#Eval("ReportHeaderName") %>
                                                                </td>
                                                                <td class="text-center">
                                                                    <asp:HyperLink ID="hlExpCount" SkinID="hlGreen_Grid" NavigateUrl='<%# "~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeList.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("HospitalID").ToString()) %>' Text='<%#Eval("ExpenseTypeCount") %>' runat="server"></asp:HyperLink>
                                                                    <asp:HyperLink ID="hlExpCountEdit" SkinID="Edit" NavigateUrl='<%# "~/AdminPanel/Master/MST_ExpenseType/MST_ExpenseTypeAddEditMany.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(Eval("HospitalID").ToString()) %>' runat="server"></asp:HyperLink>
                                                                </td>

                                                            </tr>
                                                            <%-- END Table Rows --%>

                                                            <tr id="subFinYear<%# Container.ItemIndex %>" class="collapse">
                                                                <td></td>
                                                                <td colspan="5">
                                                                    <asp:HiddenField ID="hfhospitalID" runat="server" Value='<%# Eval("HospitalID") %>' />
                                                                    <asp:Panel ID="pnlFinYear" runat="server">

                                                                        <div id="divFinYear<%# Container.ItemIndex %>">
                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                <thead>
                                                                                    <tr class="TRDark">
                                                                                        <th class="text-center" scope="col" style="width: 5%;">#</th>
                                                                                        <th scope="col">FinYear</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <tbody>

                                                                                    <asp:Repeater ID="rptFinYears" runat="server" OnItemDataBound="rptFinYears_OnItemDataBound">
                                                                                        <ItemTemplate>
                                                                                            <%-- Table Rows --%>
                                                                                            <tr class="odd gradeX">
                                                                                                <td class="text-center">
                                                                                                    <i
                                                                                                        class="collapse-icon fa fa-plus-circle text-info"
                                                                                                        data-toggle="collapse"
                                                                                                        data-target='subMonth<%# Container.ItemIndex %>'
                                                                                                        aria-expanded="false"
                                                                                                        aria-controls='subMonth<%# Container.ItemIndex %>'></i>
                                                                                                </td>
                                                                                                <td>
                                                                                                    <%# Eval("FinYearName") %> 
                                                                                                </td>
                                                                                            </tr>
                                                                                            <%-- END Table Rows --%>

                                                                                            <tr id='subMonth<%# Container.ItemIndex %>' class="panel-collapse collapse" data-parent="#HospitalDetail">
                                                                                                <td></td>
                                                                                                <td>
                                                                                                    <asp:HiddenField ID="hfHospitalID" runat="server" />
                                                                                                    <asp:HiddenField ID="hfFinYearID" runat="server" Value='<%# Eval("FinYearID") %>' />
                                                                                                    <asp:Panel ID="pnlMonth" runat="server">

                                                                                                        <div id="divMonth<%# Container.ItemIndex %>">
                                                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample_1">
                                                                                                                <thead>
                                                                                                                    <tr class="TRDark">
                                                                                                                        <th class="text-center" scope="col" style="width: 5%;">#</th>
                                                                                                                        <th scope="col">Month</th>
                                                                                                                    </tr>
                                                                                                                </thead>
                                                                                                                <tbody>

                                                                                                                    <asp:Repeater ID="rptMonth" runat="server" OnItemDataBound="rptMonth_OnItemDataBound">
                                                                                                                        <ItemTemplate>
                                                                                                                            <%-- Table Rows --%>
                                                                                                                            <tr class="odd gradeX">
                                                                                                                                <td class="text-center">
                                                                                                                                    <i
                                                                                                                                        class="collapse-icon fa fa-plus-circle text-info"
                                                                                                                                        data-toggle="collapse"
                                                                                                                                        data-target="#subIncome<%# Container.ItemIndex %>"
                                                                                                                                        aria-expanded="false"
                                                                                                                                        aria-controls="subIncome<%# Container.ItemIndex %>"></i>
                                                                                                                                </td>
                                                                                                                                <td>
                                                                                                                                    <%# Eval("MonthYear") %> 
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                            <%-- END Table Rows --%>

                                                                                                                            <tr id="subIncome<%# Container.ItemIndex %>" class="panel-collapse collapse" data-parent="#HospitalDetail">
                                                                                                                                <td></td>
                                                                                                                                <td>
                                                                                                                                    <asp:HiddenField ID="hfHospitalID" runat="server" />
                                                                                                                                    <asp:HiddenField ID="hfFinYearID" runat="server" />
                                                                                                                                    <asp:HiddenField ID="hfDate" runat="server" Value='<%# Eval("Date") %>' />
                                                                                                                                    <asp:Panel ID="pnlMonth" runat="server">

                                                                                                                                        <div id="divMonth<%# Container.ItemIndex %>">
                                                                                                                                        </div>
                                                                                                                                    </asp:Panel>
                                                                                                                                </td>
                                                                                                                            </tr>
                                                                                                                        </ItemTemplate>
                                                                                                                    </asp:Repeater>
                                                                                                                </tbody>


                                                                                                            </table>
                                                                                                        </div>
                                                                                                    </asp:Panel>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </tbody>


                                                                            </table>
                                                                        </div>

                                                                    </asp:Panel>

                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                        </div>

                                        <%-- Pagination --%>
                                        <div class="row">
                                            <div class="col-md-4">
                                                <label class="control-label">
                                                    <asp:Label ID="lblRecordInfoBottom" Text="No entries found" runat="server"></asp:Label></label>
                                            </div>
                                            <div class="col-md-5">
                                                <div class="dataTables_paginate paging_simple_numbers" runat="server" id="Div_Pagination">
                                                    <ul class="pagination">
                                                        <li class="paginate_button previous disabled" id="liFirstPage" runat="server">
                                                            <asp:LinkButton ID="lbtnFirstPage" Enabled="false" OnClick="PageChange_Click" CommandName="FirstPage" CommandArgument="1" runat="server"><i class="fa fa-angle-double-left"></i></asp:LinkButton></li>
                                                        <li class="paginate_button previous disabled" id="liPrevious" runat="server">
                                                            <asp:LinkButton ID="lbtnPrevious" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="PreviousPage" runat="server"><i class="fa fa-angle-left"></i></asp:LinkButton></li>
                                                        <asp:Repeater ID="rpPagination" runat="server" OnItemDataBound="rpPagination_ItemDataBound">
                                                            <ItemTemplate>
                                                                <li>
                                                                    <li class="paginate_button" id="liPageNo" runat="server">
                                                                        <asp:LinkButton ID="lbtnPageNo" runat="server" OnClick="PageChange_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "PageNo")%>' CommandName="PageNo"><%# DataBinder.Eval(Container.DataItem, "PageNo")%></asp:LinkButton></li>
                                                                </li>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <li class="paginate_button next disabled" id="liNext" runat="server">
                                                            <asp:LinkButton ID="lbtnNext" Enabled="false" OnClick="PageChange_Click" CommandArgument="1" CommandName="NextPage" runat="server"><i class="fa fa-angle-right"></i></asp:LinkButton></li>
                                                        <li class="paginate_button previous disabled" id="liLastPage" runat="server">
                                                            <asp:LinkButton ID="lbtnLastPage" Enabled="false" OnClick="PageChange_Click" CommandName="LastPage" CommandArgument="-99" runat="server"><i class="fa fa-angle-double-right"></i></asp:LinkButton></li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <div class="col-md-3 pull-right">
                                                <div class="btn-group" runat="server" id="Div_GoToPageNo">
                                                    <asp:TextBox ID="txtPageNo" placeholder="Page No" onkeypress="return IsNumeric(event)" runat="server" CssClass="pagination-panel-input form-control input-xsmall input-inline col-md-4" MaxLength="9"></asp:TextBox>
                                                    <asp:LinkButton ID="lbtnGoToPageNo" runat="server" CssClass="btn btn-default input-inline col-md-4" CommandName="GoPageNo" CommandArgument="0" OnClick="PageChange_Click">Go</asp:LinkButton>
                                                </div>
                                                <div class="btn-group pull-right" runat="server" id="Div_PageSize">
                                                    <label class="control-label">Page Size</label>
                                                    <asp:DropDownList ID="ddlPageSizeBottom" AutoPostBack="true" CssClass="form-control input-xsmall" runat="server" OnSelectedIndexChanged="ddlPageSizeBottom_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                </div>
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

        $(window).keydown(function (e) {
            GNWebKeyEvents(e.keyCode, '<%=hlAddNew.ClientID%>', '<%=btnSearch.ClientID%>');
        });

        SearchGridUI('<%=btnSearch.ClientID%>', 'sample_1', 1);

        //$(document).ready(function () {
        //    // Toggle the icon on collapse/expand
        //    $('.collapse').on('show.bs.collapse', function () {
        //        console.log("collaspe");
        //        $(this).prev('tr').find('.collapse-icon').removeClass('fa-plus-circle').addClass('fa-minus-circle');
        //    }).on('hide.bs.collapse', function () {
        //        console.log("hide");
        //        $(this).prev('tr').find('.collapse-icon').removeClass('fa-minus-circle').addClass('fa-plus-circle');
        //    });
        //});
        $(document).ready(function () {
            // Function to handle collapse toggle
            function handleCollapseToggle() {
                // Get all LinkButtons with the specific class
                $('.link-collaspe').each(function () {
                    // Use jQuery's on method for event handling
                    $(this).on('click', function (event) {
                        // Prevent the default behavior
                        event.preventDefault();

                        // Get the target element ID from data attribute
                        var targetId = $(this).data('target');
                        var target = $(targetId);

                        // Toggle the collapse
                        if (target.length) {
                            target.collapse('toggle');
                        }

                        // Trigger the server-side event
                        __doPostBack($(this).attr('id'), $(this).attr('data-commandargument'));
                    });
                });
            }

            // Call the function to handle collapse
            handleCollapseToggle();
        });
    </script>
</asp:Content>

