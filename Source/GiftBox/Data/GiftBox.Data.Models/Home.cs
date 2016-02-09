﻿namespace GiftBox.Data.Models
{
    using System.Collections.Generic;

    public class Home
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

        public string HomeAdministratorId { get; set; }

        public virtual User HomeAdministrator { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactInfo { get; set; }

        public bool IsApproved { get; set; }

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