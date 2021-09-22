namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Post.List.Services
{
    public interface IGet : IPlugin
    {
        void Before(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Post.List.Get.ResponseDto responseDto);

        void After(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Post.List.Get.ResponseDto responseDto);
    }
}
