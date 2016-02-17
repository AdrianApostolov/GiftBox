using GiftBox.Web.ViewModels.Institution;

namespace GiftBox.Web.ViewModels.Child
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DisplayChildViewModel : IMapFrom<Child>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int HomeId { get; set; }

        public virtual DetailsInstitutionViewModel Home { get; set; }

        public string ImageUrl { get; set; }
    }
}