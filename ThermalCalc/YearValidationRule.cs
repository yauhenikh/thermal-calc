using System.Globalization;
using System.Windows.Controls;

namespace ThermalCalc
{
    class YearValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int result2;

            if (!int.TryParse(value.ToString(), out result2))
                return new ValidationResult(false, "введите число");
            if (int.Parse(value.ToString()) <= 0)
                return new ValidationResult(false, "некорректный год");

            return new ValidationResult(true, null);
        }
    }
}
