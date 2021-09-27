//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Comment.Services.Get
{
    public static class PluginHook
    {
        #region Hook definitions
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long commentId) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData)
                => plugin.Before(
                    pluginRequestData,
                    pluginData,
                    commentId));

        public static void After(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto,
            Dto.Routes.Comment.Get.ResponseDto responseDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData) =>
                {
                    dynamic responseData = null;

                    plugin.After(
                        pluginRequestData,
                        pluginData,
                        commentId,
                        commentQueryResultDto,
                        responseData);

                    if (responseData != null)
                    {
                        responseDto.PluginData[plugin.GetId()] = responseData;
                    }
                });

        public static void CommentQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long commentId,
            SqlKata.Query commentQuery) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData)
                    => plugin.CommentQueryBuilderBefore(
                        pluginRequestData,
                        pluginData,
                        commentId,
                        commentQuery));

        public static void CommentQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            Dictionary<string, dynamic> pluginDataDictionary,
            Dictionary<string, object> pluginRequestDataDictionary,
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto) => HookBase.Invoke(
                pluginEnumerable,
                pluginRequestDataDictionary,
                pluginDataDictionary,
                (plugin, pluginRequestData, pluginData)
                => plugin.CommentQueryBuilderAfter(
                    pluginRequestData,
                    pluginData,
                    commentId,
                    commentQueryResultDto));
        #endregion
    }
}
