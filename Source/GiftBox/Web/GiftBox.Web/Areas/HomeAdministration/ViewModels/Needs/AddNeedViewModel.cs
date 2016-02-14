using AutoMapper;

namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Needs
{
    using GiftBox.Data.Models;
    using System.ComponentModel.DataAnnotations;
    using GiftBox.Web.Infrastructure.Mapping;

    public class AddNeedViewModel : IMapFrom<Need>, IHaveCustomMappings
    {
        [Required]
        public string Description { get; set; }

        public bool IsFulFilled { get; set; }

        public int HomeId { get; set; }

        public virtual NeedCategory NeedCategory { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<AddNeedViewModel, Need>()
                .ForMember(g => g.NeedCategoryId, opt => opt.MapFrom(x => x.NeedCategory.Id));
        }
    }
}