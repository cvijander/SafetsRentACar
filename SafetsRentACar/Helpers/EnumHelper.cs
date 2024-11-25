using Microsoft.AspNetCore.Mvc.Rendering;

namespace SafetsRentACar.Helpers
{
    public class EnumHelper
    {
        public static IEnumerable<SelectListItem> GetEnumSelectListWithPlaceholder<TEnum>(string placeholder) where TEnum : struct, Enum
        {
            var items = new List<SelectListItem>
            {

                new SelectListItem {Value = "", Text = placeholder}
            };

            items.AddRange(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.ToString()
            }));

            return items;
        }
    }
}
