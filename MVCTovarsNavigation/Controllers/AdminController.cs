using MVCTovarsNavigation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTovarsNavigation.Controllers
{
    public class AdminController : Controller
    {
        TovarContext tc = new TovarContext();
        // GET: Admin
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.ID_Producer = new SelectList(tc.Producers, "ID", "ProducerName");
            ViewBag.ID_Country = new SelectList(tc.Countries, "ID", "CountryName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(Tovar tovar)
        {
            tovar.Country = tc.Countries.Find(tovar.ID_Country);
            tovar.Producer = tc.Producers.Find(tovar.ID_Producer);
            /*tovar.ID_Country = tovar.Country.ID;
            tovar.ID_Producer = tovar.Producer.ID;*/
            tc.Tovars.Add(tovar);
            tc.SaveChanges();
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            tc.Tovars.Load();
            Tovar tovar = tc.Tovars.Find(id);
            if (tovar == null)
            {
                return HttpNotFound();
            }
            return View(tovar);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Tovar tovar = tc.Tovars.Find(id);
            if (tovar != null)
            {
                tc.Tovars.Remove(tovar);
                tc.SaveChanges();
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return HttpNotFound();
            Tovar tovar = tc.Tovars.Find(id);
            if (tovar != null)
            {
                ViewBag.ID_Producer = new SelectList(tc.Producers, "ID", "ProducerName", tovar.ID_Producer);
                ViewBag.ID_Country = new SelectList(tc.Countries, "ID", "CountryName", tovar.ID_Country);
                return View(tovar);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(Tovar tovar, string action)
        {
            if (action == "action_yes")
            {
                tovar.Producer = tc.Producers.Find(tovar.ID_Producer);
                tovar.Country = tc.Countries.Find(tovar.ID_Country);
                tc.Entry(tovar).State = EntityState.Modified;
                //tovar.ID_Producer = tovar.Producer.ID;
                //tovar.ID_Country = tovar.Country.ID;
                tc.SaveChanges();
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
        [HttpGet]
        public ActionResult Choose(int ID)
        {
            Tovar tovar = tc.Tovars.Find(ID);
            ViewBag.ProducerName = tc.Producers.Find(tovar.ID_Producer).ProducerName;
            ViewBag.CountryName = tc.Countries.Find(tovar.ID_Country).CountryName;
            return View(tovar);
        }
        [HttpPost]
        public ActionResult Choose()
        {
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }
    }
}