<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MasterDashboard.aspx.cs" Inherits="AdminPanel_MasterDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Master Dashboard" runat="server"></asp:Label>
    <span class="pull-right">
        <small>
            <asp:HyperLink ID="hlShowHelp" SkinID="hlShowHelp" runat="server"></asp:HyperLink>2
        </small>
    </span>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBreadcrumb" runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphPageContent" runat="Server">
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <%-- Search --%>
    <asp:UpdatePanel ID="upApplicationFeature" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ShowMessage1" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

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
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblHospitalID_XXXXX" runat="server" Text="Hospital"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:DropDownList ID="ddlHospitalID" CssClass="form-control select2me" runat="server" AutoPostBack="true" OnSelectedIndexChanged="displayChange"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvHospitalID" SetFocusOnError="True" runat="server" Display="Dynamic" ControlToValidate="ddlHospitalID" ErrorMessage="Select Hospital" InitialValue="-99"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnShow" runat="server" SkinID="btnShow" OnClick="btnShow_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%-- End Search --%>
    <%-- Dashboard --%>
    <asp:UpdatePanel ID="Dashboard" runat="server">
        <ContentTemplate>
            <asp:UpdatePanel ID="upDashboard" runat="server" UpdateMode="Conditional" Visible="false" ChildrenAsTriggers="false">
                <ContentTemplate>
                    <div class="row">
                        <div class="col-md-12">
                            <ucMessage:ShowMessage ID="ucMessage" runat="server" ViewStateMode="Disabled" />
                        </div>
                    </div>
                    <div class="row" id="displayContent" runat="server">
                        <div class="col-md-12">

                            <asp:UpdatePanel ID="upCount" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet light">
                                        <div class="portlet-title">
                                            <div class="caption font-green">
                                                <i class="fa fa-line-chart font-green"></i>
                                                <span class="caption-subject bold uppercase">Total Overview</span>
                                            </div>
                                            <div class="tools"></div>
                                        </div>
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">

                                                            <a class="dashboard-stat dashboard-stat-v2 blue" href='<%= "Account/ACC_Income/ACC_IncomeList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>

                                                                <%--<a class="dashboard-stat dashboard-stat-v2 blue" href='<%# "~/AdminPanel/Account/ACC_Income/ACC_IncomeList.aspx?HospitalID=" + GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString()) %>'>--%>
                                                                <div class="visual">
                                                                    <i class="fa fa-comments"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblIncomeCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Incomes </div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 red" href='<%= "Account/ACC_Expense/ACC_ExpenseList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-list"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblExpenseCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Expenses</div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                                                            <a class="dashboard-stat dashboard-stat-v2 green" href='<%= "Master/MST_SubTreatment/MST_SubTreatmentList.aspx?HospitalID="+ GNForm3C.CommonFunctions.EncryptBase64(ddlHospitalID.SelectedValue.ToString())%>'>
                                                                <div class="visual">
                                                                    <i class="fa fa-shopping-cart"></i>
                                                                </div>
                                                                <div class="details">
                                                                    <div class="number">
                                                                        <asp:Label runat="server" ID="lblSubTreatmentCount"></asp:Label>
                                                                    </div>
                                                                    <div class="desc">Sub Treatments </div>
                                                                </div>
                                                            </a>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="UpList" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
                                <ContentTemplate>
                                    <div class="portlet">
                                        <div class="portlet-body form">
                                            <div class="form-horizontal" role="form">
                                                <div class="form-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box blue">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>INCOMES
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                        <%--<a href="Account/ACC_Income/ACC_IncomeList.aspx"><i class="fa fa-edit font-white"></i></a>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="table-responsive">
                                                                        <asp:Label ID="lblNoIncomeRecords" runat="server" Text="No Income Records Found" Visible="false" CssClass="text-danger" />

                                                                        <div id="IncomeList" runat="server">

                                                                            <table class="table table-bordered table-advanced table-striped table-hover">
                                                                                <%-- Table Header --%>
                                                                                <thead>
                                                                                    <tr class="TRDark">
                                                                                        <th class="text-center">Day</th>
                                                                                        <th class="text-center">Jan</th>
                                                                                        <th class="text-center">Feb</th>
                                                                                        <th class="text-center">Mar</th>
                                                                                        <th class="text-center">Apr</th>
                                                                                        <th class="text-center">May</th>
                                                                                        <th class="text-center">Jun</th>
                                                                                        <th class="text-center">Jul</th>
                                                                                        <th class="text-center">Aug</th>
                                                                                        <th class="text-center">Sep</th>
                                                                                        <th class="text-center">Oct</th>
                                                                                        <th class="text-center">Nov</th>
                                                                                        <th class="text-center">Dec</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <%-- END Table Header --%>
                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpIncome" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <%-- Table Rows --%>
                                                                                            <tr class="odd gradeX">
                                                                                                <td class="day-number text-center"><%# Container.ItemIndex + 1 %></td>


                                                                                                <td class="text-right"><%# Eval("Month1",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month2",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month3",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month4",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month5",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month6",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month7",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month8",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month9",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month10",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month11",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month12",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                            </tr>
                                                                                            <%-- END Table Rows --%>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box blue">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>EXPENSE
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                        <%--<a href="Account/ACC_Income/ACC_IncomeList.aspx"><i class="fa fa-edit font-white"></i></a>--%>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">
                                                                    <div class="table-responsive">
                                                                        <asp:Label ID="lblNoExpenseRecords" runat="server" Text="No Expense Records Found" Visible="false" CssClass="text-danger" />

                                                                        <div id="ExpenseList" runat="server">
                                                                            <table class="table table-bordered table-advanced table-striped table-hover">
                                                                                <%-- Table Header --%>
                                                                                <thead>
                                                                                    <tr class="TRDark">
                                                                                        <th class="text-center">Day</th>
                                                                                        <th class="text-center">Jan</th>
                                                                                        <th class="text-center">Feb</th>
                                                                                        <th class="text-center">Mar</th>
                                                                                        <th class="text-center">Apr</th>
                                                                                        <th class="text-center">May</th>
                                                                                        <th class="text-center">Jun</th>
                                                                                        <th class="text-center">Jul</th>
                                                                                        <th class="text-center">Aug</th>
                                                                                        <th class="text-center">Sep</th>
                                                                                        <th class="text-center">Oct</th>
                                                                                        <th class="text-center">Nov</th>
                                                                                        <th class="text-center">Dec</th>
                                                                                    </tr>
                                                                                </thead>
                                                                                <%-- END Table Header --%>
                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpExpense" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <%-- Table Rows --%>
                                                                                            <tr class="odd gradeX">
                                                                                                <td class=" text-center"><%# Container.ItemIndex + 1 %></td>

                                                                                                <td class="text-right"><%# Eval("Month1",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month2",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month3",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month4",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month5",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month6",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month7",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month8",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month9",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month10",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month11",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                                <td class="text-right"><%# Eval("Month12",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint)%></td>
                                                                                            </tr>
                                                                                            <%-- END Table Rows --%>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <!-- BEGIN EXAMPLE TABLE PORTLET-->
                                                            <div class="portlet box red">
                                                                <div class="portlet-title">
                                                                    <div class="caption">
                                                                        <i class="fa fa-bullhorn "></i>TreatmentType Summary
                                                                    </div>
                                                                    <div class="tools">
                                                                        <a href="javascript:;" class="collapse" data-original-title="" title=""></a>
                                                                    </div>
                                                                </div>
                                                                <div class="portlet-body" style="display: block;">

                                                                    <div class="table-responsive">
                                                                        <asp:Label ID="lblNoTreatmentSummaryRecords" runat="server" Text="No Treatment Summary Records Found" Visible="false" CssClass="text-danger" />

                                                                        <div id="TreatmentSummaryList" runat="server">
                                                                            <table class="table table-bordered table-advanced table-striped table-hover" id="sample12">
                                                                                <%-- Table Header --%>
                                                                                <thead>
                                                                                    <tr class="TRDark">
                                                                                        <th class="text-center " style="width: 20px;">
                                                                                            <asp:Label ID="lblSrNo" runat="server" Text="Sr."></asp:Label>
                                                                                        </th>
                                                                                        <th class="text-center">
                                                                                            <asp:Label ID="lblTreatmentType" runat="server" Text="Treatment Type"></asp:Label>
                                                                                        </th>
                                                                                        <th class="text-center">
                                                                                            <asp:Label ID="lblPatient" runat="server" Text="Patient Count"></asp:Label>
                                                                                        </th>
                                                                                        <th class="text-center">
                                                                                            <asp:Label ID="lblAmount" runat="server" Text="Total Amount"></asp:Label>
                                                                                        </th>


                                                                                    </tr>
                                                                                </thead>
                                                                                <%-- END Table Header --%>
                                                                                <tbody>
                                                                                    <asp:Repeater ID="rpTreatment" runat="server">
                                                                                        <ItemTemplate>
                                                                                            <%-- Table Rows --%>
                                                                                            <tr class="odd gradeX">
                                                                                                <td class="text-center">
                                                                                                    <%#Container.ItemIndex+1 %>
                                                                                                </td>
                                                                                                <td class="text-left">
                                                                                                    <%#Eval("Treatment") %>
                                                                                                </td>
                                                                                                <td class="text-center">
                                                                                                    <%#Eval("Patient") %>
                                                                                                </td>
                                                                                                <td class="text-right">
                                                                                                    <%#Eval("Amount",GNForm3C.CV.DefaultCurrencyFormatWithDecimalPoint) %>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <%-- END Table Rows --%>
                                                                                        </ItemTemplate>
                                                                                    </asp:Repeater>
                                                                                </tbody>
                                                                            </table>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnShow" EventName="Click" />
                    <%--<asp:AsyncPostBackTrigger ControlID="btnClear" EventName="Click" />--%>
                    <%--<asp:PostBackTrigger ControlID="lbtnExportExcel" />
            <asp:PostBackTrigger ControlID="lbtnExportPDF" />--%>
                </Triggers>
            </asp:UpdatePanel>
        </ContentTemplate>

    </asp:UpdatePanel>
    <%-- END Dashboard--%>


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
</asp:Content>
