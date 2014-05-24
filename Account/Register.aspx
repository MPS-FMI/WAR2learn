<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs" Inherits="licenta.Account.Register" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="box-coloured">
        <div class="box-content">
            <asp:CreateUserWizard ID="RegisterUser" runat="server" EnableViewState="false" OnCreatedUser="RegisterUser_CreatedUser">
                <LayoutTemplate>
                    <asp:PlaceHolder ID="wizardStepPlaceholder" runat="server"></asp:PlaceHolder>
                    <asp:PlaceHolder ID="navigationPlaceholder" runat="server"></asp:PlaceHolder>
                </LayoutTemplate>
                <WizardSteps>
                    <asp:CreateUserWizardStep ID="RegisterUserWizardStep" runat="server">
                        <ContentTemplate>
                            <h2>
                                Creaza un nou cont de utilizator
                            </h2>
                            <p style="padding:10px">
                                Completeaza formularul de mai jos pentru a te inregistra in sistem.
                            </p>
                            <p style="padding:10px">
                                Parolele trebuie sa aiba o lungime de minimum <%= Membership.MinRequiredPasswordLength %> caractere.
                            </p>
                            <span class="failureNotification">
                                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
                            </span>
                            <asp:ValidationSummary ID="RegisterUserValidationSummary" runat="server" CssClass="failureNotification" 
                                 ValidationGroup="RegisterUserValidationGroup"/>
                            <div class="accountInfo">
                                <fieldset class="register" style="width:50%">
                                    <legend style="padding:10px">Informatiile Contului:</legend>
                                    <table cellpadding='10px' cellspacing='10px'>
                                        <tr>
                                            <td>
                                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Prenume:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" 
                                                 CssClass="failureNotification" ErrorMessage="Nu ati completat campul Nume." ToolTip="User Name is required." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label1" runat="server" AssociatedControlID="Prenume">Nume:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Prenume" runat="server" CssClass="textEntry"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Prenume" 
                                                 CssClass="failureNotification" ErrorMessage="Nu ati completat campul Prenume." ToolTip="Nu ati completat campul Prenume." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Email" runat="server" CssClass="textEntry"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" 
                                                     CssClass="failureNotification" ErrorMessage="E-mail is required." ToolTip="E-mail is required." 
                                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
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
                                                     CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required." 
                                                     ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirma Parola:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
                                            </td>    
                                            <td>
                                                <asp:RequiredFieldValidator ControlToValidate="ConfirmPassword" CssClass="failureNotification" Display="Dynamic" 
                                                     ErrorMessage="Confirm Password is required." ID="ConfirmPasswordRequired" runat="server" 
                                                     ToolTip="Confirm Password is required." ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                                     CssClass="failureNotification" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                                                     ValidationGroup="RegisterUserValidationGroup">*</asp:CompareValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </fieldset>

                                <fieldset class="register" style="width:50%">
                                    <legend style="padding:10px">Completare adresa:</legend>
                                        <table cellpadding='10px' cellspacing='10px'>
                                          <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" AssociatedControlID="Strada">Strada:</asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="Strada" runat="server" CssClass="textEntry"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Strada" 
                                                 CssClass="failureNotification" ErrorMessage="Nu ati completat campul Strada." ToolTip="Nu ati completat campul Strada." 
                                                 ValidationGroup="RegisterUserValidationGroup">*</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label3" runat="server" AssociatedControlID="OrasDropDown">Selectati Orasul:</asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:DropDownList ID="OrasDropDown"  DataSource='<%# AfiseazaOrase() %>' DataTextField="nume" DataValueField="id" runat="server" ViewStateMode="Enabled">
        
                                                 </asp:DropDownList>
                                            </td>
                                        </tr>
                                    </table>
                                </fieldset>
                                <p>
                                    <asp:Button ID="CreateUserButton" runat="server" CommandName="MoveNext" Text="Creaza utilizator" 
                                         ValidationGroup="RegisterUserValidationGroup" CssClass="create-submit"/>
                                </p>
                            </div>
                        </ContentTemplate>
                        <CustomNavigationTemplate>
                        </CustomNavigationTemplate>

                    </asp:CreateUserWizardStep>
                </WizardSteps>
            
            </asp:CreateUserWizard>
        </div>
    </div>
</asp:Content>
