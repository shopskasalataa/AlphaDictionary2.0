using Data.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace Data
{
    public class WordsContext : DbContext
    {
        public WordsContext() 
        {

        }

        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>().ToTable("Word");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string conString = "Server=(localdb)\\mssqllocaldb;Database=AlphaDictionary;ConnectRetryCount=0;Trusted_Connection=True;MultipleActiveResultSets=true"; 
                optionsBuilder.UseSqlServer(conString);
            }
        }
    }
}
