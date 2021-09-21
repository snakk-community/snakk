namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Post.List.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
