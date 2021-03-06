﻿namespace GiftBox.Common
{
    public static class GlobalConstants
    {
        public const string HomeAdministrator = "HomeAdministrator";
        public const string UserRole = "User";
        public const string AdminRole = "Admin";

        public const string DefaultUserPicture = "http://educaresydney.com.au/wp-content/uploads/2015/01/Coming-soon-clipart.png";
        public const string DefaultHomeCoverPage = "http://demo.geekslabs.com/materialize/v3.1/images/user-profile-bg.jpg";
        public const string DefaultGiftPicture = "https://www.wpclipart.com/holiday/Christmas/gifts/gift_boxes/gift_box_blue.png";

        public const string ImageFolderPathPrefix = "~/Resources/Images/Profile/";
        public const string ImageUrlPrefix = "/Resources/Images/Profile/";
        public const string CaptureImageExtention = ".jpg";

        public const string NoPagesFound = "No pages found!";
        public const string UpdateImageMessage = "Profile picture updated!";
        public const string CreateHomeMessage = "Home created successfully!";
        public const string ClaimSuccessMessage = "You succesfully claim this gift!";

        public const string AddCommentPartial = "_AddCommentPartial";
        public const string DeleteCommentPartial = "_DeleteCommentPartial";
        public const string SingleCommentPartial = "_SingleCommentPartial";
        public const string PageCommentsPartial = "_PageCommentsPartial";
        public const string HomesListPartial = "_HomesListPartial";
        public const string PagingPartial = "_PagingPartial";
        public const string SearchPartial = "_SearchPartial";
        public const string HomeDetailsPartial = "_HomeDetailsPartial";
        public const string ListGiftsPartial = "_ListGiftsPartial";
        public const string ListNeedsPartial = "_ListNeedsPartial";
        public const string EventsCategoriesListPartial = "_EventCategoriesPartial";
        public const string NeedsCategoriesListPartial = "_NeedsCategoriesPartial";

        public const string PageNotFound = "The page you're looking for wasn't found.";
        public const string InvalidComment = "Invalid comment";

        public const int HomePageSize = 6;
        public const int AjaxSearchResult = 6;
    }
}
