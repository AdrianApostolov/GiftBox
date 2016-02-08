namespace GiftBox.Web.ViewModels.Account
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        public string ImageUrl { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Joined on")]
        public DateTime CreatedOn { get; set; }

        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
        
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}