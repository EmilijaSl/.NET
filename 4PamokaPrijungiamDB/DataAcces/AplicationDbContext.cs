using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class AplicationDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        { 
        
        }
    }
}
