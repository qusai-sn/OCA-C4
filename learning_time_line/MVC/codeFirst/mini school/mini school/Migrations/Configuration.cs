namespace mini_school.Migrations
{
    using mini_school.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<mini_school.Models.SchoolDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(mini_school.Models.SchoolDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.  
            context.Subjects.AddOrUpdate(
                new Subject { Name = "Mathematics" },
                new Subject { Name = "Science" },
                new Subject { Name = "History" }
            );
        }
       

    }
}
