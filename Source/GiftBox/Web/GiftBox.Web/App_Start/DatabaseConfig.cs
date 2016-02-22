using System.Data.Entity;
using GiftBox.Data;
using GiftBox.Data.Migrations;

namespace GiftBox.Web
{
    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GiftBoxDbContext, Configuration>());
            GiftBoxDbContext.Create().Database.Initialize(true);
        }
    }
}