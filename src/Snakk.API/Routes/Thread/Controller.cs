//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

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
        private readonly Services.Get.IService _getService;

        public Controller(
            IThreadHashIdConverter threadHashIdConverter,
            Services.Get.IService getService)
        {
            _threadHashIdConverter = threadHashIdConverter;
            _getService = getService;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.Thread.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                _threadHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
