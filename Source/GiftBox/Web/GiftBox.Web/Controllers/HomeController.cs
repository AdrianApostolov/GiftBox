using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using GiftBox.Common;
using GiftBox.Services.Data.Contracts;
using GiftBox.Web.Infrastructure.HtmlHelpers;
using GiftBox.Web.ViewModels.Institution;
using PagedList;

namespace GiftBox.Web.Controllers
{
    public class HomeController : Controller
    {
        private const int PageSize = 6;
        private const int AjaxSearchResult = 3;
        private IHomeService homes;

        public HomeController(IHomeService homes)
        {
            this.homes = homes;
        }

        [HttpGet]
        public ActionResult Index(string searchInput, string currentFilter,int? page)
        {
            var allHomes = this.homes.GetAll();

            if (string.IsNullOrEmpty(searchInput))
            {
                searchInput = currentFilter;
            }
            else
            {
                page = 1;
            }

            allHomes = FilterHelper.FilterSearchString(searchInput, allHomes);

            ViewBag.CurrentFilter = searchInput;

            var viewModel = allHomes
                .OrderBy(x => x.CreatedOn)
                .ProjectTo<DetailsInstitutionViewModel>();

            int pageNumber = page ?? 1;

            return View(viewModel.ToPagedList(pageNumber, PageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
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
                .Take(AjaxSearchResult)
                .ProjectTo<DetailsInstitutionViewModel>();

            return this.PartialView(GlobalConstants.HomesListPartial, viewModel.ToPagedList(1, int.MaxValue));
        }
    }
}