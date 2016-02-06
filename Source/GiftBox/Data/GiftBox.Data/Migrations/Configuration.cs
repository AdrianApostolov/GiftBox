namespace GiftBox.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<GiftBoxDbContext>
    {
        public Configuration()
        {
            //TODO: Fix this
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(GiftBoxDbContext context)
        {
           
        }
    }
}
