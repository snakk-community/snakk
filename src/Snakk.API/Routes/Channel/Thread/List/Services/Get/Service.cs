//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Thread.List.Services.Get
{
    public class Service : IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> _pluginEnumerable;

        public Service(IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dto.Routes.Channel.Thread.List.Get.ResponseDto> RunAsync(
            string channelUrlIdentifier,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Channel.Thread.List.Get.ResponseDto();

            //HookBase.Invoke(_pluginEnumerable, i => i.Before(channelUrlIdentifier, responseDto));

            await Task.Run(() => { });

            //HookBase.Invoke(_pluginEnumerable, i => i.After(channelUrlIdentifier, responseDto));

            return responseDto;
        }
    }
}
