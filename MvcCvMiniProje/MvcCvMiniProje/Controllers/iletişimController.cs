using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;

namespace MvcCvMiniProje.Controllers
{
    public class iletişimController : Controller
    {
        // GET: iletişim
        GenericRepository<tbl_iletişim> repo = new GenericRepository<tbl_iletişim>();
        public ActionResult Index()
        {
            var iletisim = repo.list();
            return View(iletisim);
        }
    }
}