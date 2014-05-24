<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Adauga.aspx.cs" Inherits="licenta.Adauga" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> 
                <asp:Label ID="LabelTitluAdauga" runat="server" Text="Adauga produs nou: " Visible = "true"></asp:Label>
            </h2>
         
            <div class="box-cart">
                <asp:Label ID="LabelProdus" runat="server" Text="Produsul a fost adaugat!" Visible="false" CssClass="label-padding" ForeColor="#FF9900" Font-Size="Large" Font-Bold="True"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Alege categoria:" CssClass="label-padding"></asp:Label><br />
                <asp:DropDownList ID="CategoriiDropDown"  
                    DataSource='<%# AfiseazaCategorii() %>' DataTextField="nume" 
                    DataValueField="id" runat="server" ViewStateMode="Enabled" Height="20px" 
                    Width="177px">
                </asp:DropDownList>
                <table cellpadding="10px">
                    <tr>
                        <td><asp:Label ID="Label2" runat="server" Text="Nume produs:"></asp:Label></td>
                        <td>
                             <asp:TextBox ID="TextBoxNumeProdus" runat="server" Width="119px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label3" runat="server" Text="Pret unitar:"></asp:Label></td>
                        <td>
                             <asp:TextBox ID="TextBoxPretUnitar" runat="server" Height="23px" Width="119px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label4" runat="server" Text="Stoc impus:"></asp:Label></td>
                        <td>
                             <asp:TextBox ID="TextBoxStocImpus" runat="server" Width="119px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td><asp:Label ID="Label5" runat="server" Text="Stoc curent:"></asp:Label></td>
                        <td>
                             <asp:TextBox ID="TextBoxStocCurent" runat="server" Width="120px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                             <asp:Button ID="ButtonAdaugaProdus" runat="server" CssClass="create-submit" 
                                 Text="Adauga"  OnClick="ButtonAdaugaProdus_Click"  Height="27px" 
                                 Width="193px"/>
                        </td>
                    </tr>
                </table>
                
                <br /><br />
                
            </div>
        </div>
    </div>

</asp:Content>
