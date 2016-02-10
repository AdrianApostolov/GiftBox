namespace GiftBox.Data.Models
{
    using  System;
    using GiftBox.Data.Common.Models;

    public class Location : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
