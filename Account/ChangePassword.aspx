<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePassword.aspx.cs" Inherits="licenta.Account.ChangePassword" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="box-coloured">
        <h2>
            Change Password
        </h2>
        <div class="box-content">
            <p style="padding:10px">
                Use the form below to change your password.
            </p>
            <p style="padding:10px">
                New passwords are required to be a minimum of <%= Membership.MinRequiredPasswordLength %> characters in length.
            </p>
            <asp:ChangePassword ID="ChangeUserPassword" runat="server" CancelDestinationPageUrl="~/" EnableViewState="false" RenderOuterTable="false" 
                 SuccessPageUrl="ChangePasswordSuccess.aspx">
                <ChangePasswordTemplate>
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="ChangeUserPasswordValidationSummary" runat="server" CssClass="failureNotification" 
                         ValidationGroup="ChangeUserPasswordValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset class="changePassword">
                            <legend style="padding:10px">Account Information</legend>
                            <table cellpadding='10px' cellspacing='10px'>
                                <tr>
                                    <td>
                                        <asp:Label ID="CurrentPasswordLabel" runat="server" AssociatedControlID="CurrentPassword">Old Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="CurrentPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" ControlToValidate="CurrentPassword" 
                                             CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Old Password is required." 
                                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>    
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="NewPasswordLabel" runat="server" AssociatedControlID="NewPassword">New Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" ControlToValidate="NewPassword" 
                                             CssClass="failureNotification" ErrorMessage="New Password is required." ToolTip="New Password is required." 
                                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="ConfirmNewPasswordLabel" runat="server" AssociatedControlID="ConfirmNewPassword">Confirm New Password:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="ConfirmNewPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" ControlToValidate="ConfirmNewPassword" 
                                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="Confirm New Password is required."
                                             ToolTip="Confirm New Password is required." ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:RequiredFieldValidator>
                                    </td>
                                    <td>
                                        <asp:CompareValidator ID="NewPasswordCompare" runat="server" ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                             CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Confirm New Password must match the New Password entry."
                                             ValidationGroup="ChangeUserPasswordValidationGroup">*</asp:CompareValidator>
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        <p style="padding:10px">
                            <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Anuleaza" CssClass="search-submit"/>
                            <asp:Button ID="ChangePasswordPushButton" runat="server" CommandName="ChangePassword" Text="Schimba Parola" 
                                 ValidationGroup="ChangeUserPasswordValidationGroup" CssClass="create-submit"/>
                        </p>
                    </div>
                </ChangePasswordTemplate>
            </asp:ChangePassword>
        </div>
    </div>
</asp:Content>
