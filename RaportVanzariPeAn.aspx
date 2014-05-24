<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RaportVanzariPeAn.aspx.cs" Inherits="licenta.RaportVanzariPeAn" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="box-coloured">
        <div class="box-content">
            <h2> Vizualizare rapoarte:</h2>
            <asp:Repeater ID="RepeaterRaport3" runat="server">
                <HeaderTemplate>
                    <table  cellspacing="5px" style="text-align:center">
                        <tr style="font-size: medium; font-weight: bold; color: #808000">
                            <th>
                                Anul
                            </th>
                            <th>
                                Valoarea incasata
                            </th>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr  style="font-size: small;  color: #800000;">
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "an") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "valoare") %>
                            </td>
                        </tr>
                </ItemTemplate>
            </asp:Repeater>
            
        </div>
    </div>

</asp:Content>
