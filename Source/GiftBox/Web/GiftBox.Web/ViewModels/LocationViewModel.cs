namespace GiftBox.Web.ViewModels
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class LocationViewModel : IMapFrom<Location>
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostCode { get; set; }

        public string Address { get; set; }
    }
}