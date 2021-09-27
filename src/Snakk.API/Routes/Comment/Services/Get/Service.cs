//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment.Services.Get
{
    public abstract class Service : IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            QueryFactory db)
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
        }

        public async Task<Dto.Routes.Comment.Get.ResponseDto> RunAsync(
            long commentId,
            object pluginData)
        {
            var responseDto = new Dto.Routes.Comment.Get.ResponseDto();

            Hook.Before(_pluginEnumerable, commentId, responseDto);

            var comment = await GetComment(
                _pluginEnumerable,
                commentId);

            responseDto.Text = comment.Text;
            responseDto.PluginData = comment.PluginData;

            Hook.After(_pluginEnumerable, commentId, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.Comment.Services.Get.CommentDto> GetComment(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            long commentId)
        {
            var commentQuery = _db
                .Query("Comment")
                .Where("Id", commentId)
                .Select("Id", "Text", "CreatedUtc");

            Hook.CommentQueryBuilderBefore(_pluginEnumerable, commentId, commentQuery);

            var commentQueryResultDto = await commentQuery.FirstOrDefaultAsync<QueryResult.Dto.Routes.Comment.Services.Get.CommentDto>();

            Hook.CommentQueryBuilderAfter(_pluginEnumerable, commentId, commentQueryResultDto);

            return commentQueryResultDto;
        }
    }
}
