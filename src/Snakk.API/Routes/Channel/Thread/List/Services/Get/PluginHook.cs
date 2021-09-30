//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Channel.Thread.List.Services.Get
{
    public static class PluginHook
    {
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable,
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
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto commentListQueryResultDto,
            Dto.Routes.Channel.Thread.List.Get.ResponseDto responseDto) => HookBase.Invoke(
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
                        commentListQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void ThreadListQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            SqlKata.Query commentListQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ThreadListQueryBuilderBefore(
                    pluginRequestData,
                    pluginData,
                    channelId,
                    commentListQuery));

        public static void ThreadListQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long channelId,
            QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto commentListQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ThreadListQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    channelId,
                    commentListQueryResultDto));
    }
}
