using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class CustomValidation
    {
        public class NotThisYearAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime date = (DateTime)value;
                return date.Year != DateTime.Now.Year;
            }
        }
    }
}
