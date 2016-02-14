using AutoMapper;

namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Gift
{
    using System;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class AddGiftViewModel : IMapFrom<Gift>, IHaveCustomMappings
    {
        public string AditionalInfo { get; set; }

        public virtual Child Child { get; set; }

        public virtual EventCategory EventCategory { get; set; }

        public DateTime ExpirationDate { get; set; }

        public bool IsFulfilled { get; set; }

        public bool Claimed { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddGiftViewModel, Gift>()
                .ForMember(g => g.ChildId, opt => opt.MapFrom(x => x.Child.Id))
                .ForMember(g => g.EventCategoryId, opt => opt.MapFrom(x => x.EventCategory.Id));
        }
    }
}