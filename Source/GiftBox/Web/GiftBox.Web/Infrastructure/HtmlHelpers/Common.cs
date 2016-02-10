namespace GiftBox.Web.Infrastructure.HtmlHelpers
{
    using System.Web.Mvc;

    public static class Common
    {
        public static MvcHtmlString Submit(this HtmlHelper helper, string value, object htmlAttributes = null)
        {
            var submitButton = new TagBuilder("input");
            submitButton.Attributes.Add("type", "submit");
            submitButton.Attributes.Add("value", value);
            submitButton.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
            submitButton.AddCssClass("btn btn-dark");
            return new MvcHtmlString(submitButton.ToString());
        }
    }
}