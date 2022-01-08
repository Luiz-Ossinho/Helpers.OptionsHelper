using System;

namespace Helpers.OptionsHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromNestedOptionsAttribute : ForOptionsAttribute { }
}
