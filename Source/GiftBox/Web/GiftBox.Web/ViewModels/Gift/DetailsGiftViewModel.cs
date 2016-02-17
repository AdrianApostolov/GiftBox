namespace GiftBox.Web.ViewModels.Gift
{
    using System;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Web.ViewModels.Account;
    using GiftBox.Web.ViewModels.Child;

    public class DetailsGiftViewModel : IMapFrom<Gift>
    {
        public int Id { get; set; }

        public string AditionalInfo { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string ImageUrl { get; set; }

        public virtual UserViewModel ClaimedBy { get; set; }

        public virtual DisplayChildViewModel Child { get; set; }

        public int EventCategoryId { get; set; }

        public virtual EventCategory EventCategory { get; set; }
    }
}