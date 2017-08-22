using System.ComponentModel.DataAnnotations;

namespace Blip.Common.Formatting
{
    public class Attributes
    {
        // Code from http://stackoverflow.com/questions/3548300/how-to-do-integer-model-validation-in-asp-net-mvc-2
        public class PosNumberNoZeroAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                if (value == null)
                {
                    return true;
                }
                if (int.TryParse(value.ToString(), out int getal))
                {

                    if (getal == 0)
                        return false;

                    if (getal > 0)
                        return true;
                }
                return false;
            }
        }
    }
}