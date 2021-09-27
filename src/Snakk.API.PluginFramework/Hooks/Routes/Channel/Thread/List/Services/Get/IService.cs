namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Thread.List.Get.ResponseDto responseDto);

        void After(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Thread.List.Get.ResponseDto responseDto);
    }
}
