using Scarpe_co.Models;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Scarpe_co.Controllers
{
    [Authorize(Users = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            List<Prodotti> list = new List<Prodotti>();
            list = Prodotti.SelectAllP();

            return View(list);
        }


        public ActionResult Crea()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Crea(Prodotti p, HttpPostedFileBase Copertina, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            if (ModelState.IsValid)
            {
                if (Copertina.ContentLength > 0)
                {
                    string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), Copertina.FileName);
                    Copertina.SaveAs(pathToSave);
                    p.Copertina = Copertina.FileName;
                }
               
                if (Img1.ContentLength > 0 )
                {
                    string pathToSave1 = Path.Combine(Server.MapPath("~/Content/img"), Img1.FileName);
                    Img1.SaveAs(pathToSave1);
                    p.Img1 = Img1.FileName;
                }
                if (Img2.ContentLength > 0)
                {
                    string pathToSave2 = Path.Combine(Server.MapPath("~/Content/img"), Img2.FileName);
                    Img2.SaveAs(pathToSave2);
                    p.Img2 = Img2.FileName;
                }

                Prodotti.NewProd(p);
                return RedirectToAction("Index", "Admin");

            }
                return View();
        }

        public ActionResult Edit(int id)
        {
            Prodotti pro = new Prodotti();
            pro = Prodotti.DettaglioP(id);
            return View(pro);
        }

        [HttpPost]
        public ActionResult Edit(Prodotti p, HttpPostedFileBase Copertina, HttpPostedFileBase Img1, HttpPostedFileBase Img2)
        {
            if (ModelState.IsValid)
            {
                //if (Copertina.ContentLength > 0 || Img1.ContentLength > 0 || Img2.ContentLength > 0)
                //{

                //    string NomeC = Copertina.FileName;
                //    string Nome1 = Img1.FileName;
                //    string Nome2 = Img2.FileName;
                //    string pathToSave = Path.Combine(Server.MapPath("~/Content/img"), NomeC);
                //    string pathToSave1 = Path.Combine(Server.MapPath("~/Content/img"), Nome1);
                //    string pathToSave2 = Path.Combine(Server.MapPath("~/Content/img"), Nome2);

                //    Copertina.SaveAs(pathToSave);
                //    Img1.SaveAs(pathToSave1);
                //    Img2.SaveAs(pathToSave2);
                //}

                //p.FotoCopertina = Copertina.FileName;
                //p.Image1 = Img1.FileName;
                //p.Image2 = Img2.FileName;

                Prodotti.ModificaProd(p);
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Prodotti.Delete(id);
            return RedirectToAction("Index", "Admin");
        }
    }
}