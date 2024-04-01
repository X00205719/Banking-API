using BankingApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BankingApi
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
