namespace Snakk.API.PluginFramework.Routes.Post.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
