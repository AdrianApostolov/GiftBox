namespace GiftBox.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Controllers;

    //[Authorize(Roles = "Admin")]
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