using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Thread.List
{
    [ApiController]
    [Route("/group/{groupSlug}/threads")]
    public class Controller : ControllerBase
    {
        private readonly IGet _get;

        public Controller(
            IGet get)
        {
            _get = get;
        }

        public async Task<IActionResult> GetAsync(string groupSlug)
        {
            return Ok(await _get.RunAsync(groupSlug));
        }
    }
}
