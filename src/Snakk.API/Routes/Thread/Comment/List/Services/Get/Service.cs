//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers.HashIdConverters;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread.Comment.List.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;
        private readonly ICommentHashIdConverter _commentHashIdConverter;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get.IService> pluginEnumerable,
            ICommentHashIdConverter commentHashIdConverter,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
            _commentHashIdConverter = commentHashIdConverter;
        }

        public async Task<Dto.Routes.Thread.Comment.List.Get.ResponseDto> RunAsync(
            long threadId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId);

            var commentList = await GetCommentList(
                threadId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.Thread.Comment.List.Get.ResponseDto
            {
                List = commentList.List
                    .Select(i => new Dto.Routes.Thread.Comment.List.Get.ResponseCommentDto
                    {
                        Text = i.Text,
                        CreatedUtc = i.CreatedUtc,

                        HashId = _commentHashIdConverter.GetHashFromId(i.CommentId),

                        PluginData = i.PluginData,
                    })
                    .ToList(),
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, commentList, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto> GetCommentList(
            long threadId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var commentQuery = _db
                .Query("ThreadComment")
                .LeftJoin(
                    "Comment", 
                    j => j.On(
                        "ThreadComment.CommentId", 
                        "Comment.CommentId"))
                .Where("ThreadId", threadId)
                .Select(
                    "Comment.CommentId", 
                    "Comment.Text", 
                    "Comment.IsDeleted", 
                    "Comment.CreatedUtc");

            PluginHook.CommentListQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, commentQuery);

            var commentListQueryResultDto = new QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto
            {
                List = await commentQuery.GetAsync<QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.ThreadDto>()
            };

            PluginHook.CommentListQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, commentListQueryResultDto);

            return commentListQueryResultDto;
        }
    }
}
