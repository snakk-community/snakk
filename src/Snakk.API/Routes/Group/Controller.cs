//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel
{
    [ApiController]
    [Route("/group")]
    public class Controller : ControllerBase
    {
        private readonly IGet _get;

        public Controller(
            IGet get)
        {
            _get = get;
        }

        [HttpGet("{groupSlug}")]
        public async Task<IActionResult> GetAsync(string groupSlug)
            => Ok(await _get.RunAsync(groupSlug));
    }
}
