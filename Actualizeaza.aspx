<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Actualizeaza.aspx.cs" Inherits="licenta.Actualizeaza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> 
                <asp:Label ID="LabelTitluCategorie" runat="server" Text="Actualizeaza informatii produse: " Visible = "true"></asp:Label>
            </h2>
         
            <div class="box-cart">
                <asp:Label ID="LabelFaraProduse" runat="server" Visible="false" Text="Nu s-au gasit produse!" ForeColor="#990000" Font-Size="Medium" Font-Bold="True"></asp:Label>

               <asp:DataList ID="DataInfoProduse" runat="server" Height="50px" 
                    Width="534px" Visible = "true">
                    <HeaderTemplate>
                        <asp:Label runat="server" ForeColor="#CC3300" Font-Size="Medium"> Lista produse:</asp:Label>
                        
                    </HeaderTemplate>
                    
                    <ItemTemplate> 
                        <a href='ActualizeazaProdus.aspx?id_prod=<%# DataBinder.Eval(Container.DataItem, "id_produs") %>'> 
                            <%# DataBinder.Eval(Container.DataItem, "nume_produs") %> </a>, <%# DataBinder.Eval(Container.DataItem, "nume_categorie") %>
                    </ItemTemplate>
                       
                </asp:DataList>
                <br /><br />
                
            </div>
        </div>
    </div>

</asp:Content>
