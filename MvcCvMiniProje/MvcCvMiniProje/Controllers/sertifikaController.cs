using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class sertifikaController : Controller
    {
        // GET: sertifika
        GenericRepository<tbl_sertifikalar> repo = new GenericRepository<tbl_sertifikalar>();
        public ActionResult Index()
        {   //Sertifika listeleme
            var sliste = repo.list();
            return View(sliste);
        }
        [HttpGet]
        public ActionResult sgetir(int id)
        {
            var sbul = repo.find(x => x.Id == id);
            return View(sbul);
        }
        [HttpPost]
        public ActionResult sgetir(tbl_sertifikalar p)
        {
            var sbul = repo.find(x => x.Id == p.Id);
            sbul.Tarih = p.Tarih;
            sbul.Açıklama = p.Açıklama;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult yenisertifika()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenisertifika(tbl_sertifikalar p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ssil(int id)
        {
            var sertifikabul = repo.find(x => x.Id == id);
            repo.TDelete(sertifikabul);
            return RedirectToAction("Index");
        }
    }
}