//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Thread.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Thread.Services.Get.IService> pluginEnumerable,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
        }

        public async Task<Dto.Routes.Thread.Get.ResponseDto> RunAsync(
            long threadId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId);

            var thread = await GetThread(
                threadId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.Thread.Get.ResponseDto
            {
                Name = thread.Name,
                Slug = thread.Slug,

                CreatedUtc = thread.CreatedUtc,

                IsClosed = thread.IsClosed,
                IsPinned = thread.IsPinned,
                IsDeleted = thread.IsDeleted,
                IsAnonymous = thread.IsAnonymous,
                IsSafeForKids = thread.IsSafeForKids,

                PluginData = thread.PluginData
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, thread, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto> GetThread(
            long threadId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var threadQuery = _db
                .Query("Thread")
                .Where("Id", threadId)
                .Select("ThreadId", "Name", "Slug", "IsClosed", "IsPinned", "IsDeleted", "IsAnonymous", "IsSafeForKids", "CreatedUtc");

            PluginHook.ThreadQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, threadQuery);

            var threadQueryResultDto = await threadQuery.FirstOrDefaultAsync<QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto>();

            PluginHook.ThreadQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, threadId, threadQueryResultDto);

            return threadQueryResultDto;
        }
    }
}
