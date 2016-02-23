namespace GiftBox.Web.Controllers.Account
{
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;

    using GiftBox.Common;
    using GiftBox.Services.Data.Contracts;
    using GiftBox.Web.Infrastructure.Filters;
    using GiftBox.Web.ViewModels.Account;

    public class SettingsController : BaseController
    {
        public SettingsController(IUsersService users)
            : base(users)
        {
        }

        // GET: Settings
        public ActionResult UpdateProfile(string id)
        {
            if (id == null)
            {
                throw new HttpException(404, "Incorrect route parameters, id cannot be null");
            }

            var user = Mapper.Map<UserViewModel>(this.users.GetById(id));

            if (user == null)
            {
                throw new HttpException(404, "User does not exist");
            }

            return this.View(user);
        }

        [HttpPost]
        [ValidatePictureFile]
        public ActionResult UpdateProfile(HttpPostedFileBase file, string id)
        {
            var user = this.users.GetById(this.CurrentUser.Id);

            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string folderPath = this.Server.MapPath(GlobalConstants.ImageFolderPathPrefix + user.Id);
                string imagePath = folderPath + "/" + filename;
                string imageUrl = GlobalConstants.ImageUrlPrefix + user.Id + "/" + filename;

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }

                file.SaveAs(imagePath);
                user.ImageUrl = imageUrl;
                this.users.Update();
                this.TempData["Success"] = "Profile picture updated!";
            }

            return this.RedirectToAction("UpdateProfile");
        }

        [HttpPost]
        public ActionResult Capture()
        {
            var user = this.users.GetById(this.CurrentUser.Id);

            if (this.Request.InputStream != null)
            {
                string filename = user.Id + GlobalConstants.CaptureImageExtention;
                string folderPath = this.Server.MapPath(GlobalConstants.ImageFolderPathPrefix + user.Id);
                string imagePath = folderPath + "/" + filename;
                string imageUrl = GlobalConstants.ImageUrlPrefix + user.Id + "/" + filename;

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }

                var stream = this.Request.InputStream;
                string dump;

                using (var reader = new StreamReader(stream))
                {
                    dump = reader.ReadToEnd();
                }

                System.IO.File.WriteAllBytes(imagePath, HelperMethods.StringToBytes(dump));

                user.ImageUrl = imageUrl;
                this.users.Update();
                this.TempData["Success"] = GlobalConstants.UpdateImageMessage;
            }

            return this.RedirectToAction("UpdateProfile", this.CurrentUser.Id);
        }
    }
}