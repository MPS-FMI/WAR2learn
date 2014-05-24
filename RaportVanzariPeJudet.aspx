<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RaportVanzariPeJudet.aspx.cs" Inherits="licenta.RaportVanzariPeJudet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div class="box-coloured">
        <div class="box-content">
            <h2> Vizualizare rapoarte:</h2>
            <asp:Repeater ID="RepeaterRaport1" runat="server">
                <HeaderTemplate>
                    <table cellspacing="5px" style="text-align:center">
                        <tr style="font-size: medium; font-weight: bold; color: #808000">
                            <th>
                                An de calcul
                            </th>
                            <th>
                                Judet
                            </th>
                            <th>
                                Valoare incasata
                            </th>
                        </tr>
                </HeaderTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
                <ItemTemplate>
                    <tr  style="font-size: small; color: #800000;">
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "an") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "judet") %>
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
