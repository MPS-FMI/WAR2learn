<%@ Page Title="" Language="C#" MasterPageFile="~/Angajat.Master" AutoEventWireup="true" CodeBehind="FacturiAngajat.aspx.cs" Inherits="licenta.FacturiAngajat" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ul style="list-style-type: none;">
<li>
<div class="box-coloured">
        <div class="box-content">
            <h2>
                 Computere: ultimele facturi achitate
            </h2>
         </div>
    </div>                   
               <!-- Orders -->
          <div class="products">
            <div class="cl">&nbsp;</div>
            <ul>
                <li>
               <div class="invoice">
                  <h3>Ultrabook SAMSUNG</h3><strong class="order_price">5899RON</strong> 
                  <div class="product-desc">
                    <h4>procesor Intel® CoreTM i5-3317UM 1.70GHz</h4> 
                    <h4> Ivy Bridge </h4>
                     <h4> 4GB, 128GB SSD </h4>
                     <h4> Intel® HD Graphics</h4>
                     <h4> Microsoft Windows 8, Dark Grey</h4>
                    
                  </div>
                  <div class="client-desc">
                    <h4>Ghita Laurentiu - Pitesti</h4>
                  </div>
                </div>
              </li>
         
              <li class="spaced"> 
                <div class="invoice">
                  <h3>Ultrabook Lenovo IDEA PAD</h3><strong class="order_price">3400RON</strong>
                  <div class="product-desc">
                    <h4>procesor Intel® CoreTM i5-3317U 1.70GHz</h4>
                     <h4>Ivy Bridge</h4>
                      <h4>4GB, 500GB + SSD 24GB</h4>
                       <h4>Intel® HD Graphics</h4>
                        <h4>Microsoft Windows 8, Gri</h4

                   </div>
                   <div class="client-desc">
                    <h4>Mitra Corina - Suceava</h4>
                  </div>
                </div>
              </li>
            </ul>
        
        <div class="cl">&nbsp;</div>
         </div>
      <!-- End Orders -->
    </li>                    
                        
    <li>
    <div class="box-coloured">
        <div class="box-content">
            <h2>
                    Periferice: ultimele facturi achitate
            </h2>
        </div>
    </div>
            <div class="products">
            <div class="cl">&nbsp;</div>
            <ul>
                <li class="older">
                       Luna Iunie
                       <a href="" class="bul"> Vizualizare</a>
                    </li>
                <li class="older">
                       Luna Mai
                       <a href="" class="bul"> Vizualizare</a>
                    
                 </li>
                 <li class="older">
                       Luna Aprilie
                       <a href="" class="bul"> Vizualizare</a>
                    
               </li> 
               </ul>
            </div> 
        </li>
    </ul>
</asp:Content>
