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
        private readonly IGet _get;

        public Controller(
            ICommentHashIdConverter commentHashIdConverter,
            IGet get)
        {
            _commentHashIdConverter = commentHashIdConverter;
            _get = get;
        }

        [HttpGet("{hashid}")]
        public async Task<IActionResult> GetAsync(string hashId)
        {
            return Ok(await _get.RunAsync(_commentHashIdConverter.GetIdFromHash(hashId)));
        }
    }
}
