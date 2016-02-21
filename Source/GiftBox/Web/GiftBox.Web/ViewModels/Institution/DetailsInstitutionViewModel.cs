namespace GiftBox.Web.ViewModels.Institution
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DetailsInstitutionViewModel : IMapFrom<Home>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual User HomeAdministrator { get; set; }

        public string ImageUrl { get; set; }

        public int LocationId { get; set; }

        public Location Location { get; set; }

        public string AditionalInfo { get; set; }

        public string PhoneNumber { get; set; }

        public string ContactInfo { get; set; }
    }
}