//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Services
{
    public interface IGet
    {
        Task<Dto.Routes.Channel.Get.ResponseDto> RunAsync(
            string channelUrlIdentifier,
            object pluginData);
    }

    public class Get : IGet
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.IGet> _pluginEnumerable;

        public Get(IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.IGet> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dto.Routes.Channel.Get.ResponseDto> RunAsync(
            string channelUrlIdentifier,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Channel.Get.ResponseDto();

            Hook.Invoke(_pluginEnumerable, i => i.Before(channelUrlIdentifier, responseDto));

            await Task.Run(() => { });

            Hook.Invoke(_pluginEnumerable, i => i.After(channelUrlIdentifier, responseDto));

            return responseDto;
        }
    }
}
