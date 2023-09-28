using Scarpe_co.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarpe_co.Controllers
{
    [Authorize]
    public class LoggedUserController : Controller
    {
        // GET: LoggedUser
        public ActionResult Index()
        {
            List<Prodotti> list = new List<Prodotti>();
            list = Prodotti.SelectAllP();

            return View(list);
        }

        public ActionResult Dettagli(int id)
        {
            Prodotti pro = new Prodotti();
            pro = Prodotti.DettaglioP(id);

            foreach (Prodotti p in Prodotti.SelectAllP())
            {
                if (p.Id == id)
                {
                    pro = p;
                }
            }
            return View(pro);
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie(".ASPXAUTH");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
    }
}