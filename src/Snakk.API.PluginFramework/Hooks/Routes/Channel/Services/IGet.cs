namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Services
{
    public interface IGet
    {
        void Before(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Get.ResponseDto responseDto);

        void After(
            string channelUrlIdentifier,
            Dto.Routes.Channel.Get.ResponseDto responseDto);
    }
}
