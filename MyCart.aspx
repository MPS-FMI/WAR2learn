<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="MyCart.aspx.cs" Inherits="licenta.MyCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box-coloured">
        <div class="box-content">
            <h2> Cosul meu de cumparaturi</h2>
         
            <div class="box-cart">
                <asp:Label ID="LabelCosGol" runat="server" Text="Momentan nu aveti nimic in cosul de cumparaturi!" Visible = "false"></asp:Label> <br />

                <asp:Label ID="LabelComandaTrimisa" runat="server" Text="Comanda dumneavoastra a fost trimisa!" Visible="false"></asp:Label><br />
    
                <asp:Label ID="LabelProduseInCos" runat="server" Text="Produsele selectate au fost rezervate pentru 45 de minute." Visible="true"></asp:Label><br /> <br />
                <asp:Repeater ID="RepeaterCart" runat="server" Visible = "true">
                    <HeaderTemplate>
                                        <table border="2" cellpadding="10">
                                            <tr>
                                                <th>Denumire Produs</th>
                                                <th>Pret</th>
                                            </tr>
                    </HeaderTemplate>
                    <FooterTemplate>
                            <tr>
                                <td colspan="2" align="right" style="background:#a80303; color:#fff; font-weight: normal; padding:5px;">
                                    
                                </td>
                    
                            </tr>
                            <tr>
                                <td colspan="2" align="center"> 
                                    <asp:Button ID="ButtonSendOrder" runat="server" CssClass="create-submit" Text="Trimite comanda"  OnClick="ButtonSendOrder_Click"  Height="45px"/>
                                </td>
                            </tr>
                         </table>
                    </FooterTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "nume_prod") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "pret") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
