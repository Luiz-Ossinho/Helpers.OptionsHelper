using System;

namespace Helpers.OptionsHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromEnviromentAttribute : ForOptionsAttribute
    {
        public FromEnviromentAttribute(string enviromentVariableName)
        {
            EnviromentVariableName = enviromentVariableName;
        }

        public string EnviromentVariableName { get; }
    }
}
