using Snakk.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.Thread.Get.ResponseDto> RunAsync(
            long id,
            object pluginData);
    }

    public class Service : IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> _pluginEnumerable;

        public Service(IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dto.Routes.Thread.Get.ResponseDto> RunAsync(
            long id,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Thread.Get.ResponseDto();

            HookBase.Invoke(_pluginEnumerable, i => i.Before(id, responseDto));

            await Task.Run(() => { });

            HookBase.Invoke(_pluginEnumerable, i => i.Before(id, responseDto));

            return responseDto;
        }
    }
}
