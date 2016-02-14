using GiftBox.Services.Data.Contracts;

namespace GiftBox.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using GiftBox.Data.Contracts;
    using GiftBox.Web.Infrastructure.Caching;

    public class DropDownListPopulator : IDropDownListPopulator
    {
        private ICategoryService categories;
        private ICacheService cache;

        public DropDownListPopulator(ICategoryService categories, ICacheService cache)
        {
            this.categories = categories;
            this.cache = cache;
        }

        public IEnumerable<SelectListItem> GetNeedCategories()
        {
            var needCategories = this.cache.Get<IEnumerable<SelectListItem>>(
                "needCategories",
                () =>
                {
                    var categoriesList = new List<SelectListItem>
                    {
                          { 
                              new SelectListItem { Text = "Select category", Value = "-1", Selected = true } 
                          },
                    };

                    categoriesList.AddRange(this.categories.GetNeedCategories()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       }));

                    return categoriesList;
                });

            return needCategories;
        }

        public IEnumerable<SelectListItem> GetEventCategories()
        {
            var eventsCategories = this.cache.Get<IEnumerable<SelectListItem>>(
                "eventCategories",
                () =>
                {
                    var categoriesList = new List<SelectListItem>
                    {
                          {
                              new SelectListItem { Text = "Select category", Value = "-1", Selected = true }
                          },
                    };

                    categoriesList.AddRange(this.categories.GetEventCategories()
                       .Select(c => new SelectListItem
                       {
                           Value = c.Id.ToString(),
                           Text = c.Name
                       }));

                    return categoriesList;
                });

            return eventsCategories;
        }
    }
}