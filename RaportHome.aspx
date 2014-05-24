<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RaportHome.aspx.cs" Inherits="licenta.RaportHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box-coloured">
        <div class="box-content">
            <h2> Vizualizare rapoarte:</h2>
         
            <ul style="list-style:none">   
                <li><a href="RaportVanzariPeJudet.aspx" class="bul"> Vanzarile inregistrate la nivel de judet in perioada 2000 - 2013</a></li>
                <li><a href="RaportVanzariPeCategorii.aspx" class="bul"> Ieraria dupa vanzari a categoriilor de produse</a></li>
                <li><a href="RaportVanzariPeAn.aspx" class="bul"> Venitul incasat pe an</a></li>
            </ul>
                
                 
        </div>
    </div>

</asp:Content>
