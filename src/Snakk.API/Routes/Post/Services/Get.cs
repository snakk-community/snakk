using Snakk.API.Extensions;
using Snakk.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Post.Services
{
    public interface IGet
    {
        Task<Dto.Routes.Post.Get.ResponseDto> RunAsync(
            long id,
            object pluginData);
    }

    public class Get : IGet
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Post.Services.IGet> _pluginEnumerable;

        public Get(IEnumerable<PluginFramework.Hooks.Routes.Post.Services.IGet> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dto.Routes.Post.Get.ResponseDto> RunAsync(
            long id,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Post.Get.ResponseDto();

            Hook.Invoke(_pluginEnumerable, i => i.Before(id, responseDto));

            await Task.Run(() => { });

            Hook.Invoke(_pluginEnumerable, i => i.Before(id, responseDto));

            return responseDto;
        }
    }
}
