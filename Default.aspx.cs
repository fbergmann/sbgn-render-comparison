using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace WebLibSBGNRenderComparison
{
    public partial class _Default : System.Web.UI.Page
    {

        //private const string SF_URL = "http://libsbgn.svn.sourceforge.net/viewvc/libsbgn/trunk/test-files";
        //public const string SF_URL = "http://libsbgn.svn.sourceforge.net/svnroot/libsbgn/trunk/test-files/";
      public const string SF_URL = "http://svn.code.sf.net/p/libsbgn/code/trunk/test-files/ER";

        static string[] elements = new[]
        {
            "adh", 
            "and", 
            "clone-marker", 
            "compartments", 
            "edgerouting", 
            "labeledCloneMarker", 
            "multimer", 
            "multimer2", 
            "or-simple", 
            "protein_degradation", 
            "reversible-verticalpn", 
            "states", 
            "statesType2", 
            "statesType3", 
            "stoichiometry", 
            "submap",
        };

        protected void Page_Init(object sender, EventArgs e)
        {
            elements = GetList();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lblResult.Text = GetTableString();
        }

        public static string[] GetList()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var wholeList = client.DownloadString(SF_URL);
                    var lines = wholeList.Split('\n');
                    var result = new List<string>();
                    Array.ForEach(lines, line =>
                    {
                        string trimmed = line.Trim();
                        trimmed = trimmed.Replace("<li>", "");
                        trimmed = trimmed.Replace("</li>", "");
                        if (trimmed.StartsWith("<a href="))
                            trimmed = trimmed.Substring(trimmed.IndexOf(">")+1);
                        if (trimmed.EndsWith(".sbgn</a>"))
                            result.Add(trimmed.Substring(0, trimmed.IndexOf(".")));
                    });
                    return result.ToArray();
                }
            }
            catch 
            {
                return new string[0];
            }
        }

        private static string GetTableString()
        {

            //const string width = "100%";
            const string width = "210px";

            var sb = new StringBuilder();            
            if (elements.Length > 0)
            {


                sb.Append("<h2>Overview</h2>");
                foreach (var file in elements)
                {
                    sb.AppendFormat("<a href=\"#{0}\">{0}</a>&nbsp;", file);
                }

                sb.Append("<table width = \"100%\">");
                sb.Append("<tr><td>Reference</td>" +
                          "<td><a href=\"http://www.pathvisio.org\">PathVisio</a></td>" +
                          "<td><a href=\"http://sbmllayout.sf.net/\">SBML Layout</a></td>" +
                          "<td><a href=\"http://vanted.ipk-gatersleben.de/\">SBGN-ED</a></td></tr>");

                foreach (var file in elements)
                {
                    sb.Append(
                        string.Format(
                            "<tr><td colspan=\"4\"><h3><a name=\"{0}\"/><a href=\"{1}\">{0}</a><h3></td></tr>", file,
                            String.Format("{1}/{0}.sbgn", file, SF_URL)));
                    sb.Append("<tr>");

                    string pvImage = String.Format("./Images/{0}.sbgn_pv.png", file);
                    sb.Append(string.Format("<td width=\"33%\"><img src=\"{0}\" width=\"{1}\"></td> ",
                                            String.Format("{1}/{0}.png", file, SF_URL), width));
                    sb.Append(
                        String.Format("<td width=\"33%\"><a href=\"{0}\"><img src=\"{0}\" width=\"{1}\"/></a></td>",
                                      pvImage, width));
                    sb.Append(
                        string.Format("<td width=\"33%\"><a href=\"{0}\"><img src=\"{0}\" width=\"{1}\"/></a></td> ",
                                      String.Format("./Image.aspx?uri={1}/{0}.sbgn", file, SF_URL)
                                      , width));
                    string vantedImage = String.Format("./Images/{0}.sbgn_vanted.png", file);
                    sb.Append(
                        String.Format("<td width=\"33%\"><a href=\"{0}\"><img src=\"{0}\" width=\"{1}\"/></a></td>",
                                      vantedImage, width));

                    sb.Append("</tr>");
                }

                sb.Append("</table >");
            }
            else
            {
                sb.Append("<h2>No cases</h2>");
                sb.Append("<p>Something went wrong while trying to obtain the test cases from SourceForge. Please" +
                    " ensure that SourceForge is up and running and the following URL is accessible. Once it is" +
                    " please check back here.</p>");
                sb.Append(String.Format("<p><a href=\"{0}/\">Test file directory</a></p>", SF_URL));

            }


            return sb.ToString();
        }
    }
}
