using Microsoft.EntityFrameworkCore;
using CaseStudy.Models;

namespace CaseStudy.Data
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options)
            : base(options)
        {
        }

        public DbSet<CreditCards> CreditCards { get; set; }


    }
}


