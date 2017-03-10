using Prism.Windows.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Marketing.LOB.Validation
{
    /// <summary>
    /// This class is required when you need to check validation WITHOUT notifying to the UI
    /// </summary>
    public class ValidatableBindable : ValidatableBindableBase
    {
        public bool IsValid()
        {
            var propertiesToValidate = this.GetType()
                                       .GetRuntimeProperties()
                                       .Where(c => c.GetCustomAttributes(typeof(ValidationAttribute)).Any());


            foreach (PropertyInfo propertyInfo in propertiesToValidate)
            {
                if (!TryValidateProperty(propertyInfo))
                {
                    return false;
                }
            }

            return true;

        }

        private bool TryValidateProperty(PropertyInfo propertyInfo)
        {
            var context = new ValidationContext(this) { MemberName = propertyInfo.Name };
            var propertyValue = propertyInfo.GetValue(this);
            bool isValid = Validator.TryValidateProperty(propertyValue, context, null);
            return isValid;
        }
    }
}
