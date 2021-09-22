//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using LinqKit;
using Microsoft.EntityFrameworkCore;
using Snakk.API.Helpers;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment.Services
{
    public interface IGet
    {
        Task<Dto.Routes.Comment.Get.ResponseDto> RunAsync(
            long id,
            object pluginData);
    }

    public class Get : IGet
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> _pluginEnumerable;

        public Get(IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable)
        {
            _pluginEnumerable = pluginEnumerable;
        }

        public async Task<Dto.Routes.Comment.Get.ResponseDto> RunAsync(
            long id,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Comment.Get.ResponseDto();
            
            HookBefore(_pluginEnumerable, id, responseDto);

            using var db = new DB.Context();

            var comment = await GetComment(
                _pluginEnumerable,
                id,
                db);

            responseDto.Text = comment.Text;
            responseDto.PluginData = comment.PluginData;

            HookAfter(_pluginEnumerable, id, responseDto);

            return responseDto;
        }

        public async Task<(string Text, object PluginData)> GetComment(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            long id,
            DB.Context db)
        {
            var wherePredicate = PredicateBuilder.New<DB.Comment>();

            HookCommentQueryWhereBuilder(pluginEnumerable, wherePredicate);

            wherePredicate.And(i => i.Id == id);

            var comment = await db.Comments
                .Where(wherePredicate)
                .Select(i => new { 
                    i.Text,

                    //PluginData = CommentQuerySelectorBuilder(pluginEnumerable, i)
                    PluginData = new { },
                })
                .SingleOrDefaultAsync()
                ?? throw new Exception("Could not find comment with provided id");

            return (comment.Text, comment.PluginData);
        }

        private static object CommentQuerySelectorBuilder(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            DB.Comment entity)
        {
            dynamic result = new ExpandoObject();

            HookCommentQuerySelectorBuilder(pluginEnumerable, entity, result);

            return result;
        }

        #region Hook definitions
        private static void HookBefore(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            long id,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => Hook.Invoke(
                pluginEnumerable,
                i => i.Before(
                    id,
                    responseDto));

        private static void HookAfter(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            long id,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => Hook.Invoke(
                pluginEnumerable,
                i => i.After(
                    id,
                    responseDto));

        private static void HookCommentQueryWhereBuilder(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            ExpressionStarter<DB.Comment> wherePredicate)
            => Hook.Invoke(
                pluginEnumerable,
                i => i.CommentQueryWhereBuilder(wherePredicate));

        private static void HookCommentQuerySelectorBuilder(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.IGet> pluginEnumerable,
            DB.Comment entity,
            ExpandoObject result)
            => Hook.Invoke(
                pluginEnumerable,
                i => i.CommentQuerySelectorBuilder(entity, result));
        #endregion
    }
}
