<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ActualizeazaProdus.aspx.cs" Inherits="licenta.ActualizeazaProdus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> 
                <asp:Label ID="LabelTitluCategorie" runat="server" Text="Actualizeaza informatii produs: " Visible = "true"></asp:Label>
            </h2>
         
            <div class="box-cart">
                <asp:Label ID="LabelProdus" runat="server" Text="Produsul a fost actualizat cu succes!" Visible="false" ForeColor="#669900" Font-Size="Medium" Font-Bold="True"></asp:Label>
                <asp:Label runat="server" ID="LabelInfo" ForeColor="#669900" Font-Size="Small" Font-Bold="True" Visible="true"></asp:Label> 
                        
                <asp:DataList ID="DataListProdus" runat="server" Visible = "true" Width="373px">
                    <HeaderTemplate>
                        <table>
                    </HeaderTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                    <ItemTemplate>
                       <tr>
                            <td style="color:#CC6600; padding:5 10 5 10px"> Stoc curent:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "stoc") %>
                            </td>
                            <td> 
                                <asp:TextBox ID="TextBoxStoc" runat="server" OnTextChanged="TextBoxStoc_Changed"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color:#CC6600; padding:5 10 5 10px"> Stoc impus:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "stoc_impus") %>
                            </td>
                            <td> 
                                <asp:TextBox ID="TextBoxImpus" runat="server" OnTextChanged="TextBoxImpus_Changed"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="color:#CC6600; padding:5 10 5 10px"> Pret:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "pret") %>
                            </td>
                            <td> 
                                <asp:TextBox ID="TextBoxPret" runat="server"  OnTextChanged="TextBoxPret_Changed"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td colspan="3"> 
                                <asp:Button ID="ButtonUpdateProdus" runat="server" CssClass="create-submit" Text="Actualizeaza"  OnClick="ButtonUpdateProdus_Click"  Height="25px" Width="150px"/>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>

                                
            </div>
        </div>
    </div>

</asp:Content>
