using System;

namespace GiftBox.Data.Models
{
    using System.Collections.Generic;
    using GiftBox.Data.Common.Models;

    public class Child : AuditInfo, IDeletableEntity
    {
        public Child()
        {
            this.gifts = new HashSet<Gift>();
        }

        private ICollection<Gift> gifts;

        public int Id { get; set; }

        public string Name { get; set; }

        public int  Age { get; set; }

        public int HomeId { get; set; }

        public virtual Home Home { get; set; }

        public bool IsFulFilled { get; set; }

        public string ImageUrl { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public string AccountHolder { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Gift> Gifts
        {
            get { return this.gifts; }
            set { this.gifts = value; }
        }
    }
}
