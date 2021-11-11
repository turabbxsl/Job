using IsAxtaris.appclass;
using IsAxtaris.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Web.Security;
using System.Threading;
using System.Threading.Tasks;

namespace IsAxtaris.Controllers
{
    public class HomeController : Controller
    {

        Context context = new Context();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }



        public ActionResult Giris()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Giris(tbl_istifadeci model)
        {

            var varmi = context.tbl_istifadeci.Where(i => i.istifadeciadi == model.istifadeciadi && i.sifre == model.sifre).FirstOrDefault();
            if (varmi == null)
            {
                Session["loginsehv"] = "Istifadeci Adi Ve Ya Sifre Yanlisdir";
                return View();
            }
            else if (varmi.sifre == model.sifre)
            {
                ViewBag.istt = model.istifadeciadi;
                Session["username"] = model.istifadeciadi;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }


       

        public ActionResult Qeydiyyatt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Qeydiyyatt(tbl_istifadeci model)
        {
            var varmi = context.tbl_istifadeci.Where(i => i.istifadeciadi == model.istifadeciadi || i.sifre == model.sifre).FirstOrDefault();

            if (varmi != null)
            {
                Session["istifadeciuygunlugu"] = "Istifadeci Adindan Istifade Olunub";
                return RedirectToAction("Giris", "Home");
            }

            

            context.tbl_istifadeci.Add(model);
            context.SaveChanges();

            ViewBag.ist = model.istifadeciadi;
            Session["username"] = model.istifadeciadi;
            Session["yeniuzv"] = "Yeni Uzv";

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Butunvakansiyalar(int? page)
        {
            var data = context.tbl_vakansiya.OrderByDescending(x => x.tarix).ToList().ToPagedList(page ?? 1, 12);
            return View(data);
        }

        public ActionResult ButunCVler(int? page)
        {
            var data = context.tbl_CCVV.OrderByDescending(x => x.tarix).ToList().ToPagedList(page ?? 1, 12);
            return View(data);
        }



        public PartialViewResult Vakansiyalar()
        {
            var data = context.tbl_vakansiya.ToList().OrderByDescending(x => x.tarix).Take(12);
            ViewBag.kategoriyalar = context.tbl_kategoriya.ToList();
            return PartialView(data);
        }

        public PartialViewResult KategoriyaVakansiya()
        {
            var data = context.tbl_kategoriya.ToList();
            return PartialView(data);
        }

        public PartialViewResult CVler()
        {
            var data = context.tbl_CCVV.ToList().OrderByDescending(x => x.tarix).Take(12);
            ViewBag.kategoriyalar = context.tbl_kategoriya.ToList();
            return PartialView(data);
        }


        public ActionResult IstifadeciCV()
        {
            if (Session["username"] != null)
            {
                var KullaniciAdi = Session["username"].ToString();
                var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                //var cvsi = context.tbl_CCVV.Where(x => x.id == kullanici.cvid);
                return View(kullanici);
            }
            return View();
        }


        public ActionResult IstifadeciVakansiya()
        {
            if (Session["username"] != null)
            {
                var KullaniciAdi = Session["username"].ToString();
                var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                //var cvsi = context.tbl_CCVV.Where(x => x.id == kullanici.cvid);
                return View(kullanici);
            }
            return View();
        }



        public ActionResult CVsil(int id)
        {
            tbl_resm resm = context.tbl_resm.Where(x => x.cvid == id).FirstOrDefault();
            if (resm != null)
            {
                context.tbl_resm.Remove(resm);
                context.SaveChanges();
            }
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();
            kullanici.cvolar = false;
            tbl_CCVV cv = context.tbl_CCVV.FirstOrDefault(x => x.id == id);
            context.tbl_CCVV.Remove(cv);
            
            context.SaveChanges();
            Session["silmeugurlu"] = "Ugurlu Silindi";
            return RedirectToAction("IstifadeciCV","Home");
        }
        public ActionResult Vakansiyasil(int id)
        {
            tbl_resm resm = context.tbl_resm.Where(x => x.vakansiyaid == id).FirstOrDefault();
            if (resm != null)
            {
                context.tbl_resm.Remove(resm);
                context.SaveChanges();
            }
            var KullaniciAdi = Session["username"].ToString();
            var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();
            kullanici.vakansiyaolar = false;
            tbl_vakansiya cv = context.tbl_vakansiya.FirstOrDefault(x => x.id == id);
            context.tbl_vakansiya.Remove(cv);

            context.SaveChanges();
            Session["silmeugurlu"] = "Ugurlu Silindi";
            Thread.Sleep(5000);
            return RedirectToAction("IstifadeciVakansiya", "Home");
        }


        public PartialViewResult Nav()
        {
            var data = context.tbl_kategoriya.ToList();
            return PartialView(data);
        }

        [HttpGet]
        public ActionResult CVyaz()
        {
            ViewBag.Kategoriyalar = context.tbl_kategoriya.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult CVyaz(HttpPostedFileBase fileupload, tbl_CCVV model)
        {

            model.tarix = DateTime.Now.ToShortDateString();
            string bitmesi = DateTime.Now.AddDays(15).ToShortDateString();
            model.bitmetarixi = bitmesi;
            context.tbl_CCVV.Add(model);
            context.SaveChanges();

            int ID = model.id;

            var IIDD = context.tbl_CCVV.Where(x => x.id == ID).FirstOrDefault();

            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap kicikresim = new Bitmap(img, settings.Kicik);
                Bitmap boyukresim = new Bitmap(img, settings.Boyuk);


                string kicikyol = "/Content/CVSekiller/Kicik/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                string boyukyol = "/Content/CVSekiller/Boyuk/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);


                kicikresim.Save(Server.MapPath(kicikyol));
                boyukresim.Save(Server.MapPath(boyukyol));

                tbl_resm rsm = new tbl_resm();

                rsm.kicikolculu = kicikyol;
                rsm.boyukolculu = boyukyol;
                rsm.cvid = IIDD.id;

                if (context.tbl_resm.FirstOrDefault(x => x.id == IIDD.id && x.varsayilan == false) != null)
                {
                    rsm.varsayilan = false;
                }
                else
                {
                    rsm.varsayilan = true;
                }
                var KullaniciAdi = Session["username"].ToString();
                var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                kullanici.cvid = model.id;
                kullanici.cvolar = true;
                context.tbl_resm.Add(rsm);
                context.SaveChanges();
                Session["cvyazdi"] = "CV Yazildi";
                return View("Index");
            }
            else
            {
                tbl_resm rsm = new tbl_resm();

                rsm.cvid = IIDD.id;

                if (context.tbl_resm.FirstOrDefault(x => x.id == IIDD.id && x.varsayilan == false) != null)
                {
                    rsm.varsayilan = false;
                }
                else
                {
                    rsm.varsayilan = true;
                }
                var KullaniciAdi = Session["username"].ToString();
                var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                kullanici.cvid = model.id;
                kullanici.cvolar = true;
                Session["cvyazdi"] = "CV Yazildi";

                context.SaveChanges();
                return View("Index");

            }
            
        }

        [HttpGet]
        public ActionResult Vakansiyayaz()
        {
            ViewBag.Kategoriyalar = context.tbl_kategoriya.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Vakansiyayaz(HttpPostedFileBase fileupload, tbl_vakansiya model)
        {
            model.tarix = DateTime.Now.ToShortDateString();
            string bitmesi = DateTime.Now.AddDays(15).ToShortDateString();
            model.bitmetarixi = bitmesi;
            context.tbl_vakansiya.Add(model);
            context.SaveChanges();

            int ID = model.id;

            var IIDD = context.tbl_vakansiya.Where(x => x.id == ID).FirstOrDefault();

            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap kicikresim = new Bitmap(img, settings.Kicik);
                Bitmap boyukresim = new Bitmap(img, settings.Boyuk);


                string kicikyol = "/Content/Sekiller/Kicik/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                string boyukyol = "/Content/Sekiller/Boyuk/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);


                kicikresim.Save(Server.MapPath(kicikyol));
                boyukresim.Save(Server.MapPath(boyukyol));

                tbl_resm rsm = new tbl_resm();

                rsm.kicikolculu = kicikyol;
                rsm.boyukolculu = boyukyol;
                rsm.vakansiyaid = IIDD.id;

                if (context.tbl_resm.FirstOrDefault(x => x.id == IIDD.id && x.varsayilan == false) != null)
                {
                    rsm.varsayilan = false;
                }
                else
                {
                    rsm.varsayilan = true;
                }
                var KullaniciAdi = Session["username"].ToString();
                var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                kullanici.vakansiyaid = model.id;
                kullanici.vakansiyaolar = true;
                Session["vakansiyayazdi"] = "Vakansiya Yazdi";
                context.tbl_resm.Add(rsm);
                context.SaveChanges();
                return View("Index");
            }
            else
            {
                    tbl_resm rsm = new tbl_resm();
                
                    rsm.vakansiyaid = IIDD.id;

                    if (context.tbl_resm.FirstOrDefault(x => x.id == IIDD.id && x.varsayilan == false) != null)
                    {
                        rsm.varsayilan = false;
                    }
                    else
                    {
                        rsm.varsayilan = true;
                    }
                    var KullaniciAdi = Session["username"].ToString();
                    var kullanici = context.tbl_istifadeci.Where(i => i.istifadeciadi == KullaniciAdi).SingleOrDefault();

                    kullanici.vakansiyaid = model.id;
                    kullanici.vakansiyaolar = true;
                    Session["vakansiyayazdi"] = "Vakansiya Yazdi";
                    
                    context.SaveChanges();
                    return View("Index");
                
            }
            
        }


        public ActionResult VakansiyaDetails(int id)
        {
            var data = context.tbl_vakansiya.Where(x => x.id == id).FirstOrDefault();

            data.goruntulenme++;

            context.SaveChanges();
            return View(data);
        }
        public ActionResult CVDetails(int id)
        {
            var data = context.tbl_CCVV.Where(x => x.id == id).FirstOrDefault();

            data.goruntulenme++;

            context.SaveChanges();
            return View(data);
        }

        [HttpPost]
        public string Goruntulendi(int id)
        {
            tbl_vakansiya mql = context.tbl_vakansiya.FirstOrDefault(x => x.id == id);
            mql.goruntulenme++;
            context.SaveChanges();
            return mql.goruntulenme.ToString();
        }

        public PartialViewResult Oxsarvakansiyalar(int ID,int vkid)
        {
            var data = context.tbl_vakansiya.Where(x => x.kategoriyaid == ID && x.id != vkid).ToList().Take(7);
            return PartialView(data);
        }

        public PartialViewResult Oxsarcvler(int ID,int ozid)
        {
            var data = context.tbl_CCVV.Where(x => x.kategoriyaid == ID && x.id != ozid).ToList().Take(4);
            return PartialView(data);
        }

        public ActionResult KatV(int id, int? page)
        {
            var data = context.tbl_vakansiya.Where(x => x.kategoriyaid == id).ToList().ToPagedList(page ?? 1, 12);
            return View(data);
        }

        public ActionResult KatCV(int id, int? page)
        {
            var data = context.tbl_CCVV.Where(x => x.kategoriyaid == id).ToList().ToPagedList(page ?? 1, 12);
            return View(data);
        }











    }
}