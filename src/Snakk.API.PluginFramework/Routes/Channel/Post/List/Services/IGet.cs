namespace Snakk.API.PluginFramework.Routes.Channel.Post.List.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
