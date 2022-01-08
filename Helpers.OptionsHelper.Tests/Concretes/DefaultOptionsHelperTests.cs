using Helpers.OptionsHelper.Tests.Setup;
using Helpers.OptionsHelper.Tests.Setup.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace Helpers.OptionsHelper.Tests.Concretes
{
    public class DefaultOptionsHelperTests
    {
        private readonly Dictionary<string, string> InitialConfiguration = new()
        {
            { "Parceiros:BigBoost:BaseUrl", "https://bigboost.bigdatacorp.com.br" },
            { "Parceiros:BigBoost:MaxRetry", "20" }
        };
        private readonly OptionsHelper.Concretes.DefaultOptionsHelper OptionHelper;

        public DefaultOptionsHelperTests()
        {
            var configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(InitialConfiguration)
                .Build();
            var helper = new TestEnviromentVariableHelper();

            OptionHelper = new OptionsHelper.Concretes.DefaultOptionsHelper(configuration, helper);
        }


        [Fact]
        public void ReadOptions_Cria_ValoresDeString_Corretamente()
        {
            //Arrange in ctor

            // Act
            var options = OptionHelper.ReadOptions<ParceirosOptions>();

            // Assert
            Assert.False(options is null);
            Assert.False(options.BigBoostOptions is null);
            Assert.True(options.BigBoostOptions is BigBoostOptions { UrlBase: "https://bigboost.bigdatacorp.com.br", TokenAuth: "sb77e8ac-f86b-40c6-977b-4642ec084963" });
        }

        [Fact]
        public void ReadOptions_Cria_ValoresNumericos_Corretamente()
        {
            //Arrange in ctor

            // Act
            var options = OptionHelper.ReadOptions<ParceirosOptions>();

            // Assert
            Assert.False(options is null);
            Assert.False(options.BigBoostOptions is null);
            Assert.True(options.BigBoostOptions is BigBoostOptions { NumeroRetries: 20 });
        }
    }
}
