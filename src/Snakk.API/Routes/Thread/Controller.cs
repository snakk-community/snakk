using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread
{
    [ApiController]
    [Route("/thread")]
    public class Controller : ControllerBase
    {
        private readonly IThreadHashIdConverter _threadHashIdConverter;
        private readonly IGet _get;

        public Controller(
            IThreadHashIdConverter threadHashIdConverter,
            IGet get)
        {
            _threadHashIdConverter = threadHashIdConverter;
            _get = get;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(string hashId)
        {
            return Ok(await _get.RunAsync(_threadHashIdConverter.GetIdFromHash(hashId)));
        }
    }
}
