namespace GiftBox.Web.Views.Categories
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class ListNeedCategoryViewModel
    {
        [Key]
        [UIHint("DropDownList")]
        public int CategoryId { get; set; }

        public string Name { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}