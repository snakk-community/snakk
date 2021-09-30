//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Thread.Services.Get
{
    public static class PluginHook
    {
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.Before(
                    pluginRequestData,
                    pluginData,
                    threadId));

        public static void After(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto threadQueryResultDto,
            Dto.Routes.Thread.Get.ResponseDto responseDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) =>
                {
                    dynamic responseData = null;

                    plugin.After(
                        pluginRequestData,
                        pluginData,
                        threadId,
                        threadQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void ThreadQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            SqlKata.Query threadQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ThreadQueryBuilderBefore(
                    pluginRequestData,
                    pluginData,
                    threadId,
                    threadQuery));

        public static void ThreadQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto threadQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.ThreadQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    threadId,
                    threadQueryResultDto));
    }
}
