using System;
using GiftBox.Data.Common.Models;

namespace GiftBox.Data.Models
{
    public class Comment : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int? NeedId { get; set; }

        public virtual Need Need { get; set; }

        public int? HomeId { get; set; }

        public virtual Home Home { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
