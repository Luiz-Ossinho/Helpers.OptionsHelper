using Helpers.OptionsHelper.Attributes;
using Helpers.OptionsHelper.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Helpers.OptionsHelper.Concretes
{
    public class DefaultOptionsHelper : IOptionsHelper
    {
        private readonly IConfiguration _configuration;
        private readonly IEnviromentVariableHelper _enviromentVariableHelper;

        public DefaultOptionsHelper(IConfiguration configuration, IEnviromentVariableHelper enviromentVariableHelper)
        {
            _configuration = configuration;
            _enviromentVariableHelper = enviromentVariableHelper;
        }
        public TOptions ReadOptions<TOptions>() where TOptions : class
        {
            return ReadOptions(typeof(TOptions)) as TOptions;
        }

        public object ReadOptions(Type type)
        {
            var propertyInfos = type.GetProperties();

            var attributeDictionay = propertyInfos
                .Where(p => p.GetCustomAttribute<ForOptionsAttribute>() is not null)
                .ToDictionary(p => p, p => p.GetCustomAttribute<ForOptionsAttribute>());

            var tInstance = Activator.CreateInstance(type);

            foreach (var item in attributeDictionay)
            {
                var converter = TypeDescriptor.GetConverter(item.Key.PropertyType);

                if (item.Value is FromEnviromentAttribute)
                {
                    var fromEnviroment = item.Value as FromEnviromentAttribute;

                    var value = _enviromentVariableHelper.GetEnvironmentVariable(fromEnviroment.EnviromentVariableName);

                    var result = converter.ConvertFrom(value);

                    item.Key.SetValue(tInstance, result);
                }
                else if (item.Value is FromConfigurationAttribute)
                {
                    var fromConfig = item.Value as FromConfigurationAttribute;

                    var value = _configuration[fromConfig.ConfigurationKeyPath];

                    var result = converter.ConvertFrom(value);

                    item.Key.SetValue(tInstance, result);
                }
                else if (item.Value is FromNestedOptionsAttribute)
                {
                    var value = ReadOptions(item.Key.PropertyType);

                    item.Key.SetValue(tInstance, value);
                }
            }

            return tInstance;
        }
    }
}
