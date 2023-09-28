using Scarpe_co.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Scarpe_co.Controllers
{
    public class HomeController : Controller
    {
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

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Utenti u)
        {
            if (ModelState.IsValid)
            {
                List<Utenti> list = Utenti.AllUser();

                foreach (Utenti p in list)
                {

                    if (u.Username == p.Username && u.Password == p.Password)
                    {
                        FormsAuthentication.SetAuthCookie(u.Username, true);
                        if(u.Username!= "admin")
                        {
                        return RedirectToAction("Index","LoggedUser");

                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                    }
                }

            }
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = new HttpCookie("Admin");
            cookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(cookie);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Utenti u)
        {
            if (ModelState.IsValid)
            {
                    
                    Utenti.AddUser(u);
                
                return RedirectToAction("Login");
            }
            return View();
        }

    }
}

