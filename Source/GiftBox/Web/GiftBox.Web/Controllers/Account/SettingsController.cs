namespace GiftBox.Web.Controllers.Account
{
    using System.Web.Mvc;
    using System.IO;
    using System.Web;

    using GiftBox.Common;
    using GiftBox.Web.ViewModels.Account;
    using GiftBox.Services.Data.Contracts;

    using AutoMapper;

    public class SettingsController : BaseController
    {

        public SettingsController(IUsersService users)
            : base(users)
        {
        }

        // GET: Settings
        public ActionResult UpdateProfile(string id)
        {
            var user = Mapper.Map<UserViewModel>(this.users.GetById(id));
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateProfile(HttpPostedFileBase file, string id)
        {

            var user = this.users.GetById(this.CurrentUser.Id);

            if (file != null)
            {
                string filename = Path.GetFileName(file.FileName);
                string folderPath = Server.MapPath("~/Resources/Images/Profile/" + user.Id);
                string imagePath = folderPath + "/" + filename;
                string imageUrl = "/Resources/Images/Profile/" + user.Id + "/" + filename;

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
                string filename = user.Id + ".jpg";
                string folderPath = Server.MapPath("~/Resources/Images/Profile/" + user.Id);
                string imagePath = folderPath + "/" + filename;
                string imageUrl = "/Resources/Images/Profile/" + user.Id + "/" + filename;

                if (!Directory.Exists(folderPath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(folderPath);
                }

                var stream = Request.InputStream;
                string dump;

                using (var reader = new StreamReader(stream))
                {
                    dump = reader.ReadToEnd();
                }

                System.IO.File.WriteAllBytes(imagePath, HelperMethods.StringToBytes(dump));

                user.ImageUrl = imageUrl;
                this.users.Update();
                this.TempData["Success"] = "Profile picture updated!";
            }

            return this.RedirectToAction("UpdateProfile");
        }
    }
}