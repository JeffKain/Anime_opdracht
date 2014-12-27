﻿<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AnimeList_Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Animelist</h1>
        <p class="lead">Welcome to Animelist! Animelist is a web application for creating your personal list of anime and/or manga</p>
    </div>
    
    
   <asp:SqlDataSource    
   ConnectionString="<%$ ConnectionStrings:MyConnectionString %>"
   ID="SqlDataSource1" runat="server"
   SelectCommand="SELECT DB21_ANIME.ANIMENAME, DB21_MYANIME.SCORE, DB21_MYANIME.GENRE, DB21_MYANIME.STATUS FROM DB21_MYANIME, DB21_ANIME, DB21_ACCOUNT WHERE DB21_MYANIME.MYANIMEID = DB21_ANIME.MYANIMEID AND DB21_MYANIME.ACCOUNTNR = DB21_ACCOUNT.ACCOUNTNR AND (DB21_ACCOUNT.MAILADDRESS = @email)" ProviderName="<%$ ConnectionStrings:MyConnectionString.ProviderName %>">
   </asp:SqlDataSource>
    
        <asp:GridView ID="GridView1" runat="server" DataKeyNames="email" DataSourceID="SqlDataSource1" Width="374px">
        <Columns>
            <asp:BoundField DataField="ANIMENAME" HeaderText="ANIMENAME" SortExpression="ANIMENAME" />
            <asp:BoundField DataField="SCORE" HeaderText="SCORE" SortExpression="SCORE" />
            <asp:BoundField DataField="GENRE" HeaderText="GENRE" SortExpression="GENRE" />
            <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
        </Columns>
    </asp:GridView>
    </asp:Content>