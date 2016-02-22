namespace GiftBox.Web.Areas.Administration.ViewModels.Needs
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using AutoMapper;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Needs;
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Web.Areas.Administration.ViewModels.Base;

    public class AdministrationNeedViewModel : AdministrationViewModel, IMapFrom<Need>
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public string Description { get; set; }

        public bool IsFulFilled { get; set; }

        [Display(Name = "Home Name")]
        public string HomeName { get; set; }
        
        public string ImageUrl { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Need, DisplayNeedViewModel>()
                .ForMember(m => m.HomeName, opt => opt.MapFrom(x => x.Home.Name));
        }
    }
}