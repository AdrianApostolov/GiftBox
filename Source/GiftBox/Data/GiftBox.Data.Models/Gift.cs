namespace GiftBox.Data.Models
{
    using System;

    public class Gift
    {
        public int Id { get; set; }

        public string AditionalInfo { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFulfilled { get; set; }

        public bool Claimed { get; set; }

        public string CalimedById { get; set; } 

        public virtual User CalimedBy { get; set; }

        public  int ChildId { get; set; }

        public virtual Child Child { get; set; }
    }
}
