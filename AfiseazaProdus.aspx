<%@ Page Title="" Language="C#" MasterPageFile="~/Client.Master" AutoEventWireup="true" CodeBehind="AfiseazaProdus.aspx.cs" Inherits="licenta.AfiseazaProdus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> Produse Categorie <asp:Label ID="LabelNumeProdus" runat="server"></asp:Label></h2>

        </div>
    </div>

    <p style="padding:10px"> 
        <asp:Label ID="Label1" runat="server" Text="Stare Stoc:"></asp:Label>
        <asp:Label ID="LabelStoc" runat="server" ForeColor="#CC3300" ></asp:Label>
        <br />
      <asp:Label ID="Label2" runat="server" Text="Pret:"></asp:Label>
        <asp:Label ID="LabelPret"
            runat="server"  ></asp:Label>
            
            <asp:Button ID="ButtonAddToCart" runat="server" CssClass="create-submit" 
             Text="Adauga in cos"  OnClick="ButtonAddToCart_Click" Height="54px" 
             Width="110px" />
    </p>


    <asp:DataList ID="DataListInfoCaracteristiciProdus" runat="server" 
        Width="525px">
        <ItemTemplate>
            <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "nume") %>' Font-Bold="true" Font-Underline="true" CssClass="label-padding" ></asp:Label>
            <asp:Label ID="Label4" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "valoare") %>'></asp:Label>
        </ItemTemplate>
    </asp:DataList>
</asp:Content>
