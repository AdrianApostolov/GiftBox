namespace GiftBox.Web.Areas.Administration.ViewModels.Base
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class AdministrationViewModel
    {
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy H:mm:ss}")]
        public DateTime CreatedOn { get; set; }
        
        [HiddenInput(DisplayValue = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy H:mm:ss}")]
        public DateTime? ModifiedOn { get; set; }
    }
}