namespace Snakk.PluginFramework.Routes.Channel.Post.List.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
