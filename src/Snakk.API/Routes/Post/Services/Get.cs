using Snakk.API.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Post.Services
{
    public interface IGet
    {
        Task<Dtos.Get.ResponseDto> RunAsync(
            long id,
            object pluginData);
    }

    public class Get : IGet
    {
        private readonly IEnumerable<PluginFramework.Routes.Post.Services.IGet> _pluginEnumerable;

        public Get(IEnumerable<PluginFramework.Routes.Post.Services.IGet> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dtos.Get.ResponseDto> RunAsync(
            long id,
            object pluginData)
        {
            var responseDto = new Dtos.Get.ResponseDto();

            _pluginEnumerable.ForEach(i => i.ParseRequestData(pluginData));
            _pluginEnumerable.ForEach(i => i.RunBefore());

            await Task.Run(() => { });

            _pluginEnumerable.ForEach(i => i.RunAfter());
            _pluginEnumerable.ForEach(i => i.StuffResponseData(responseDto.PluginData));

            return responseDto;
        }
    }
}
