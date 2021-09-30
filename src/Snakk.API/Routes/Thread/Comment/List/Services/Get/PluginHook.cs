//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Thread.Comment.List.Services.Get
{
    public static class PluginHook
    {
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> pluginEnumerable,
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
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto commentListQueryResultDto,
            Dto.Routes.Thread.Comment.List.Get.ResponseDto responseDto) => HookBase.Invoke(
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
                        commentListQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void CommentListQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            SqlKata.Query commentListQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.CommentListQueryBuilderBefore(
                    pluginRequestData,
                    pluginData,
                    threadId,
                    commentListQuery));

        public static void CommentListQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long threadId,
            QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto commentListQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) => plugin.CommentListQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    threadId,
                    commentListQueryResultDto));
    }
}
