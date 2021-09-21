namespace Snakk.API.PluginFramework.Hooks.Routes.Post.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
