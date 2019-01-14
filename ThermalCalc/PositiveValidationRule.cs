using System;
using System.Globalization;
using System.Windows.Controls;

namespace ThermalCalc
{
    class PositiveValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double result;
            
            if (!double.TryParse(value.ToString(), out result))
                return new ValidationResult(false, "введите число");
            if (double.Parse(value.ToString()) <= 0)
                return new ValidationResult(false, "число должно быть > 0");
            return new ValidationResult(true, null);
        }
    }
}
