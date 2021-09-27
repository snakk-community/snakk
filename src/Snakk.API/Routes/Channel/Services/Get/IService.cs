//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.Channel.Get.ResponseDto> RunAsync(
            string channelUrlIdentifier,
            object pluginData);
    }
}
