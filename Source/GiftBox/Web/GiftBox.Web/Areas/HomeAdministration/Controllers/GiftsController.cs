namespace GiftBox.Web.Areas.HomeAdministration.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using GiftBox.Common;
    using GiftBox.Data.Models;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Areas.HomeAdministration.ViewModels.Gift;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;

    public class GiftsController : Controller
    {
        private readonly IGiftService gifts;

        public GiftsController(IGiftService gifts)
        {
            this.gifts = gifts;
        }

        public ActionResult CreateGift([DataSourceRequest]DataSourceRequest request, IEnumerable<AddGiftViewModel> models)
        {
            var result = new List<AddGiftViewModel>();
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = AutoMapper.Mapper.Map<Gift>(model);
                    dbModel.ImageUrl = GlobalConstants.DefaultGiftPicture;
                    this.gifts.Add(dbModel);
                    result.Add(model);
                }

                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }

        public ActionResult UpdateGift([DataSourceRequest]DataSourceRequest request, IEnumerable<EditGiftViewModel> models)
        {
            if (this.ModelState.IsValid && models != null)
            {
                foreach (var model in models)
                {
                    var dbModel = this.gifts.GetById(model.Id);
                    Mapper.Map(model, dbModel);
                    this.gifts.Update(dbModel);
                    return this.Json(new[] { model }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
                }
            }

            return null;
        }

        public ActionResult DeleteGift([DataSourceRequest] DataSourceRequest request, IEnumerable<DisplayGiftViewModel> models)
        {
            var result = new List<DisplayGiftViewModel>();
            if (models != null)
            {
                foreach (var model in models)
                {
                    this.gifts.Delete(model.Id);
                    result.Add(model);
                }

                return this.Json(new[] { result }.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
            }

            return null;
        }
    }
}