namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using GiftBox.Common;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public abstract class AdminController : BaseController
    {
        public readonly IDataService data;

        public AdminController(IUsersService users, IDataService data)
            : base(users)
        {
            this.data = data;
        }
    }
}