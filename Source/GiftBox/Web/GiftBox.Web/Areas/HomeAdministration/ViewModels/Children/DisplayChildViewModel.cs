namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Children
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
using AutoMapper;
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DisplayChildViewModel : IMapFrom<Child>, IHaveCustomMappings
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [Display(Name = "Home Name")]
        [HiddenInput(DisplayValue = false)]
        public string HomeName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int HomeId { get; set; }

        public string Name { get; set; }
    
        public int Age { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Child, DisplayChildViewModel>()
                .ForMember(m => m.HomeName, opt => opt.MapFrom(x => x.Home.Name));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}