//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.User.Services.Get
{
    public static class PluginHook
    {
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long userId) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.Before(
                    pluginRequestData,
                    pluginData,
                    userId));

        public static void After(
            IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long userId,
            QueryResult.Dto.Routes.User.Services.Get.UserDto userQueryResultDto,
            Dto.Routes.User.Get.ResponseDto responseDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) =>
                {
                    dynamic responseData = null;

                    plugin.After(
                        pluginRequestData,
                        pluginData,
                        userId,
                        userQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void UserQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long userId,
            SqlKata.Query userQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.UserQueryBuilderBefore(
                    pluginRequestData,
                    pluginData,
                    userId,
                    userQuery));

        public static void UserQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long userId,
            QueryResult.Dto.Routes.User.Services.Get.UserDto userQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.UserQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    userId,
                    userQueryResultDto));
    }
}
