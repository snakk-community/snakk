//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Channel.Services.Get
{
    public static class PluginHook
    {
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.Before(
                    pluginRequestData,
                    pluginData,
                    channelId));

        public static void After(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto channelQueryResultDto,
            Dto.Routes.Channel.Get.ResponseDto responseDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) =>
                {
                    dynamic responseData = null;

                    plugin.After(
                        pluginRequestData,
                        pluginData,
                        channelId,
                        channelQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void ChannelQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            SqlKata.Query channelQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ChannelQueryBuilderBefore(
                    pluginRequestData,
                    pluginData,
                    channelId,
                    channelQuery));

        public static void ChannelQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto channelQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ChannelQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    channelId,
                    channelQueryResultDto));
    }
}
