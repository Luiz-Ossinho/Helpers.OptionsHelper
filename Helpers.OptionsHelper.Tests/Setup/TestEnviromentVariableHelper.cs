using Helpers.OptionsHelper.Interfaces;
using System.Collections.Generic;

namespace Helpers.OptionsHelper.Tests.Setup
{
    public class TestEnviromentVariableHelper : IEnviromentVariableHelper
    {
        public readonly Dictionary<string, string> Values = new()
        {
            { "BIGBOOST_TokenAuth", "sb77e8ac-f86b-40c6-977b-4642ec084963" }
        };

        public string GetEnvironmentVariable(string variable)
        {
            return Values[variable];
        }
    }
}
