//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;

        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.Channel.Services.Get.IService> pluginEnumerable,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
        }

        public async Task<Dto.Routes.Channel.Get.ResponseDto> RunAsync(
            string slug,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var channelId = await GetChannelId(slug)
                ?? throw new ChannelSlugToIdConvertionException();

            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId);

            var channel = await GetChannel(
                channelId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.Channel.Get.ResponseDto
            {
                AllowAgeConfirmation = channel.AllowAgeConfirmation,
                AllowAllModerators = channel.AllowAllModerators,
                AllowAnonymous = channel.AllowAnonymous,
                CreatedUtc = channel.CreatedUtc,
                Description = channel.Description,
                IsPinned = channel.IsPinned,
                IsPublic = channel.IsPublic,
                Name = channel.Name,
                Slug = channel.Slug,
                SortWeight = channel.SortWeight,

                PluginData = channel.PluginData,
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, channel, responseDto);

            return responseDto;
        }

        private async Task<long?> GetChannelId(string slug) 
            => await _db
                .Query("Channel")
                .Where("Slug", slug)
                .Select("ChannelId")
                .FirstOrDefaultAsync<long?>();

        private async Task<QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto> GetChannel(
            long channelId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var channelQuery = _db
                .Query("Channel")
                .Where("ChannelId", channelId)
                .Select(
                    "Slug",
                    "Name",
                    "Description",
                    "AllowAnonymous",
                    "AllowAgeConfirmation",
                    "IsPublic",
                    "IsPinned",
                    "AllowAllModerators",
                    "SortWeight",
                    "CreatedUtc");

            PluginHook.ChannelQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, channelQuery);

            var channelQueryResultDto = await channelQuery.FirstOrDefaultAsync<QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto>();

            PluginHook.ChannelQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, channelId, channelQueryResultDto);

            return channelQueryResultDto;
        }
    }
}
