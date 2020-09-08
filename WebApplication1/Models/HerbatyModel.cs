using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class HerbatyModel
    {
        // model do bazy danych
        public int ID { get; set; }
        public string Nazwa { get; set; }
        public string Cena { get; set; }
        public string Zdjęcie { get; set; }

    }

    public class HerbataDBContext : DbContext
    {
        public DbSet<HerbatyModel> Herbaty { get; set; }
    }
}