using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCvMiniProje.Models.entities;
using MvcCvMiniProje.repository;
using System.Web.Security;

namespace MvcCvMiniProje.Controllers
{   [AllowAnonymous]//Bu atribute bulunan controllerlara erişim sağlanır
    public class loginController : Controller
    {
        // GET: login
        dbcvmvcEntities ent = new dbcvmvcEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(tbl_admin p)
        {
            var girisbilgi = ent.tbl_admin.FirstOrDefault(x=>x.KullaniciAdi==p.KullaniciAdi && x.Sifre==p.Sifre);
            //bu şartların doğru olmasıyla girisbilgi dolu gelecek yani giris bilgiye veri atanacak
            if (girisbilgi != null)//girisbilgi değişkenimin içerisi boş değilse aşağıyı yap
            {   
                //bir tane cookie ayarla bu cookie değeride 2 parametreli
                //1->sisteme erişim sağlayan kişinin kullanıcıadı
                //2->bool durumu
                //formsauthentication-->sayfaya erişim için kullanıcı ayarla
                FormsAuthentication.SetAuthCookie(girisbilgi.KullaniciAdi, false);
                //bir oturum ayarlayacaz giren kullanıcının adına bir session işlemi
                Session["KullaniciAdi"] = girisbilgi.KullaniciAdi.ToString();
                return RedirectToAction("Index", "deneyim");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();//sayfadan çık
            Session.Abandon();//oturumu terk et
            return RedirectToAction("Index", "login");
        }
    }
}