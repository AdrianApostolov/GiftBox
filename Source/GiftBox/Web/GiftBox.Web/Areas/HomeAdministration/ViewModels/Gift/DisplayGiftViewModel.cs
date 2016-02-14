using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Children;
using Glimpse.Core.Extensions;

namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Gift
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DisplayGiftViewModel : IMapFrom<Gift>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string AditionalInfo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }

        [ScaffoldColumn(false)]
        public string ImageUrl { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool IsFulfilled { get; set; }

        [HiddenInput(DisplayValue = false)]
        public bool Claimed { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ClaimedBy { get; set; }
        
        public int? ChildId { get; set; }

        [UIHint("ChildrenDropDown")]
        public DisplayChildViewModel Child { get; set; }
        
        public int? EventCategoryId { get; set; }

        [UIHint("EventCategoryDropDown")]
        public DisplayEventCategoryViewModel EventCategory { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Gift, DisplayGiftViewModel>()
                .ForMember(m => m.ClaimedBy, opt => opt.MapFrom(x => x.ClaimedBy.UserName));
        }
    }
}