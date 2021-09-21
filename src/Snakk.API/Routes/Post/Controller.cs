using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Post
{
    [ApiController]
    [Route("/post")]
    public class Controller : ControllerBase
    {
        private readonly IPostHashIdConverter _postHashIdConverter;
        private readonly Services.IGet _get;

        public Controller(
            IPostHashIdConverter postHashIdConverter,
            Services.IGet get)
        {
            _postHashIdConverter = postHashIdConverter;
            _get = get;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.Post.Get.RequestDto requestDto)
            => Ok(await _get.RunAsync(
                _postHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
