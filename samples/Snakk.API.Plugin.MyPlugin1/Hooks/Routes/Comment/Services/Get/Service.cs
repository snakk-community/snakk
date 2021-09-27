//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.QueryResult.Dto.Routes.Comment.Services.Get;
using SqlKata;
using System;

namespace Snakk.API.Plugin.MyPlugin1.Hooks.Routes.Comment.Services.Get
{
    public class Service : BasePlugin, PluginFramework.Hooks.Routes.Comment.Services.Get.IService
    {
        public void Before(object pluginRequestData, dynamic pluginData, long commentId)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.Before()");
        }

        public void After(object pluginRequestData, dynamic pluginData, long commentId, CommentDto commentQueryResultDto, dynamic responseData)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.After()");

            responseData = new
            {
                Foo = 1,
                Bar = 2,
            };
        }

        public void CommentQueryBuilderBefore(object pluginRequestData, dynamic pluginData, long commentId, Query commentQuery)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.CommentQueryBuilderBefore()");

            commentQuery.Select($"IsDeleted AS PluginData[{PluginInfo.Id}].IsDeleted");
        }

        public void CommentQueryBuilderAfter(object pluginRequestData, dynamic pluginData, long commentId, CommentDto commentQueryResultDto)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.CommentQueryBuilderAfter()");
        }
    }
}
