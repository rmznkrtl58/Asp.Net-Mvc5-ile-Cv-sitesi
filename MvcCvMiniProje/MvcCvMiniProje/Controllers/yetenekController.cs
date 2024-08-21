using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.repository;
using MvcCvMiniProje.Models.entities;

namespace MvcCvMiniProje.Controllers
{
    public class yetenekController : Controller
    {
        //deneyimlerimde tanımlamış olduğum deneyimlerrepository'nin farklı bir kullanımı var
        GenericRepository<tbl_yetenekler> repo =new GenericRepository<tbl_yetenekler>();
        public ActionResult Index()
        {  //YETENEK LİSTELEME
            var yetenekliste = repo.list();
            return View(yetenekliste);
        }
        [HttpGet]
        public ActionResult yeniyetenek()
        {   
            return View();
        }
        [HttpPost]
        public ActionResult yeniyetenek(tbl_yetenekler p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult ysil(int id)
        {
            var yetenekbul = repo.find(x => x.Id == id);
            repo.TDelete(yetenekbul);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult ygetir(int id)
        {   
            var yetenekbul = repo.find(x => x.Id == id);
            return View(yetenekbul);
        }
        public ActionResult güncelle(tbl_yetenekler p)
        {
            var yetenekbul = repo.find(x => x.Id == p.Id);
            yetenekbul.Yetenek = p.Yetenek;
            yetenekbul.Oran = p.Oran;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}