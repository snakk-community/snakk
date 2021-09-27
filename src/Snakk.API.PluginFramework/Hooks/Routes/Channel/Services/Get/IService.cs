namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Get.ResponseDto responseDto);

        void After(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Get.ResponseDto responseDto);
    }
}
