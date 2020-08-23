using Khanah.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Khanah.Api.Data
{
    public class QuotesDBContext : DbContext
    {
        public QuotesDBContext(DbContextOptions option):base(option)
        {            
        }
        public DbSet<Quote> Quotes { get; set; }
    }
}