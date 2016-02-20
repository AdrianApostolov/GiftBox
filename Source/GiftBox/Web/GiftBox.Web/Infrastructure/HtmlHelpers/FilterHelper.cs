namespace GiftBox.Web.Infrastructure.HtmlHelpers
{
    using System.Linq;
    using GiftBox.Data.Models;

    public class FilterHelper
    {
        public static IQueryable<Home> FilterSearchString(string searchString, IQueryable<Home> homes)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                return homes
                    .Where(x => x.Name.ToLower().Contains(searchString.ToLower()) || x.Location.City.ToLower().Contains(searchString.ToLower()));
            }
           
           return homes;
        }
    }
}