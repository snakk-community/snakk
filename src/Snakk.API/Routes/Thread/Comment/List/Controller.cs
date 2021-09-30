//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread.Comment.List
{
    [ApiController]
    [Route("/thread/{threadHashId}/comments")]
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

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string threadHashId,
            [FromQuery] Dto.Routes.Thread.Comment.List.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                _threadHashIdConverter.GetIdFromHash(threadHashId),
                requestDto.PluginData));
    }
}
