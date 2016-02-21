using GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories;
using GiftBox.Web.ViewModels.Institution;

namespace GiftBox.Web.ViewModels.Need
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class NeedViewModel : IMapFrom<Need>
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int HomeId { get; set; }

        public virtual DetailsInstitutionViewModel Home { get; set; }

        public int NeedCategoryId { get; set; }

        public virtual DisplayNeedCategoryViewModel NeedCategory { get; set; }

        public string ImageUrl { get; set; }
    }
}