using System.Data.Entity;
using System.Linq;
using GiftBox.Common;
using GiftBox.Web.Infrastructure.Populators;
using GiftBox.Web.ViewModels.Gift;
using GiftBox.Web.Views.Categories;

namespace GiftBox.Web.Controllers
{
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.ViewModels.Need;

    public class NeedController : BaseController
    {
        private readonly INeedService needs;
        private readonly IDropDownListPopulator populator;

        public NeedController(IUsersService users, INeedService needs, IDropDownListPopulator populator)
            : base(users)
        {
            this.needs = needs;
            this.populator = populator;
        }

        [HttpGet]
        public ActionResult All()
        {
          var allNeeds = this.needs
                .GetAll()
                .ProjectTo<NeedViewModel>();

            return this.View(allNeeds);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Incorrect route parameters, id cannot be null");
            }

            var need = this.needs.GetAll()
                .Include(x => x.Home)
                .Include(x => x.Home.Location)
                .Include(x => x.NeedCategory)
                .FirstOrDefault(x => x.Id == id);

            var model = AutoMapper.Mapper.Map<NeedViewModel>(need);

            if (need == null)
            {
                throw new HttpException(404, "Need does not exist");
            }

            return this.View(model);
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult GetNeedCategoriesPartial()
        {
            var viewModel = new ListNeedCategoryViewModel
            {
                Categories = this.populator.GetNeedCategories()
            };

            return this.PartialView(GlobalConstants.NeedsCategoriesListPartial, viewModel);
        }

        [HttpGet]
        public ActionResult FilterByNeedCategory(int categoryId)
        {
            var allGiftsByCategory = this.needs
               .GetAll()
               .ProjectTo<NeedViewModel>();

            if (categoryId > -1)
            {
                allGiftsByCategory = this.needs
               .GetAll()
               .Where(x => x.NeedCategoryId == categoryId)
               .ProjectTo<NeedViewModel>();
            }

            return this.PartialView(GlobalConstants.ListNeedsPartial, allGiftsByCategory);
        }
    }
}