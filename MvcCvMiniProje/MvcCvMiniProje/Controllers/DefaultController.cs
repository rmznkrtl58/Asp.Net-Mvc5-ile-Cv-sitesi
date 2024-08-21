using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;

namespace MvcCvMiniProje.Controllers
{   
    [AllowAnonymous]//Bu atribute bulunan controllerlara erişim sağlanır
    public class DefaultController : Controller
    {
        // GET: Default
        dbcvmvcEntities ent = new dbcvmvcEntities();
        public ActionResult Index()
        {   //HAKKIMDA LİSTELEME
            var hakkımdaliste = ent.tbl_hakkımda.ToList();
            return View(hakkımdaliste);
        }

        public PartialViewResult deneyim()
        {   //DENEYİMLERİM LİSTELEME
            var deneyimliste = ent.tbl_deneyimlerim.ToList();
            return PartialView(deneyimliste);
        }
        public PartialViewResult sosyalmedya()
        {
            //Sosyal medya iconları listeleme
            var sliste = ent.tbl_sosyalmedya.ToList();
            return PartialView(sliste);
        }
        public PartialViewResult egitim()
        {
            //EĞİTİMLERİ LİSTELEME
            var egitimliste = ent.tbl_eğitim.ToList();
            return PartialView(egitimliste);
        }
        public PartialViewResult yetenek()
        {   //YETENEK LİSTELEME
            var yetenekliste = ent.tbl_yetenekler.ToList();
            return PartialView(yetenekliste);
        }
        public PartialViewResult hobi()
        {
            var hobilistele = ent.tbl_hobiler.ToList();
            return PartialView(hobilistele);
            
        }
        public PartialViewResult sertifika()
        {   //SERTİFİKA LİSTELEME
            var sertifikaliste = ent.tbl_sertifikalar.ToList();
            return PartialView(sertifikaliste);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();

        }
        [HttpPost]
        public PartialViewResult iletisim(tbl_iletişim t)
        {   //bugünün kısa tarihini ekle
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            ent.tbl_iletişim.Add(t);
            ent.SaveChanges();
            return PartialView();

        }
    }
}