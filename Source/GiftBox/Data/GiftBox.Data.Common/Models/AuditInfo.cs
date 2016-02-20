namespace GiftBox.Data.Common.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class AuditInfo : IAuditInfo
    {
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        /// <value>
        /// A value indicating whether specifies whether or not the CreatedOn property should be automatically set.
        /// </value>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
