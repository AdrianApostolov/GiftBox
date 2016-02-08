using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GiftBox.Data.Models;
using GiftBox.Services.Data.Contracts;

namespace GiftBox.Web.Controllers
{
    [HandleError]
    public class BaseController : Controller
    {
        protected IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;
        }

        protected User CurrentUser { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.CurrentUser = this.users.All().Where(u => u.UserName == requestContext.HttpContext.User.Identity.Name).FirstOrDefault();
            return base.BeginExecute(requestContext, callback, state);
        }
    }
}