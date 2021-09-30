//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Comment.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Comment.Services.Get.IService> pluginEnumerable,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
        }

        public async Task<Dto.Routes.Comment.Get.ResponseDto> RunAsync(
            long commentId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, commentId);

            var comment = await GetComment(
                commentId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.Comment.Get.ResponseDto
            {
                Text = comment.Text,
                PluginData = comment.PluginData
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, commentId, comment, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.Comment.Services.Get.CommentDto> GetComment(
            long commentId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var commentQuery = _db
                .Query("Comment")
                .Where("CommentId", commentId)
                .Select("CommentId", "Text", "CreatedUtc");

            PluginHook.CommentQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, commentId, commentQuery);

            var commentQueryResultDto = await commentQuery.FirstOrDefaultAsync<QueryResult.Dto.Routes.Comment.Services.Get.CommentDto>();

            PluginHook.CommentQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, commentId, commentQueryResultDto);

            return commentQueryResultDto;
        }
    }
}
