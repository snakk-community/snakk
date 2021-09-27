//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers;
using System.Collections.Generic;

namespace Snakk.API.Routes.Comment.Services.Get
{
    public static class Hook
    {
        #region Hook definitions
        public static void Before(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            long commentId,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => HookBase.Invoke(
                pluginEnumerable,
                i => i.Before(
                    commentId,
                    responseDto));

        public static void After(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            long commentId,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => HookBase.Invoke(
                pluginEnumerable,
                i => i.After(
                    commentId,
                    responseDto));

        public static void CommentQueryBuilderBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            long commentId,
            SqlKata.Query commentQuery)
            => HookBase.Invoke(
                pluginEnumerable,
                i => i.CommentQueryBuilderBefore(commentId, commentQuery));

        public static void CommentQueryBuilderAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto)
            => HookBase.Invoke(
                pluginEnumerable,
                i => i.CommentQueryBuilderAfter(commentId, commentQueryResultDto));
        #endregion
    }
}
