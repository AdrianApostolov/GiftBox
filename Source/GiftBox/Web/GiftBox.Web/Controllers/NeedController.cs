using System.Data.Entity;
using System.Linq;

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

        public NeedController(IUsersService users, INeedService needs)
            : base(users)
        {
            this.needs = needs;
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
    }
}