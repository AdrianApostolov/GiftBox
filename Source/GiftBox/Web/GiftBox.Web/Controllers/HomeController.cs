namespace GiftBox.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using GiftBox.Common;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Infrastructure.HtmlHelpers;
    using GiftBox.Web.ViewModels.Institution;
    using GiftBox.Web.Infrastructure.Caching;

    using PagedList;

    public class HomeController : BaseController
    {
        private readonly IHomeService homes;
        private readonly ICacheService cache;

        public HomeController(IUsersService users, IHomeService homes, ICacheService cache)
            : base(users)
        {
            this.homes = homes;
            this.cache = cache;
        }

        [HttpGet]
        public ActionResult Index(string searchInput, string currentFilter, int? page)
        {
            var allHomes = this.cache.Get("allHomes", () => this.homes.GetAllApproved(), 60*15);

            if (string.IsNullOrEmpty(searchInput))
            {
                searchInput = currentFilter;
            }
            else
            {
                page = 1;
            }

            allHomes = FilterHelper.FilterSearchString(searchInput, allHomes);

            this.ViewBag.CurrentFilter = searchInput;

            var viewModel = allHomes
                .OrderBy(x => x.CreatedOn)
                .ProjectTo<DetailsInstitutionViewModel>();

            int pageNumber = page ?? 1;

            return this.View(viewModel.ToPagedList(pageNumber, GlobalConstants.HomePageSize));
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }

        [HttpGet]
        public ActionResult Search(string searchInput)
        {
            var allHomes = this.homes.GetAll();

            allHomes = FilterHelper.FilterSearchString(searchInput, allHomes);

            if (!allHomes.Any())
            {
                return this.Content(GlobalConstants.NoPagesFound);
            }

            var viewModel = allHomes
                .OrderByDescending(x => x.CreatedOn)
                .Take(GlobalConstants.AjaxSearchResult)
                .ProjectTo<DetailsInstitutionViewModel>();

            return this.PartialView(GlobalConstants.HomesListPartial, viewModel.ToPagedList(1, int.MaxValue));
        }
    }
}