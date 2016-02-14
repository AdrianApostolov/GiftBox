namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories
{
    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DisplayNeedCategoryViewModel : IMapFrom<NeedCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}