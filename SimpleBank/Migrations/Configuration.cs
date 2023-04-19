using SimpleBank.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SQLite.EF6.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBank.Migrations
{
    public class Configuration : DbMigrationsConfiguration<SimpleBankContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
        }

        protected override void Seed(SimpleBankContext context)
        {
            //base.Seed(context);
        }
    }
}
