using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread
{
    [ApiController]
    [Route("/thread")]
    public class Controller : ControllerBase
    {
        private readonly IThreadHashIdConverter _postHashIdConverter;
        private readonly Services.Get.IService _getService;

        public Controller(
            IThreadHashIdConverter postHashIdConverter,
            Services.Get.IService getService)
        {
            _postHashIdConverter = postHashIdConverter;
            _getService = getService;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.Thread.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                _postHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
