//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using Snakk.API.Helpers.HashIdConverters;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Thread.List.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;
        private readonly IThreadHashIdConverter _threadHashIdConverter;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get.IService> pluginEnumerable,
            IThreadHashIdConverter threadHashIdConverter,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
            _threadHashIdConverter = threadHashIdConverter;
        }

        public async Task<Dto.Routes.Channel.Thread.List.Get.ResponseDto> RunAsync(
            string channelSlug,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var channelId = 123;

            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId);

            var threadList = await GetThreadList(
                channelId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.Channel.Thread.List.Get.ResponseDto
            {
                List = threadList.List
                    .Select(i => new Dto.Routes.Channel.Thread.List.Get.ResponseThreadDto
                    {
                        Name = i.Name,
                        Slug = i.Slug,

                        CreatedUtc = i.CreatedUtc,

                        IsAnonymous = i.IsAnonymous,
                        IsClosed = i.IsClosed,
                        IsDeleted = i.IsDeleted,
                        IsPinned = i.IsPinned,
                        IsSafeForKids = i.IsSafeForKids,

                        HashId = _threadHashIdConverter.GetHashFromId(i.ThreadId),

                        PluginData = i.PluginData,
                    })
                    .ToList(),
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, threadList, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto> GetThreadList(
            long channelId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var threadQuery = _db
                .Query("Thread")
                .Where("ChannelId", channelId)
                .Select(
                    "Thread.ThreadId",
                    "Thread.Slug",
                    "Thread.Name",
                    "Thread.IsClosed",
                    "Thread.IsPinned",
                    "Thread.IsAnonymous",
                    "Thread.IsSafeForKids",
                    "Thread.IsDeleted",
                    "Thread.CreatedUtc");

            PluginHook.ThreadListQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, threadQuery);

            var threadListQueryResultDto = new QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto
            {
                List = await threadQuery.GetAsync<QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadDto>(),
            };

            PluginHook.ThreadListQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, threadListQueryResultDto);

            return threadListQueryResultDto;
        }
    }
}
