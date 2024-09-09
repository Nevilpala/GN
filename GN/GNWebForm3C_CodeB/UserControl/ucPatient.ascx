<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPatient.ascx.cs" Inherits="UserControl_ucPatient" %>
<%--<asp:Image ID="imhPatient" runat="server" CssClass="img-responsive" AlternateText="Patient Image" EnableViewState="false" ImageUrl="~/Default/Images/profile_user.jpg" />--%>
<asp:MultiView ID="mvwPatient" runat="server" Visible="false" EnableViewState="false">
    <asp:View ID="vwPatient" runat="server">
        <div class="row">
            <div class="col-md-12">
                <div class="portlet light">
                    <div class="portlet-title ">
                        <div class="caption">
                            <span class="caption-subject font-green-sharp bold uppercase">
                                <i class="fa fa-user font-green-sharp"></i>Patient Details
                            </span>
                        </div>
                        <div class="pull-right">
                            <asp:HyperLink 
                                ID="hlPrint" 
                                SkinID="hlPrint"
                                NavigateUrl='<%# "~/AdminPanel/Reports/RPT_MST_Patient/RPT_PatientIDCard.aspx?PatientID=" + GNForm3C.CommonFunctions.EncryptBase64(ViewState["PatientID"].ToString()) + "&ReportType=" + GNForm3C.CommonFunctions.EncryptBase64("PDF") %>' 
                                runat="server"></asp:HyperLink> 
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="nav">
                                    <li class="text-center margin-bottom-10 margin-top-10">
                                        <asp:Image
                                            ID="imhPatient"
                                            runat="server"
                                            Height="180"
                                            Weigth="180"
                                            CssClass="img-circle imgStudentPhoto"
                                            AlternateText="Patient Image"
                                            EnableViewState="true" />

                                    </li>
                                </ul>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-md-12">
                                <div id="divBottom" class="table-responsive">
                                    <table class="table">
                                        <tbody>
                                            <tr class="text-center">
                                                <td class="text-center sbold" colspan="2">
                                                    <h4>
                                                        <asp:Label EnableViewState="false" ID="lblucTitle" class="bold font-blue-soft text-center gn-label" runat="server">Pala Nevil Dilipbhai</asp:Label>

                                                    </h4>
                                                    <small>
                                                        <span id="lblStudentStatusID" class="label label-sm label-success sbold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Status Date : 03-10-2021">On Roll</span>
                                                    </small>
                                                </td>
                                            </tr>

                                            <%--      <tr id="ctl00_cphPageContent_ucStudentInfoCompact_trCourseName" class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCourseName" class="font-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Program">BTech - CSE</span>
                                        </td>
                                    </tr>


                                    <tr class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblEnrollmentNo" class="font-grey-gallery font-md bold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Enrollment No.">21010101134<br>
                                            </span>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentSemester" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Semester">Semester - 7</span>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblABCID" class="font-blue-dark bold" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Academic Bank Credit No.(ABCID)">
                                                <br>
                                                371076861949</span>
                                        </td>
                                    </tr>
                                    <tr id="ctl00_cphPageContent_ucStudentInfoCompact_trCurrentDivision" class="text-center">
                                        <td class="text-center sbold" colspan="2">
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentDivision" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Division">CSE-7A</span>
                                            <br>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentLabBatchNo" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Current Batch">Batch No. 6</span>
                                            <br>
                                            <span id="ctl00_cphPageContent_ucStudentInfoCompact_lblCurrentRollNo" class="font-blue-dark" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Roll No.">Roll No. 217</span>
                                        </td>
                                    </tr>--%>



                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Patient Name :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatientName" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Name"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Age :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" runat="server" ID="lblucPatietAge" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient Age"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Date of Birth :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucDOB" runat="server" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Patient DOB"></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Mobile No. :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucMobileNo" runat="server" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="<i class='fa fa-phone'></i> Patient Mobile No."></asp:Label>

                                                </td>
                                            </tr>

                                            <tr>
                                                <th class="gn-view-label-header text-right text-nowrap">Primary Description :</th>
                                                <td class="gn-view-label-value">
                                                    <asp:Label EnableViewState="false" ID="lblucPrimaryDesc" runat="server" data-html="true" data-toggle="tooltip" data-placement="top" data-container="body" data-trigger="hover" data-original-title="Primary Description"> </asp:Label>

                                                </td>
                                            </tr>

                                        </tbody>

                                    </table>


                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </asp:View>
</asp:MultiView>