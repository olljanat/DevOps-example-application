namespace DataService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataService.ExampleAppModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

            // Source: http://stackoverflow.com/questions/36024400/migratedatabasetolatestversion-no-running-seed-method
            // Check if there are migrations pending to run, this can happen if database doesn't exists or if there was any
            //  change in the schema
            var migrator = new DbMigrator(this);
            var _pendingMigrations = migrator.GetPendingMigrations().Any();

            // If there are pending migrations run migrator.Update() to create/update the database then run the Seed() method to populate
            //  the data if necessary
            if (_pendingMigrations)
            {
                migrator.Update();
                Seed(new DataService.ExampleAppModel());
            }
        }

        protected override void Seed(DataService.ExampleAppModel context)
        {
            context.Companies.AddOrUpdate(x => x.CompanyId,
                new CompanyEntity() { CompanyId = 1, CompanyName = "Example company 1" },
                new CompanyEntity() { CompanyId = 2, CompanyName = "Example company 2" },
                new CompanyEntity() { CompanyId = 3, CompanyName = "Example company 3" }
            );

            context.People.AddOrUpdate(x => x.PersonId,
                new PersonEntity() { PersonId = 1, CompanyId = 1, FirstName = "Michael", LastName = "Newton" },
                new PersonEntity() { PersonId = 2, CompanyId = 1, FirstName = "Chris", LastName = "Bell" },
                new PersonEntity() { PersonId = 3, CompanyId = 2, FirstName = "Amy", LastName = "Canty" },
                new PersonEntity() { PersonId = 4, CompanyId = 2, FirstName = "John", LastName = "Daugherty" },
                new PersonEntity() { PersonId = 5, CompanyId = 3, FirstName = "Maria", LastName = "York" },
                new PersonEntity() { PersonId = 6, CompanyId = 3, FirstName = "Ellsworth", LastName = "Webber" }
            );
        }
    }
}
