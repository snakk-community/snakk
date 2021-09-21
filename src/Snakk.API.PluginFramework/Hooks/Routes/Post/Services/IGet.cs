namespace Snakk.API.PluginFramework.Hooks.Routes.Post.Services
{
    public interface IGet
    {
        void Before(
            long commentId, 
            Dto.Routes.Post.Get.ResponseDto responseDto);
        
        void After(
            long commentId, 
            Dto.Routes.Post.Get.ResponseDto responseDto);
    }
}
