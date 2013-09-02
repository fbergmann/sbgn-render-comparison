using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using SBMLExtension;
namespace WebLibSBGNRenderComparison
{
    public partial class Image : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var uri = Request["uri"];
            if (!string.IsNullOrEmpty(uri))
            {
                var result = GetPNGForURI(uri);                
                Response.ContentType = "image/png";
                Response.Buffer = true;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(result);
                Response.Flush();                
                Response.End();
            }
        }



        public byte[] GetPNGForModel(string rawModel)
        {
            try
            {
                var layout = Util.readLayout(rawModel);
                if (layout == null)
                    throw new ArgumentException("Invalid model, need either SBML Layout / Render Extension, JDesigner, CellDesigner or libsbgn annotations");
                using (var stream = new MemoryStream())
                {
                    layout.ToImage(2f).Save(stream, ImageFormat.Png);
                    stream.Flush();
                    return stream.GetBuffer();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Write(ex.Message);
                return new byte[0];
            }
        }


        public byte[] GetPNGForURI(string uri)
        {
            try
            {
                using (var client = new WebClient())
                {
                    var rawModel = client.DownloadData(uri);
                    rawModel = Util.RemoveBOMFromBytes(rawModel);
                    return GetPNGForModel(Encoding.UTF8.GetString(rawModel));
                }
            }
            catch (Exception)
            {
                return new byte[0];
            }
        }
    }
}