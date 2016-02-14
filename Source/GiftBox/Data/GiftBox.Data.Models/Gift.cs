namespace GiftBox.Data.Models
{
    using System;
    using GiftBox.Data.Common.Models;

    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Gift : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string AditionalInfo { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFulfilled { get; set; }

        public bool Claimed { get; set; }

        public string ClaimedById { get; set; } 

        public virtual User ClaimedBy { get; set; }

        public int ChildId { get; set; }

        public virtual Child Child { get; set; }

        public int EventCategoryId { get; set; }

        public virtual EventCategory EventCategory { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
