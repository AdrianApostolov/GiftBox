namespace GiftBox.Data.Models
{
    using System;
    using GiftBox.Data.Common.Models;

    public class NeedCategory : AuditInfo, IDeletableEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
