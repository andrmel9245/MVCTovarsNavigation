using MVCTovarsNavigation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTovarsNavigation.Controllers
{
    public class HomeController : Controller
    {
        public int pageSize { get; set; }

        public TovarContext TC { get; set; }
        public HomeController()
        {
            TC = new TovarContext();
            pageSize = 3;

            var d = TC.Tovars.ToList();
            foreach(var z in d)
            {
                z.Country = TC.Countries.Find(z.ID_Country);
                z.Producer = TC.Producers.Find(z.ID_Producer);
                TC.Entry(z).State = EntityState.Modified;
                TC.SaveChanges();
            }
        }

        // GET: Home
        /*[HttpGet]
        public ActionResult Index(int id = 0)
        {
            //хотів виймати з Url в Index.cshtml але були помилки тому просто додав у VievData;
            ViewData.Add("id", id);
            return View();
        }

        [HttpPost]
        public ActionResult Index(object id)
        {
            //Request.Params.Add("id", ((int)id).ToString());
            return View();
        }*/

        public ActionResult Index(int producer = 0, int country = 0, string name = "", int page = 1)
        {
            //List<Phone> phones_for_page = phones.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            List<Tovar> tovars_for_page = TC.Tovars.ToList();

            if (producer != 0)
            {
                tovars_for_page = tovars_for_page.Where(p => p.Producer.ID == producer).ToList();
            }

            if(name != "")
            {
                tovars_for_page = tovars_for_page.Where(n => n.Name.Contains(name)).ToList();
            }

            if (country != 0)
            {
                tovars_for_page = tovars_for_page.Where(p => p.Country.ID == country).ToList();
            }

            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = tovars_for_page.Count };

            tovars_for_page = tovars_for_page.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            List<Producer> for_view_producers = TC.Producers.ToList();
            for_view_producers.Insert(0, new Producer { ID = 0, ProducerName = "Всі" });

            List<Country> for_view_countries = TC.Countries.ToList();
            for_view_countries.Insert(0, new Country { ID = 0, CountryName = "Всі" });


            IndexViewModel ivm = new IndexViewModel
            {
                Tovars = tovars_for_page,
                Producers = new SelectList(for_view_producers, "ID", "ProducerName"),
                Countries = new SelectList(for_view_countries, "ID", "CountryName"),
                producer_id = producer,
                country_id = country,
                PageInfo = pageInfo
            };

            return View(ivm);
        }

        //public ActionResult Index(int page = 1)
        //{

        //    List<Phone> phones_for_page = phones.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = phones.Count };
        //    IndexViewModel ivm = new IndexViewModel { PageInfo = pageInfo, Phones = phones_for_page };
        //    return View(ivm);
        //}
    }
}