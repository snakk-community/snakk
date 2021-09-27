//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Dto.Routes.Comment.Get;
using SqlKata;
using System;

namespace Snakk.API.Plugin.MyPlugin1.Hooks.Routes.Comment.Services
{
    public class Get : PluginFramework.Hooks.Routes.Comment.Services.IGet
    {
        public void After(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.After()");
        }

        public void Before(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.Before()");
        }

        public void CommentQueryBuilderBefore(long commentId, Query commentQuery)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.CommentQueryBuilderBefore()");

            commentQuery.Select($"IsDeleted AS PluginData[{PluginInfo.Identifier}].IsDeleted");
        }

        public void CommentQueryBuilderAfter(long commentId, QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto)
        {
            Console.WriteLine($"[{PluginInfo.Name}] Hello from {GetType().FullName}.CommentQueryBuilderAfter()");
        }
    }
}
