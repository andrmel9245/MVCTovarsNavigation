using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCTovarsNavigation.Models
{
    public class Tovar
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Назва товару")]
        [DataType(DataType.Text)]
        //[RegularExpression(@"^[a-zA-Z][a-zA-Z\\s]+$", ErrorMessage = "Не допустимі символи")]
        public string Name { get; set; }
        [Display(Name = "Ціна товару за 1 шт.")]
        [DataType(DataType.Currency, ErrorMessage = "Введіть ціну!")]
        public decimal Prize { get; set; }
        [Display(Name = "Кількість товару на складі")]
        public int Quantity { get; set; }
        [Display(Name = "Опис товару")]
        [DataType(DataType.Text, ErrorMessage = "Введіть опис товару")]
        public string Desc { get; set; }

        [ForeignKey("Producer")]
        [Display(Name = "Виробник")]
        public int ID_Producer { get; set; }
        public Producer Producer { get; set; }
        
        [ForeignKey("Country")]
        [Display(Name = "Країна")]
        public int ID_Country { get; set; }
        public Country Country { get; set; }
    }
    public class Producer
    {
        public int ID { get; set; }
        [Display(Name = "Назва виробника")]
        [DataType(DataType.Text, ErrorMessage = "Назва має бути текстом!")]
        public string ProducerName { get; set; }
        public List<Tovar> Tovars{ get; set; }
    }

    public class Country
    {
        public int ID { get; set; }
        [Display(Name = "Назва країни")]
        [DataType(DataType.Text, ErrorMessage = "Назва має бути текстом!")]
        public string CountryName { get; set; }
        public List<Tovar> Tovars{ get; set; }
    }
}
