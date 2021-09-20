namespace Snakk.API.PluginFramework.Routes.Channel
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
