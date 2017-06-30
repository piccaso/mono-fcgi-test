using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MonoFcgiTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        public ActionResult Trace()
        {
            var sb = new StringBuilder();

            DumpCollection(nameof(Request.Headers), sb, Request.Headers);
            DumpCollection(nameof(Request.ServerVariables), sb, Request.ServerVariables);
            DumpCollection(nameof(Request.Params), sb, Request.Params);
            DumpCollection(nameof(Request.QueryString), sb, Request.QueryString);

            return Content(sb.ToString(), "text/plain");
        }

        private void DumpCollection(string title, StringBuilder sb, NameValueCollection collection)
        {
            sb.AppendLine($"# {title}");
            foreach (var key in collection.AllKeys)
            {
                var value = collection[key];
                sb.AppendLine($"{key}: {value}");
            }
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            var sb = new StringBuilder();

            if (file != null && file.ContentLength > 0)
            {
                sb.AppendLine($"FileName   : {file.FileName}");
                sb.AppendLine($"ContentType: {file.ContentType}");
                sb.AppendLine($"Length     : {file.ContentLength}");
                using (var ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    ms.Seek(0, SeekOrigin.Begin);

                    using (var sr = new StreamReader(ms))
                    {
                        var cnt = 10;
                        while (!sr.EndOfStream && --cnt > 0)
                        {
                            var r = sr.Read();
                            sb.AppendLine($"{cnt,-12}:{r}");
                        }
                    }
                }
            }

            return Content(sb.ToString(),"text/plain");
        }
    }
}