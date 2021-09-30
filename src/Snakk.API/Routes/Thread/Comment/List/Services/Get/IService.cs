//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread.Comment.List.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.Thread.Comment.List.Get.ResponseDto> RunAsync(
            long threadId,
            Dictionary<string, object> pluginRequestDataDictionary);
    }
}
