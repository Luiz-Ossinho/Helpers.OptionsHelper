using Helpers.OptionsHelper.Attributes;

namespace Helpers.OptionsHelper.Tests.Setup.Models
{
    public class ParceirosOptions
    {
        [FromNestedOptions]
        public BigBoostOptions BigBoostOptions { get; set; }
    }

    public class BigBoostOptions
    {
        [FromConfiguration("Parceiros:BigBoost:BaseUrl")]
        public string UrlBase { get; set; }

        [FromConfiguration("Parceiros:BigBoost:MaxRetry")]
        public int NumeroRetries { get; set; }

        [FromEnviroment("BIGBOOST_TokenAuth")]
        public string TokenAuth { get; set; }
    }
}
