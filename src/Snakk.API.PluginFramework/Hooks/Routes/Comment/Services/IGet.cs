namespace Snakk.API.PluginFramework.Hooks.Routes.Comment.Services
{
    public interface IGet :
        IParseRequestData,
        IStuffResponseData,
        IRunBefore,
        IRunAfter
    {
    }
}
