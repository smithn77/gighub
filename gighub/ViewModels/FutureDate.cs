using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace gighub.ViewModels
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isDate = DateTime.TryParseExact(Convert.ToString(value),
                "d MMM yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, 
                out dateTime);

            return (isDate && dateTime > DateTime.Now);
        }
    }
}