using System.ComponentModel.DataAnnotations;

namespace GiftBox.Data.Models
{
    using System;
    using System.Collections.Generic;
    using GiftBox.Data.Common.Models;

    public class Child : AuditInfo, IDeletableEntity
    {
        private ICollection<Gift> gifts;

        public Child()
        {
            this.gifts = new HashSet<Gift>();
        }
        
        public int Id { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public int HomeId { get; set; }

        public virtual Home Home { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<Gift> Gifts
        {
            get { return this.gifts; }
            set { this.gifts = value; }
        }
    }
}
