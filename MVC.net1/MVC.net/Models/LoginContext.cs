using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC.net.Models
{
    public class LoginContext : DbContext
    {
        public DbSet<Mirsham> Mirshams { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Med> Med { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Pharma> Pharma { get; set; }


        public LoginContext() : base("LoginContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<LoginContext>());
        }

       
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
