namespace GiftBox.Web.Infrastructure.Populators
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public interface IDropDownListPopulator
    {
        IEnumerable<SelectListItem> GetNeedCategories();

        IEnumerable<SelectListItem> GetEventCategories();
    }
}
