using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class hakkımdaController : Controller
    {
        // GET: hakkımda
        GenericRepository<tbl_hakkımda> repo = new GenericRepository<tbl_hakkımda>();
        [HttpGet]
        public ActionResult Index()
        {
            var hlistele = repo.list();
            return View(hlistele);
        }
        [HttpPost]
        public ActionResult Index(tbl_hakkımda p)
        {
            var hakkımda = repo.find(x => x.Id == 1);
            hakkımda.Ad = p.Ad;
            hakkımda.Adres = p.Adres;
            hakkımda.Açıklama = p.Açıklama;
            hakkımda.Mail = p.Mail;
            hakkımda.Resim = p.Resim;
            hakkımda.Soyad = p.Soyad;
            hakkımda.Telefon = p.Telefon;
            repo.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}