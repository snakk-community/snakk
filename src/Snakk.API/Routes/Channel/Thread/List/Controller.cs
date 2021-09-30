//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Thread.List
{
    [ApiController]
    [Route("/channel/{channelSlug}/threads")]
    public class Controller : ControllerBase
    {
        private readonly Services.Get.IService _getService;

        public Controller(Services.Get.IService getService)
        {
            _getService = getService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string channelSlug,
            [FromQuery] Dto.Routes.Channel.Thread.List.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                channelSlug,
                requestDto.PluginData));
    }
}
