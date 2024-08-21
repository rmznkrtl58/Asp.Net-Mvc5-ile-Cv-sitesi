using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class hobilerController : Controller
    {
        // GET: hobiler
        GenericRepository<tbl_hobiler> repo = new GenericRepository<tbl_hobiler>();
        [HttpGet]
        public ActionResult Index()
        {
            var hobiliste = repo.list();
            return View(hobiliste);
        }
        [HttpPost]
        public ActionResult Index(tbl_hobiler p)
        {
            var hobi = repo.find(x => x.Id == 1);
            hobi.Açıklama1 = p.Açıklama1;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
