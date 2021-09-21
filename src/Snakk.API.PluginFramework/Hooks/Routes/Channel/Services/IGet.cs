namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
