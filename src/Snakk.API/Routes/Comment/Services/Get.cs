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
            
            HookBefore(id, responseDto);

            using var db = new DB.Context();

            var comment = await GetComment(
                id,
                db);

            responseDto.Text = comment.Text;
            responseDto.PluginData = comment.PluginData;

            HookAfter(id, responseDto);

            return responseDto;
        }

        public async Task<(string Text, object PluginData)> GetComment(
            long id,
            DB.Context db)
        {
            var wherePredicate = PredicateBuilder.New<DB.Comment>();

            HookCommentQueryWhereBuilder(wherePredicate);

            wherePredicate.And(i => i.Id == id);

            var comment = await db.Comments
                .Where(wherePredicate)
                .Select(i => new { 
                    i.Text,

                    PluginData = CommentQuerySelectorBuilder(i)
                })
                .SingleOrDefaultAsync();

            return (comment.Text, comment.PluginData);
        }

        private object CommentQuerySelectorBuilder(DB.Comment entity)
        {
            dynamic result = new ExpandoObject();

            HookCommentQuerySelectorBuilder(entity, result);

            return result;
        }

        #region Hook definitions
        private void HookBefore(
            long id,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => Hook.Invoke(
                _pluginEnumerable,
                i => i.Before(
                    id,
                    responseDto));

        private void HookAfter(
            long id,
            Dto.Routes.Comment.Get.ResponseDto responseDto)
            => Hook.Invoke(
                _pluginEnumerable,
                i => i.After(
                    id,
                    responseDto));

        private void HookCommentQueryWhereBuilder(
            ExpressionStarter<DB.Comment> wherePredicate)
            => Hook.Invoke(
                _pluginEnumerable,
                i => i.CommentQueryWhereBuilder(wherePredicate));

        private void HookCommentQuerySelectorBuilder(
            DB.Comment entity,
            ExpandoObject result)
            => Hook.Invoke(
                _pluginEnumerable,
                i => i.CommentQuerySelectorBuilder(entity, result));
        #endregion
    }
}
