using ConsoleApp31.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp31.data
{
    internal class appdbcontext:DbContext
    {
        private object assembly;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;Database=efiti;Trusted_connection=True;Encrypt=false;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<student> students { get; set; }
        public DbSet<department> department { get; set; }
        public DbSet<instructor> instructors { get; set; }
        public DbSet<course> course { get; set; }
        public DbSet<topic> topic { get; set; }

    }
}
