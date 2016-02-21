namespace GiftBox.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Country { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string City { get; set; }

        [Required]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Address { get; set; }
    }
}