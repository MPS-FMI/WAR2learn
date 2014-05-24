<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="licenta._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
   
      <!-- Content Slider -->
      <div id="slider" class="box">
        <div id="slider-holder">
          <ul>
            <li><a href="#"><img src="/css/images/first-page1.png" alt="" /></a></li>
            <li><a href="#"><img src="/css/images/tablete-first-page6.png" alt="" /></a></li>
            <li><a href="#"><img src="/css/images/foto-first-page4.png" alt="" /></a></li>
            <li><a href="#"><img src="/css/images/monitoare-first-page2.png" alt="" /></a></li>
            <li><a href="#"><img src="/css/images/tablete-first-page5.png" alt="" /></a></li>
          </ul>
        </div>
        <div id="slider-nav"> <a href="#" class="active">1</a> <a href="#">2</a> <a href="#">3</a> <a href="#">4</a><a href="#">5</a> </div>
      </div>
      <!-- End Content Slider -->
      <!-- Products -->
      <div class="products">
        <div class="cl">&nbsp;</div>
        <ul>
          <li> <a href="#"><img src="/css/images/foto-first-page3.png" alt="" /></a>
            <div class="product-info">
              <h3>FUJIFILM S4000</h3>
              <div class="product-desc">
                <h4>30x super zoom 14 MP</h4><br />
                <h4>Filmare HD</h4><br />
                <strong class="price">599RON</strong> </div>
            </div>
          </li>
         
          <li class="last"> <a href="#"><img src="/css/images/monitor-first-page7.png" alt="" /></a>
            <div class="product-info">
              <h3>MONITOARE LED AOC</h3>
              <div class="product-desc">
                <h4>Diagonale de la 21.5"</h4><br />
                <h4>Rezolutie Full HD</h4><br />
                <strong class="price">de la 400RON</strong> </div>
            </div>
          </li>
        </ul>
        
    <div class="cl">&nbsp;</div>
     </div>
      <!-- End Products -->
      
     
</asp:Content>
