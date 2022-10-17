using FullStackDomain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullStackDAL
{
    public class FullStackDbContext : DbContext //db kontekstas leis is C# kodo per entity frameworka pasiquerinti duomenu baze.
                                                //Atspindes kokia duombazes struktura is aplikacijos puses. Kokios db bus lenteles.
                                                //Kviesdami db propercius galesime pasiekti viena ar kita lentele.
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        //kad galetume prisijungti prie db mum reikia connection stringo
        //jis turi nukeliauti i entity framework ir tai ivyksta kai iskvieciam konstruktoriu DbContext options
        public DbSet<ContactDetail> Contacts { get; set; }
        public FullStackDbContext(DbContextOptions options) : base(options)
        { 
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
           modelBuilder
                .Entity<ContactDetail>()
                .Property(p=>p.Type)
                .HasConversion(
            c=>c.ToString(),
            c=>(ContactType)Enum.Parse(typeof(ContactType), c));    
        }
}

    }

