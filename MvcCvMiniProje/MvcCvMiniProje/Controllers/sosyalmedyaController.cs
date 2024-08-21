using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class sosyalmedyaController : Controller
    {
        // GET: sosyalmedya
        GenericRepository<tbl_sosyalmedya> repo = new GenericRepository<tbl_sosyalmedya>();
        public ActionResult Index()
        {
            var sliste = repo.list();
            return View(sliste);
        }
        [HttpGet]
        public ActionResult sgetir(int id)
        {
            var sbul = repo.find(x=>x.Id==id);
            return PartialView(sbul);
        }
        [HttpPost]
        public ActionResult sgetir(tbl_sosyalmedya p)
        {
            var sbul = repo.find(x => x.Id == p.Id);
            sbul.Ad = p.Ad;
            sbul.Durum = true;
            sbul.Link = p.Link;
            sbul.İcon = p.İcon;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}