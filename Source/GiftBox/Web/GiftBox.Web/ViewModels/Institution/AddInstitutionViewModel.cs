using AutoMapper;

namespace GiftBox.Web.ViewModels.Institution
{
    using System.ComponentModel.DataAnnotations;

    using GiftBox.Web.Infrastructure.Mapping;
    using GiftBox.Data.Models;

    public class AddInstitutionViewModel : IMapFrom<Home>
    { 
    
        public int Id { get; set; }
        
        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        public LocationViewModel Location { get; set; }

        [Required]
        public string AditionalInfo { get; set; }

        [Required]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "The phone number must be exactly 10 digits. ")]
        public string PhoneNumber { get; set; }

        [Required]
        public string ContactInfo { get; set; }
    }
}