﻿//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Extensions;
using Snakk.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment.Services
{
    public interface IGet
    {
        Task<Dtos.Get.ResponseDto> RunAsync(
            long id,
            object pluginData);
    }

    public class Get : IGet
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> _pluginEnumerable;

        public Get(IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dtos.Get.ResponseDto> RunAsync(
            long id,
            object pluginData)
        {
            var responseDto = new Dtos.Get.ResponseDto();

            Hook.Invoke(_pluginEnumerable, i => i.ParseRequestData(pluginData));
            Hook.Invoke(_pluginEnumerable, i => i.RunBefore());

            await Task.Run(() => { });

            Hook.Invoke(_pluginEnumerable, i => i.RunAfter());
            Hook.Invoke(_pluginEnumerable, i => i.StuffResponseData(responseDto.PluginData));

            return responseDto;
        }
    }
}
