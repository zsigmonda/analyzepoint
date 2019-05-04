using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AnalyzePoint.Core.Common
{
  public static class EnumExtensions
  {
    /// <summary>
    /// Converts an enumeration to an another one by their value.
    /// </summary>
    /// <typeparam name="T1">Source enumeration type</typeparam>
    /// <typeparam name="T2">Target enumeration type</typeparam>
    /// <param name="val">Source enumeration value</param>
    /// <returns>Target enumeration value</returns>
    public static T2 ConvertByValue<T1, T2>(this T1 val) where T1 : struct where T2 : struct
    {
      if (!typeof(T1).IsEnum)
      {
        throw new ArgumentException("Not an Enum: " + typeof(T1).ToString());
      }

      if (!typeof(T2).IsEnum)
      {
        throw new ArgumentException("Not an Enum: " + typeof(T2).ToString());
      }

      return (T2)Enum.ToObject(typeof(T1), val);
    }

    /// <summary>
    /// Converts an enum to string. If an enum value has a System.ComponentModel.DataAnnotations.DisplayAttribute attribute, then the encapsulated string is returned, otherwise a simple ToString method is called upon.
    /// </summary>
    /// <param name="val">The enum valie to convert.</param>
    /// <returns>String representation of the enum value.</returns>
    public static string ToDisplayText(this Enum val)
    {
      string result = null;

      var display = val.GetType()
          .GetMember(val.ToString()).First()
          .GetCustomAttributes(false)
          .OfType<DisplayAttribute>()
          .LastOrDefault();

      if (display != null)
      {
        result = display.GetName();
      }
      else
      {
        result = val.ToString();
      }

      return result;
    }
  }
}