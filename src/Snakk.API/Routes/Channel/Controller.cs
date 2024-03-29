﻿//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel
{
    [ApiController]
    [Route("/channel")]
    public class Controller : ControllerBase
    {
        private readonly Services.Get.IService _getService;

        public Controller(Services.Get.IService getService)
        {
            _getService = getService;
        }

        [HttpGet("{channelSlug}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string channelSlug,
            [FromQuery] Dto.Routes.Channel.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                channelSlug,
                requestDto.PluginData));
    }
}
