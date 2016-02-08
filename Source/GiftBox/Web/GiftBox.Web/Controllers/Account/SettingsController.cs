

using System.IO;
using System.Web;

namespace GiftBox.Web.Controllers.Account
{
    using System.Web.Mvc;
    using System.Linq;

    using GiftBox.Web.ViewModels.Account;
    using GiftBox.Services.Data.Contracts;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    public class SettingsController : BaseController
    {

        public SettingsController(IUsersService users)
            :base(users)
        {
        }

        // GET: Settings
        public ActionResult User()
        {
            var user = Mapper.Map<UserViewModel>(this.users.GetById(this.CurrentUser.Id));
            return View(user);
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateProfile(HttpPostedFileBase file)
        {

            var user = this.users.GetById(this.CurrentUser.Id);

            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string folderPath = Server.MapPath("~/Resources/Images/Profile/" + user.Id);
                string imagePath = folderPath + "/" + filename;
                string imageUrl = "../Resources/Images/Profile/" + user.Id + "/" + filename;

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }

                file.SaveAs(imagePath);
                user.ImageUrl = imageUrl;
                this.users.Update();
                this.TempData["Success"] = "Profile picture updated!";
            }

            return this.View("User", Mapper.Map<UserViewModel>(user));
        }
    }
}