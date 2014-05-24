<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="licenta.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="box-coloured">
        <h2>
            Autentificare
        </h2>   
        <div class="box-content">
            <br />
            <asp:Label ID="LabelMesaj" runat="server" Visible="false" ForeColor="#CC3300" Font-Bold="True" CssClass="label-padding"></asp:Label>

            <p style="padding:10px">
                <label>Completeaza cu numele de utilizator si parola.</label>
               <!--- <asp:HyperLink ID="RegisterHyperLink" runat="server" EnableViewState="false">Inregistraza-te</asp:HyperLink> daca nu ai deja un cont.--->
            </p>
            <asp:Login ID="LoginUser" runat="server" EnableViewState="false" RenderOuterTable="false">
                <LayoutTemplate>
                    <span class="failureNotification">
                        <asp:Literal ID="FailureText" runat="server"></asp:Literal>
                    </span>
                    <asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification" 
                        ValidationGroup="LoginUserValidationGroup"/>
                    <div class="accountInfo">
                        <fieldset style="width:50%">
                            <legend style="padding:10px">Informatiile Contului:</legend>
                            <p>
                                <table cellpadding='10px' cellspacing='10px'>
                                    <tr>
                                        <td>
                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Nume utilizator:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                                CssClass="failureNotification" ErrorMessage="Campul 'Nume utilizator' este obligatoriu." ToolTip="Campul 'Nume utilizator' este obligatoriu." 
                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Parola:</asp:Label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" 
                                                CssClass="failureNotification" ErrorMessage="Campul 'Parola' nu a fost completat." ToolTip="Campul 'Parola' nu a fost completat.." 
                                                ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
                                        </td>    
                                    </tr>
                                    <tr>    
                                        <td colspan='3'>
                                            <asp:CheckBox ID="RememberMe" runat="server"/>
                                            <asp:Label ID="RememberMeLabel" runat="server" AssociatedControlID="RememberMe" CssClass="inline">Pastreaza-ma autentificat.</asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </p>
                        </fieldset>
                        <p>
                            <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Autentifica" ValidationGroup="LoginUserValidationGroup" CssClass="search-submit" Width="120px" Height="25px"/>
                        </p>
                    </div>
                </LayoutTemplate>
             </asp:Login>
         </div>
    </div>
</asp:Content>
