namespace GiftBox.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using GiftBox.Data.Common.Models;

    public class Home : AuditInfo, IDeletableEntity
    {
        private ICollection<Comment> comments;
        private ICollection<Child> children;
        private ICollection<Need> needs;

        public Home()
        {
            this.comments = new HashSet<Comment>();
            this.children = new HashSet<Child>();
            this.needs = new HashSet<Need>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        public string HomeAdministratorId { get; set; }

        public virtual User HomeAdministrator { get; set; }

        public string ImageUrl { get; set; }

        public virtual Location Location { get; set; }

        [Required]
        public string AditionalInfo { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be exactly 10 digits. ")]
        public string PhoneNumber { get; set; }

        [Required]
        public string ContactInfo { get; set; }

        public bool IsApproved { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Child> Children
        {
            get { return this.children; }
            set { this.children = value; }
        }

        public virtual ICollection<Need> Needs
        {
            get { return this.needs; }
            set { this.needs = value; }
        }
    }
}
