namespace GiftBox.Data
{
    using GiftBox.Data.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class GiftBoxDbContext : IdentityDbContext<User>
    {
        public GiftBoxDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static GiftBoxDbContext Create()
        {
            return new GiftBoxDbContext();
        }
    }
}
