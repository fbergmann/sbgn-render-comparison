<%@ Page Title="LibSBGN Render Comparison" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebLibSBGNRenderComparison._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<title>LibSBGN Render Comparison</title>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Comparison
    </h2>
    <p>
        Below you will find the current state of comparison as of <% Response.Write( DateTime.Now.ToLongDateString() +", " + DateTime.Now.ToLongTimeString()); %>.        
    </p>
    <asp:Label ID="lblResult" runat="server" ></asp:Label>    
    
</asp:Content>
