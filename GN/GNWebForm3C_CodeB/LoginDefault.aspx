<%@ Page Title="" Language="C#" MasterPageFile="~/Default/MasterLogin.master" AutoEventWireup="true" CodeFile="LoginDefault.aspx.cs" Inherits="LoginDefault" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpContent" runat="Server">

    <!-- BEGIN LOGO -->
    <div class="logo "> 
        <img src="Default/Images/gnlogo.png" class="" alt="GNWEBSOFT LOGO" />
    </div>
    <!-- END LOGO -->
    <!-- BEGIN LOGIN -->
    <div class="content">

        <!-- BEGIN LOGIN FORM -->
        <form class="login-form" method="post" novalidate="novalidate">
            <h3 class="form-title font-green">Login</h3>
            <div class="alert alert-danger display-hide">
                <button class="close" data-close="alert"></button>
                <span>Enter any username and password. </span>
            </div>
            <div class="form-group">
                <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                <label class="control-label visible-ie8 visible-ie9">Username</label>
                <input class="form-control form-control-solid placeholder-no-fix" type="text" autocomplete="off" placeholder="Username" name="username" />
            </div>
            <div class="form-group">
                <label class="control-label visible-ie8 visible-ie9">Password</label>
                <input class="form-control form-control-solid placeholder-no-fix" type="password" autocomplete="off" placeholder="Password" name="password" />
            </div>
            <div class="form-actions">
                <button type="submit" class="btn green uppercase  ">Login</button>

            </div>
            <%-- <div class="login-options">
                <h4>Or login with</h4>
                <ul class="social-icons">
                    <li>
                        <a class="social-icon-color facebook" data-original-title="facebook" href="javascript:;"></a>
                    </li>
                    <li>
                        <a class="social-icon-color twitter" data-original-title="Twitter" href="javascript:;"></a>
                    </li>
                    <li>
                        <a class="social-icon-color googleplus" data-original-title="Goole Plus" href="javascript:;"></a>
                    </li>
                    <li>
                        <a class="social-icon-color linkedin" data-original-title="Linkedin" href="javascript:;"></a>
                    </li>
                </ul>
            </div>--%>
            <%--    <div class="create-account">
                <p>
                    <a href="javascript:;" id="register-btn" class="uppercase">Create an account</a>
                </p>
            </div>--%>
        </form>
    </div>
    <!-- END LOGIN FORM -->
</asp:Content>

