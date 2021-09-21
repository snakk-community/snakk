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
        private readonly Services.IGet _get;

        public Controller(
            ICommentHashIdConverter commentHashIdConverter,
            Services.IGet get)
        {
            _commentHashIdConverter = commentHashIdConverter;
            _get = get;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] string hashId,
            [FromQuery] Dto.Routes.Comment.Get.RequestDto requestDto) 
            => Ok(await _get.RunAsync(
                _commentHashIdConverter.GetIdFromHash(hashId),
                requestDto.PluginData));
    }
}
