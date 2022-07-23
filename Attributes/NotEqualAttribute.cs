using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Attributes
{
  /// <summary>
  /// Compare two properties thats are not allowed to be the same.
  /// </summary>
  public class NotEqualAttribute : ValidationAttribute
  {
    /// <summary>
    /// Gets the property to compare with the current property.
    ///
    /// Rückgabewerte: The other property.
    /// </summary>
    private string OtherProperty { get; set; }

    /// <summary>
    /// Compare two properties thats are not allowed to be the same.
    /// </summary>
    public NotEqualAttribute(string otherProperty)
    {
      OtherProperty = otherProperty;
    }

    /// <summary>
    /// Determines whether a specified object is valid.
    /// </summary>
    /// <param name="value">The object to validate.</param>
    /// <param name="validationContext">An object that contains information about the validation request.</param>
    /// <returns>true if value is valid; otherwise, false.</returns>
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      // get other property value.
      var otherValue = validationContext.ObjectType.GetProperty(OtherProperty).GetValue(validationContext.ObjectInstance);

      if (value.ToString().Equals(otherValue.ToString()))
        return new ValidationResult(string.Format("{0} should not be equal to {1}.", validationContext.MemberName, OtherProperty));
      else
        return ValidationResult.Success;
    }
  }
}
