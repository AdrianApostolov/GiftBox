using AutoMapper;
using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;

namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Needs
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class DisplayNeedViewModel : IMapFrom<Need>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsFulFilled { get; set; }

        [Display(Name = "Home Name")]
        [HiddenInput(DisplayValue = false)]
        public string HomeName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int HomeId { get; set; }

         public int? NeedCategoryId { get; set; }

        [UIHint("NeedCategoryDropDown")]
        public DisplayNeedCategoryViewModel NeedCategory { get; set; }
        
        public string ImageUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Need, DisplayNeedViewModel>()
                .ForMember(m => m.HomeName, opt => opt.MapFrom(x => x.Home.Name));
        }
    }
}