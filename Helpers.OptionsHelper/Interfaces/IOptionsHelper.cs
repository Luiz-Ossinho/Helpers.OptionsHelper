using System;

namespace Helpers.OptionsHelper.Interfaces
{
    public interface IOptionsHelper
    {
        TOptions ReadOptions<TOptions>() where TOptions : class;
        object ReadOptions(Type type);
    }
}
