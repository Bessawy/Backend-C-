using System.ComponentModel.DataAnnotations;
namespace NETCoreDemo.Common;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
public class CourseStartDateAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is null)
        {
            return false;
        }
        var startDate = (DateTime)value;
        return startDate.Year == DateTime.Now.Year;
    }
}