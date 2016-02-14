namespace GiftBox.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using GiftBox.Data.Contracts;
    using GiftBox.Data.Models;
    using GiftBox.Data.Common.Models;

    using Microsoft.AspNet.Identity.EntityFramework;

    public class GiftBoxDbContext : IdentityDbContext<User>, IGiftBoxDbContext
    {
        public GiftBoxDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false; 
        }
        
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public static GiftBoxDbContext Create()
        {
            return new GiftBoxDbContext();
        }

        public virtual IDbSet<Child> Children { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<EventCategory> EventCategorys { get; set; }

        public virtual IDbSet<Gift> Gifts { get; set; }

        public virtual IDbSet<Home> Homes { get; set; }

        public virtual IDbSet<Location> Locations { get; set; }

        public virtual IDbSet<Need> Needs { get; set; }

        public virtual IDbSet<NeedCategory> NeedCategorys { get; set; }


        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            this.ApplyDeletableEntityRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        private void ApplyDeletableEntityRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (
                var entry in
                    this.ChangeTracker.Entries()
                        .Where(e => e.Entity is IDeletableEntity && (e.State == EntityState.Deleted)))
            {
                var entity = (IDeletableEntity)entry.Entity;

                entity.DeletedOn = DateTime.Now;
                entity.IsDeleted = true;
                entry.State = EntityState.Modified;
            }
        }
    }
}
