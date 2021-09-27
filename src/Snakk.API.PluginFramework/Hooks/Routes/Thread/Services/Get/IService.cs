namespace Snakk.API.PluginFramework.Hooks.Routes.Thread.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            long commentId, 
            Dto.Routes.Thread.Get.ResponseDto responseDto);
        
        void After(
            long commentId, 
            Dto.Routes.Thread.Get.ResponseDto responseDto);
    }
}
