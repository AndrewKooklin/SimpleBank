using SimpleBank.Model;
using SQLite.CodeFirst;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Linq;

namespace SimpleBank.Data
{
    public class SimpleBankContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<SalaryAccount> SalaryAccounts { get; set; }

        public DbSet<DepositAccount> DepositAccounts { get; set; }

        public SimpleBankContext() : base("SimpleBankConnectionSQLite") 
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var sqLiteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SimpleBankContext>(modelBuilder);

            Database.SetInitializer(sqLiteConnectionInitializer);

            //var model = modelBuilder.Build(Database.Connection);
            //ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            //string sql = sqlGenerator.Generate(model.StoreModel);

            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //base.OnModelCreating(modelBuilder);
        }

        //private static bool _created = false;

        //public string path = @".\SimpleBank.db";

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite($"Data Source = {path}");
        //}
    }
}
