//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.User.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.User.Get.ResponseDto> RunAsync(
            long userId,
            Dictionary<string, object> pluginData);
    }
}
