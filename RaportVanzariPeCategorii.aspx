<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RaportVanzariPeCategorii.aspx.cs" Inherits="licenta.RaportVanzariPeCategorii" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


 <div class="box-coloured">
        <div class="box-content">
            <h2> Vizualizare rapoarte:</h2>
            <asp:DataList ID="DataListRaport2" runat="server">
                <HeaderTemplate>
                    <table cellpadding="5px"  cellspacing="5px" style="text-align:center">
                        <tr>
                            <th>
                                An
                            </th>
                            <th>
                                Categorie
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
                    <tr style="font-size: small; color: #800000; padding:10px"> 
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "an") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "categorie") %>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "valoare") %>
                            </td>
                        </tr>
                </ItemTemplate>
            </asp:DataList>
            
        </div>
    </div>
</asp:Content>
