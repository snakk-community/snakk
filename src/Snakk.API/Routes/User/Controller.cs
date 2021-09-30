//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System;
using System.Threading.Tasks;

namespace Snakk.API.Routes.User
{
    [ApiController]
    [Route("/user")]
    public class Controller : ControllerBase
    {
        private readonly IUserHashIdConverter _userHashIdConverter;
        private readonly Services.Get.IService _getService;

        public Controller(
            IUserHashIdConverter userHashIdConverter,
            Services.Get.IService getService)
        {
            _userHashIdConverter = userHashIdConverter;
            _getService = getService;
        }

        [HttpGet("{hashId}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.User.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                _userHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
