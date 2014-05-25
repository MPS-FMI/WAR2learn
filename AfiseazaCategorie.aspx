<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="AfiseazaCategorie.aspx.cs" Inherits="licenta.AfiseazaCategorie" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="box-coloured">
        <div class="box-content">
            <h2> Produse Categorie <asp:Label ID="LabelNumeCategorie" runat="server"></asp:Label></h2>
        </div>
    </div>

    <asp:Repeater ID="RepeaterProduseInCategorie" runat="server">
        <ItemTemplate>
            <a href='AfiseazaProdus.aspx?id_prod=<%#DataBinder.Eval(Container.DataItem,"id_prod") %>' class='bul'> 
                        <%# DataBinder.Eval(Container.DataItem,"nume") %> 
            </a> <br />
        </ItemTemplate>
    </asp:Repeater>

</asp:Content>
