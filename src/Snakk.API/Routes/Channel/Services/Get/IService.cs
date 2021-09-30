//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.Channel.Get.ResponseDto> RunAsync(
            string slug,
            Dictionary<string, object> pluginData);
    }
}
