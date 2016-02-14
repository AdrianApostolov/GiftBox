
using System;

namespace GiftBox.Data.Models
{
    using System.Collections.Generic;
    using GiftBox.Data.Common.Models;

    public class Need : AuditInfo, IDeletableEntity
    {
        private ICollection<Comment> comments;

        public Need()
        {
            this.comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsFulFilled { get; set; }

        public int HomeId { get; set; }

        public virtual Home Home { get; set; }

        public int NeedCategoryId { get; set; }

        public virtual NeedCategory NeedCategory { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

    }
}
