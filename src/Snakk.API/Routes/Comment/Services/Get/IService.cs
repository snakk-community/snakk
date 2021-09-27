//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment.Services.Get
{
    public interface IService
    {
        Task<Dto.Routes.Comment.Get.ResponseDto> RunAsync(
            long commentId,
            object pluginData);
    }
}
