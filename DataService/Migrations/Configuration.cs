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
            AutomaticMigrationsEnabled = false;
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
