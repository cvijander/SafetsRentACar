using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SafetsRentACar.Helpers
{
    public class EnumHelper
    {
        public static IEnumerable<SelectListItem> GetEnumSelectListWithPlaceholder<TEnum>(string placeholder) where TEnum : struct, Enum
        {
            var items = new List<SelectListItem>
            {

                new SelectListItem {Value = "", Text = placeholder, Disabled = true, Selected = true} // Placeholder kao nevalidan
            };

            items.AddRange(Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e =>

            {
            var displayAttribute = e.GetType()
                                   .GetField(e.ToString())
                                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                                   .FirstOrDefault() as DisplayAttribute;

                    return new SelectListItem
                    {
                        Value = e.ToString(),
                        Text = displayAttribute?.Name ?? e.ToString()

                    };

            }));

            return items;
        }
    }
}
