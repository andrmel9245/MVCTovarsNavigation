using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCTovarsNavigation.Models
{
    public class TovarContext : DbContext
    {
        public DbSet<Tovar> Tovars { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public TovarContext() : base("TovarsConnection") { }

        static TovarContext()
        {
            Database.SetInitializer(new TovarInit());
        }
    }

    public class TovarInit : DropCreateDatabaseIfModelChanges<TovarContext>
    {
        protected override void Seed(TovarContext context)
        {
            Producer producer = new Producer { ProducerName = "CVQ" };
            Producer producer1 = new Producer { ProducerName = "CBT" };
            Producer producer2 = new Producer { ProducerName = "CQC" };
            Producer producer3 = new Producer { ProducerName = "Premail" };
            Producer producer4 = new Producer { ProducerName = "DDS" };

            Country country = new Country { CountryName = "Ukraine" };
            Country country1 = new Country { CountryName = "England" };
            Country country2 = new Country { CountryName = "Japan" };
            Country country3 = new Country { CountryName = "Taiwan" };

            Tovar tovar = new Tovar { Name = "Miss", Prize = 2453.5M, Quantity = 15, Desc = "CheckTovar", Country = country, Producer = producer };

            Tovar tovar1 = new Tovar { Name = "Choko", Prize = 23.2M, Quantity = 30, Desc = "GG", Country = country2, Producer = producer };

            Tovar tovar2 = new Tovar { Name = "Check", Prize = 50.5M, Quantity = 10, Desc = "EQE", Producer = producer4, Country = country2 };

            Tovar tovar3 = new Tovar { Name = "Milk", Prize = 70M, Quantity = 40, Desc = "ZCS", Country = country2, Producer = producer2 };
            
            Tovar tovar4 = new Tovar { Name = "NameTovarHere", Prize = 35.2M, Quantity = 9, Desc = "Опис товару тут", Country = country3, Producer = producer2 };
            
            Tovar tovar5 = new Tovar { Name = "Майонез (ВВ)", Prize = 35.2M, Quantity = 8, Desc = "Робочий товар", Country = country3, Producer = producer1 };
            
            Tovar tovar6 = new Tovar { Name = "Кетчуп (ВВ)", Prize = 27.5M, Quantity = 10, Desc = "Дуже гострий", Country = country3, Producer = producer1 };
            
            Tovar tovar7 = new Tovar { Name = "Серветки (10 шт.)", Prize = 15.5M, Quantity = 35, Desc = "Білі", Country = country, Producer = producer4 };

            Tovar tovar8 = new Tovar { Name = "Мокрі Серветки (10 шт.)", Prize = 20.5M, Quantity = 35, Desc = "Білі", Country = country2, Producer = producer4 };
            
            Tovar tovar9 = new Tovar { Name = "YYY", Prize = 40M, Quantity = 10, Desc = "YYYY", Producer = producer, Country = country2 };

            context.Producers.Add(producer);
            context.Producers.Add(producer1);
            context.Producers.Add(producer2);
            context.Producers.Add(producer3);
            context.Producers.Add(producer4);
            context.SaveChanges();

            context.Countries.Add(country);
            context.Countries.Add(country1);
            context.Countries.Add(country2);
            context.Countries.Add(country3);
            context.SaveChanges();

            context.Tovars.Add(tovar);
            context.Tovars.Add(tovar1);
            context.Tovars.Add(tovar2);
            context.Tovars.Add(tovar3);
            context.Tovars.Add(tovar4);
            context.Tovars.Add(tovar5);
            context.Tovars.Add(tovar6);
            context.Tovars.Add(tovar7);
            context.Tovars.Add(tovar8);
            context.Tovars.Add(tovar9);
            context.SaveChanges();

            var d = context.Tovars.ToList();

            base.Seed(context);
        }
    }

}