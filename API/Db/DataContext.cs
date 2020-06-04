using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Db
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Quote>().HasData(
                 new Quote
                 {
                     Id = 1,
                     Text = "Шел Грек через реку",
                     Author = "Native",
                     Date = DateTime.Parse("15.10.2020")
                 },
                    new Quote
                    {
                        Id = 2,
                        Text = "Бери всё и ничего не отдавай",
                        Author = "Джек Воробей",
                        Date = DateTime.Parse("02.11.1890")
                    },
                    new Quote
                    {
                        Id = 3,
                        Text = "Надо любить жизнь больше, чем смысл жизни.",
                        Author = "Достоевский",
                        Date = DateTime.Parse("06.06.1890")
                    },
                    new Quote
                    {
                        Id = 4,
                        Text = "Элементарно, Ватсон",
                        Author = "Шерлок Холмс",
                        Date = DateTime.Parse("25.05.1800")
                    },
                    new Quote
                    {
                        Id = 5,
                        Text = "Неосмысленная жизнь не стоит того, чтобы жить.",
                        Author = "Сократ",
                        Date = DateTime.Parse("1.1.1100")
                    }
                    );
        }
    }
}
