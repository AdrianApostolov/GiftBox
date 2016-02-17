using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using AutoMapper;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Children;

namespace GiftBox.Web.ViewModels.Gift
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class GiftViewModel : IMapFrom<Gift>, IHaveCustomMappings
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string AditionalInfo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime ExpirationDate { get; set; }

        public string ImageUrl { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string ClaimedBy { get; set; }

        public int ChildId { get; set; }

        public DisplayChildViewModel Child { get; set; }

        public string Category { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Gift, GiftViewModel>()
                .ForMember(g => g.Category, opt => opt.MapFrom(x => x.EventCategory.Name))
                .ForMember(m => m.ClaimedBy, opt => opt.MapFrom(x => x.ClaimedBy.UserName)); 
        }
    }
}