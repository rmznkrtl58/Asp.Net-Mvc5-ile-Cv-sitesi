using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class egitimController : Controller
    {
        // GET: egitim
        GenericRepository<tbl_eğitim> repo = new GenericRepository<tbl_eğitim>();
        [Authorize]
        public ActionResult Index()
        {   //EĞİTİMLERİ LİSTELEME
            var egitimliste = repo.list();
            return View(egitimliste);
        }
        [HttpGet]
        public ActionResult yeniegitim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yeniegitim(tbl_eğitim p)
        {
            if (!ModelState.IsValid)//doğrulama ezilmişse 
            {
                return View();
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult esil(int id)
        {
            var egitimbul = repo.find(x=>x.Id==id);
            repo.TDelete(egitimbul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult egetir(int id)
        {
            var egitimbul = repo.find(x => x.Id == id);
            return View(egitimbul);
        }
        [HttpPost]
        public ActionResult egetir(tbl_eğitim p)
        {
            var egitimbul = repo.find(x => x.Id == p.Id);
            egitimbul.AltBaşlık = p.AltBaşlık;
            egitimbul.AltBaşlık2 = p.AltBaşlık2;
            egitimbul.Başlık = p.Başlık;
            egitimbul.Gno = p.Gno;
            egitimbul.Tarih = p.Tarih;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}