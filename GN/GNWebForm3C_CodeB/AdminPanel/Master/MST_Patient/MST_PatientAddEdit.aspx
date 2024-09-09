<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterPage.master" AutoEventWireup="true" CodeFile="MST_PatientAddEdit.aspx.cs" Inherits="AdminPanel_Master_MST_Patient_MST_PatientAddEdit" %>

<asp:Content ID="cnthead" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="cntPageHeader" ContentPlaceHolderID="cphPageHeader" runat="Server">
    <asp:Label ID="lblPageHeader_XXXXX" Text="Patient " runat="server"></asp:Label><small><asp:Label ID="lblPageHeaderInfo_XXXXX" Text="Master" runat="server"></asp:Label></small>
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
        <asp:HyperLink ID="hlPatient" runat="server" NavigateUrl="~/AdminPanel/Master/MST_Patient/MST_PatientList.aspx" Text="Patient List"></asp:HyperLink>
        <i class="fa fa-angle-right"></i>
    </li>
    <li class="active">
        <asp:Label ID="lblBreadCrumbLast" runat="server" Text="Patient Add/Edit"></asp:Label>
    </li>
</asp:Content>
<asp:Content ID="cntPageContent" ContentPlaceHolderID="cphPageContent" runat="Server">
    <!--Help Text-->
    <ucHelp:ShowHelp ID="ucHelp" runat="server" />
    <!--Help Text End-->
    <asp:ScriptManager ID="sm" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upMST_Patient" runat="server" EnableViewState="true" UpdateMode="Conditional" ChildrenAsTriggers="false">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <ucMessage:ShowMessage ID="ucMessage" runat="server" />
                    <asp:ValidationSummary ID="ValidationSummary1" SkinID="VS" runat="server" />
                </div>
            </div>

            <div class="portlet light">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Label SkinID="lblFormHeaderIcon" ID="lblFormHeaderIcon" runat="server"></asp:Label>
                        <span class="caption-subject font-green-sharp bold uppercase">
                            <asp:Label ID="lblFormHeader" runat="server" Text=""></asp:Label>
                        </span>
                    </div>
                </div>

                <div class="portlet-body form">
                    <div class="form-horizontal" role="form">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblPatient_XXXXX" runat="server" Text="Patient Name"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtPatientName" CssClass="form-control" runat="server" PlaceHolder="Enter Patient Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPatient" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPatientName" ErrorMessage="Enter Patient Name"></asp:RequiredFieldValidator>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblAge_XXXXX" runat="server" Text="Age"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" onkeypress="return IsPositiveInteger(event)" placeholder="Enter Age"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtAge" ErrorMessage="Enter Age" SetFocusOnError="True" Operator="DataTypeCheck" Display="Dynamic" Type="Integer"></asp:CompareValidator>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtAge" ErrorMessage="Enter Amount"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblDOB_XXXXX" runat="server" Text="Date of Birth"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <div class="input-group input-medium date date-picker" data-date-format='<%=GNForm3C.CV.DefaultHTMLDateFormat.ToString()%>'>
                                        <asp:TextBox ID="dtpDOB" CssClass="form-control" runat="server" placeholder="Date"></asp:TextBox>
                                        <span class="input-group-btn">
                                            <button class="btn default" type="button"><i class="fa fa-calendar"></i></button>
                                        </span>
                                    </div>
                                    <asp:RequiredFieldValidator ID="rfvDOB" runat="server" ControlToValidate="dtpDOB" ErrorMessage="Enter DOB" Display="Dynamic" Type="Date"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblMobileNo_XXXXX" runat="server" Text="MobileNo"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtMobileNo" CssClass="form-control" runat="server" PlaceHolder="Enter MobileNo"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvMobileNo" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtMobileNo" ErrorMessage="Enter MobileNo"></asp:RequiredFieldValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="col-md-3 control-label">
                                    <span class="required">*</span>
                                    <asp:Label ID="lblPrimaryDesc_XXXXX" runat="server" Text="PrimaryDesc"></asp:Label>
                                </label>
                                <div class="col-md-5">
                                    <asp:TextBox ID="txtPrimaryDesc" CssClass="form-control" runat="server" PlaceHolder="Enter PrimaryDesc"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvPrimaryDesc" SetFocusOnError="True" Display="Dynamic" runat="server" ControlToValidate="txtPrimaryDesc" ErrorMessage="Enter PrimaryDesc"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-3 control-label" for="txtPrimaryDesc">Patient Image</label>
                                <div class="col-md-5">
                                    <div class="fileinput fileinput-new" data-provides="fileinput">
                                        <div class="fileinput-new thumbnail" style="width: 200px; height: 150px;">
                                            <asp:Image ID="imgPatientPhotoPath" runat="server" AlternateText="Patient Image"/>
                                            <asp:HiddenField ID="hfPatientPhotoPath" runat="server" />
                                        </div>
                                        <div class="fileinput-preview fileinput-exists thumbnail" style="max-width: 200px; max-height: 150px;"></div>
                                        <div>
                                            <span class="btn default btn-file">
                                                <span class="fileinput-new">Select Image </span>
                                                <span class="fileinput-exists">Change </span>
                                                <asp:FileUpload ID="fuPatientPhotoPath" runat="server" />
                                            </span>
                                            <br />
                                            <a href="javascript:;" class="btn red fileinput-exists" data-dismiss="fileinput">Remove </a>

                                        </div>

                                    </div>


                                </div>
                            </div>
                            <div class="form-actions">
                                <div class="row">
                                    <div class="col-md-offset-3 col-md-9">
                                        <asp:Button ID="btnSave" runat="server" SkinID="btnSave" OnClick="btnSave_Click" />
                                        <asp:HyperLink ID="hlCancel" runat="server" SkinID="hlCancel" NavigateUrl="~/AdminPanel/Master/MST_Patient/MST_PatientList.aspx"></asp:HyperLink>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
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
<asp:Content ID="cntScripts" ContentPlaceHolderID="cphScripts" runat="Server">
</asp:Content>

