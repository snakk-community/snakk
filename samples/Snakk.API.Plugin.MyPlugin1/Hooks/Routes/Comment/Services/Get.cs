//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Dto.Routes.Comment.Get;
using System;

namespace Snakk.API.Plugin.MyPlugin1.Hooks.Routes.Comment.Services
{
    public class Get : PluginFramework.Hooks.Routes.Comment.Services.IGet
    {
        public void After(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.After()");
        }

        public void Before(long commentId, ResponseDto responseDto)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.Before()");
        }

        public void CommentQuerySelectorBuilder(DB.Comment entity, dynamic result)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.CommentQuerySelectorBuilder()");
           
            result.Test = entity.CreatedUtc;
        }

        public void CommentQueryWhereBuilder(LinqKit.ExpressionStarter<DB.Comment> wherePredicate)
        {
            Console.WriteLine($"Hello from {GetType().FullName}.CommentQueryWhereBuilder()");
        
            wherePredicate.And(i => i.CreatedUtc > DateTime.UtcNow.AddYears(-10));
        }
    }
}
