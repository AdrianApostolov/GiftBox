namespace GiftBox.Data.Models
{
    using System.Collections.Generic;

    public class Need
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

        public string ImageUrl { get; set; }

        public string IBAN { get; set; }

        public string BIC { get; set; }

        public string AccountHolder { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        } 
    }
}
