<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="licenta.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="box-coloured">
        <h2>
            Despre noi
        </h2>
        <div class="box-content">
            <p style="padding:10px">
                La shopAround gasiti cea mai variata gama de produse IT, electronice si gadgeturi. <br /> Multumit total sau banii inapoi in 30 de zile.
            </p>
            <p style="padding:10px">
                <a href="About.aspx?lista='da'" class="bul">Vezi o lista cu locatiile showroom-urilor noastre!</a>
            </p>
        </div>
        <div class="box-content">
             <asp:DataList ID="DataList1" runat="server" DataSource="<%# AfiseazaSucursale() %>" >
                <ItemTemplate>
                <table>
                    <tr>
                        <td> Showroom-ul: <%#DataBinder.Eval(Container.DataItem, "nume") %>  </td>
            
            
                    </tr>
                   
                    <tr>
                        <td> Oras: <%#DataBinder.Eval(Container.DataItem, "oras") %>   </td>
                    </tr>
                    <tr>
                        <td> Strada: <%#DataBinder.Eval(Container.DataItem, "strada") %>   
                        </td>
                    </tr>
        
                 </table></ItemTemplate>
                 </asp:DataList>
        </div>
    </div>
</asp:Content>
