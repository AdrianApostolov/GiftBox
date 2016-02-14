namespace GiftBox.Web.Areas.HomeAdministration.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    using GiftBox.Data.Models;
    using GiftBox.Web.Infrastructure.Mapping;

    public class DisplayEventCategoryViewModel : IMapFrom<EventCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}