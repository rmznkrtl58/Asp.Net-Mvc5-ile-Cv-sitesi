using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class deneyimController : Controller
    {
        // GET: deneyimü
        DeneyimlerRepository repo = new DeneyimlerRepository();
        public ActionResult Index()
        {   //DENEYİM LİSTELEME
            var deneyimliste = repo.list();
            return View(deneyimliste);
        }
        //DENEYİM EKLEME
        [HttpGet]
        public ActionResult yenideneyim()
        {
            return View();
        }
        [HttpPost]
        public ActionResult yenideneyim(tbl_deneyimlerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult dsil(int id)
        {   
            //tbl_deneyimlerime bağlı olan t nesneme 
            //repo.find ile gelecek değeri atadım
            tbl_deneyimlerim t = repo.find(x => x.Id == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult dgetir(int id)
        {
            //tbl_deneyimlerime bağlı olan t nesneme 
            //repo.find ile gelecek değeri atadım
            //sonra sayfamı t nesnemin içindeki verilerle birlikte çağırdım
            tbl_deneyimlerim t = repo.find(x=>x.Id==id);
            return View(t);
        }
        //GÜNCELLEME İŞLEMİ
        [HttpPost]
        public ActionResult dgetir(tbl_deneyimlerim p)
        {
            tbl_deneyimlerim t = repo.find(x => x.Id == p.Id);
            t.Başlık = p.Başlık;
            t.AltBaşlık = p.AltBaşlık;
            t.Acıklama = p.Acıklama;
            t.Tarih = p.Tarih;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}