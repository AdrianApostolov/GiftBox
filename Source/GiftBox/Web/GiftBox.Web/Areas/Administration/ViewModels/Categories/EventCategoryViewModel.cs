namespace GiftBox.Web.Areas.Administration.ViewModels.Categories
{
    using GiftBox.Web.Areas.Administration.ViewModels.Base;
    using GiftBox.Web.Infrastructure.Mapping;

    public class EventCategoryViewModel : AdministrationViewModel, IMapFrom<Data.Models.EventCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}