using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCBlog
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            HttpPostedFile uploads = context.Request.Files["upload"];//upload edilen dosyalarımızı alıyoruz
            string CKEditorFuncNum = context.Request["CKEditorFuncNum"];
            string file = System.IO.Path.GetFileName(uploads.FileName);//dosya adımızı aldık
            uploads.SaveAs(context.Server.MapPath(".") + "/images/uploads/" + file);//sunucuya kaydediyoruz. dilersek ismini de değiştirebiliriz.
            string url = "/images/uploads/" + file;//resmin url adresi
            context.Response.Write("<script>window.parent.CKEDITOR.tools.callFunction(" + CKEditorFuncNum + ", \"" + url + "\");</script>");//ckeditore ile iletişimimiz.
            context.Response.End();   
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}