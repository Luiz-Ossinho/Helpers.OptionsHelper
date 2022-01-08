using System;

namespace Helpers.OptionsHelper.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FromConfigurationAttribute : ForOptionsAttribute
    {
        public FromConfigurationAttribute(string configurationKeyPath)
        {
            ConfigurationKeyPath = configurationKeyPath;
        }

        public string ConfigurationKeyPath { get; }
    }
}
