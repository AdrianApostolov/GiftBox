namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Children
{
    using System.ComponentModel.DataAnnotations;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class AddChildViewModel : IMapFrom<Child>
    {
        [Required]
        [StringLength(50)]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [Range(0, 100)]
        public int Age { get; set; }
    }
}