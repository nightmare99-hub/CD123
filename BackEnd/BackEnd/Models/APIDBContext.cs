using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class APIDBContext : DbContext 
    {
        public APIDBContext(DbContextOptions<APIDBContext> options) : base(options)
        {

        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<AnimeType> AnimeTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Viewer> Viewers { get; set; }
        public DbSet<New> News { get; set; }
    }
}
