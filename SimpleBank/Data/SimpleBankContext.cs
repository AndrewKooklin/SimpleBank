using Microsoft.EntityFrameworkCore;
using SimpleBank.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBank.Data
{
    public class SimpleBankContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<SalaryAccount> SalaryAccounts { get; set; }

        public DbSet<DepositAccount> DepositAccounts { get; set; }

        private static bool _created = false;

        public SimpleBankContext()// : base("SimpleBankConnectionSQLite") 
        {
            //if (!_created)
            //{
            //    //Database.Delete();
            //    Database.CreateIfNotExists();
            //    _created = true;
            //}
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var sqLiteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<SimpleBankContext>(modelBuilder);

        //    Database.SetInitializer(sqLiteConnectionInitializer);

        //    var model = modelBuilder.Build(Database.Connection);
        //    ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
        //    string sql = sqlGenerator.Generate(model.StoreModel);
        //}
    }
}
