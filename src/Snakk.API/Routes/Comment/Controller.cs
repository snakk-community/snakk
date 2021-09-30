//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using Snakk.API.Helpers.HashIdConverters;
using System;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment
{
    [ApiController]
    [Route("/comment")]
    public class Controller : ControllerBase
    {
        private readonly ICommentHashIdConverter _commentHashIdConverter;
        private readonly Services.Get.IService _getService;

        public Controller(
            ICommentHashIdConverter commentHashIdConverter,
            Services.Get.IService getService)
        {
            _commentHashIdConverter = commentHashIdConverter;
            _getService = getService;
        }

        [HttpGet("{hashId}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.Comment.Get.RequestDto requestDto)
            => Ok(await _getService.RunAsync(
                _commentHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
