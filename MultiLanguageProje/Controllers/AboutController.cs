using MultiLanguageProje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguageProje.Controllers
{
    public class AboutController : Controller
    {
        MultiLanguageEntities db = new MultiLanguageEntities();
        // GET: About
        public ActionResult Index()
        {
            var request = Request.Url.Query;
            string dil = "";
            ListAboutViewModel model = new ListAboutViewModel();
            if (request != "")
            {
                if (HttpContext.Request.QueryString["language"].ToString() != null)
                {
                    dil = HttpContext.Request.QueryString["language"].ToString();
                    switch (dil)
                    {
                        case "tr-TR":
                            model.Abouts = db.About.Where(p => p.LanguageId == 1).ToList();
                            break;
                        case "en-US":
                            model.Abouts = db.About.Where(p => p.LanguageId == 2).ToList();
                            break;
                        default:
                            model.Abouts = db.About.Where(p => p.LanguageId == 1).ToList();
                            break;
                    }
                }
                return View(model);
            }
            else
            {
                model.Abouts = db.About.Where(p => p.LanguageId == 1).ToList();
                return View(model);
            }
        }
    }
}