using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTovarsNavigation.Models
{
    public class IndexViewModel
    {
        public List<Tovar> Tovars { get; set; }

        public SelectList Producers { get; set; }
        public SelectList Countries { get; set; }

        public int producer_id { get; set; }
        public int country_id { get; set; }

        public PageInfo PageInfo { get; set; }
    }
}