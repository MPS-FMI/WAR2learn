<%@ Page Title="" Language="C#" MasterPageFile="~/Angajat.Master" AutoEventWireup="true" CodeBehind="VeziComanda.aspx.cs" Inherits="licenta.VeziComanda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> 
                <asp:Label ID="LabelTitluCategorie" runat="server" Text="Informatii comanda: " Visible = "true"></asp:Label>
            </h2>
         
            <div class="box-cart">

                <asp:DataList ID="DataViewInfoClient" runat="server" Height="16px" 
                    Width="505px">
                    <HeaderTemplate>
                        <asp:Label runat="server" ID="titlu" ForeColor="#FF9900" CssClass="label-padding" Font-Size="Large" Font-Bold="True"> Informatii despre client:</asp:Label>
                        <table>
                    </HeaderTemplate>
                    <FooterTemplate>
                         
                        </table>
                    </FooterTemplate>
                    <ItemTemplate>
                       <tr>
                            <td style="color:#CC6600; padding:5 10 5 10px">Nume client:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "nume_client") %>
                            </td>
                        </tr>
                        <tr>
                            <td style="color:#993300; padding:5 10 5 10px"> Adresa client:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "nume_strada") %>, <%#DataBinder.Eval(Container.DataItem, "nume_oras") %>
                            </td>
                        </tr>
                        <tr>
                            <td style="color:#CC6600; padding:5 10 5 10px"> Produs:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "numar_produse") %>
                            </td>
                        </tr>
                        <tr>
                            <td style="color:#993300; padding:5 10 5 10px"> Valoare comanda:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "valoare_comanda") %>
                            </td>
                        </tr>
                        
                    </ItemTemplate>
                </asp:DataList>
                <br /><br />
                <asp:Label ID="LabelFinalizare" runat="server" Visible="False" Font-Bold="True" 
                    Font-Size="Large" ForeColor="#FF9900"></asp:Label>
                <br /><br />
                <asp:Repeater ID="RepeaterInfoComanda" runat="server" Visible = "true">
                    <HeaderTemplate>
                                        <table border="2" cellpadding="10px">
                                            
                    </HeaderTemplate>
                    <FooterTemplate>
                            <tr>
                            <td colspan="2" align="center"  style="color:#993300; padding:5 10 5 10px"> 
                                 
                                <asp:Button ID="ButtonFinalizeOrder" runat="server" CssClass="create-submit" Text="Finalizeaza comanda"  OnClick="ButtonFinalizeOrder_Click"  Height="25px" Width="130px"/>
                            </td>
                        </tr>
                         </table>
                    </FooterTemplate>

                    <SeparatorTemplate> <tr> <td colspan="2"> <div style="width:auto; height:3px; background:#a80303"> </div> </td></tr></SeparatorTemplate>

                    <ItemTemplate>
                        <tr>
                            <td> Produs:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "nume_produs") %>
                            </td>
                        </tr>
                        <tr>
                            <td> Pret:</td>
                            <td><%#DataBinder.Eval(Container.DataItem, "pret") %>
                            </td>
                        </tr>
                        <tr>
                            <td> Stare stoc:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "stoc") %>
                            </td>
                        </tr>
                        <tr>
                            <td> Categorie:</td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "nume_categorie") %>
                            </td>
                        </tr>
                        
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
