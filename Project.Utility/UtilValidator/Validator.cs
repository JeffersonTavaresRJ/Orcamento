using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Project.Utility.UtilValidator
{
    public class SenhaValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string)
            {
                string senha = value.ToString();

                Regex rgx = new Regex("^[A-Za-z0-9]{6,10}$", RegexOptions.IgnoreCase);

                return !(senha.ToUpper().Equals("ABC123")) || rgx.Matches(senha).Count > 0;

            }
            return false;
        }
    }
}
