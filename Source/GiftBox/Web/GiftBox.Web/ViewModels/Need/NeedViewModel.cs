using System.Collections.Generic;
using AutoMapper;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;
using GiftBox.Web.ViewModels.Institution;

namespace GiftBox.Web.ViewModels.Need
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class NeedViewModel : IMapFrom<Need>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int HomeId { get; set; }

        public string HomeName { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }

        public string Address { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Need, NeedViewModel>()
                .ForMember(x => x.HomeName, opt => opt.MapFrom(x => x.Home.Name))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.NeedCategory.Name))
                .ForMember(x => x.Address, opt => opt.MapFrom(x => x.Home.Location.Address));
        }
    }
}