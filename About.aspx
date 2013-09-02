<%@ Page Title="About LibSBGN Render Comparison" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="WebLibSBGNRenderComparison.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        About
    </h2>
    <p>
        This page was inspired by Martijn van Iersel's <a href="http://azraelbigcat.dyndns.org/reports/libsbgn/render_comparison/index.html">render comparison</a> page. And was
        developed for the better integration of the <a href="http://sbmllayout.sf.net">SBML Layout</a> libraries with support for the <a href="http://libsbgn.sf.net">LibSBGN</a>
        Markup format. 
    </p>
    <p>
        How does this site work? This site is implemented on top of ASP.net. All information is dynamically located. That is:        
    </p>
    <ul>
        <li> The Reference results are taken from SVN: http://libsbgn.svn.sourceforge.net/viewvc/libsbgn/trunk/test-files/ </li>
        <li> The PathViso results come straight from Matijns page: http://azraelbigcat.dyndns.org/reports/libsbgn/render_comparison/ </li>
        <li> The SBML Render Extension results are directly generated on the server using the latest version of the SBML extension library. For this, each
             individual file is generated dynamically by checking out the SBGN file from: http://libsbgn.svn.sourceforge.net/viewvc/libsbgn/trunk/test-files/.
        </li>
        <li>Vanted files are generated nightly using the latest jar file provided by Tobias Czauderna. </li>
    </ul>
    <p>
        Please contact me in case of questions or suggestions. 
    </p>
</asp:Content>
