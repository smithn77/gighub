using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace gighub.ViewModels
{
    public class ValidateTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValidTime = DateTime.TryParseExact(Convert.ToString(value),
                "HH:mm",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None, 
                out dateTime);

            return isValidTime;
        }
    }
}