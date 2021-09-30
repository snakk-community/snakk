//  SPDX-FileCopyrightText: 2021 Pål Rune Sørensen Tuv <me@paaltuv.no>
//  SPDX-License-Identifier: MIT

using SqlKata.Execution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Snakk.API.Routes.User.Services.Get
{
    public class Service : BaseService, IService
    {
        private readonly IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> _pluginEnumerable;
        private readonly QueryFactory _db;
        private readonly Helpers.HashIdConverters.AvatarHashIdConverter _avatarHashIdConverter;
        public Service(
            IEnumerable<PluginFramework.Hooks.Routes.User.Services.Get.IService> pluginEnumerable,
            Helpers.HashIdConverters.AvatarHashIdConverter avatarHashIdConverter,
            QueryFactory db) : base()
        {
            _pluginEnumerable = pluginEnumerable;
            _db = db;
            _avatarHashIdConverter = avatarHashIdConverter;
        }

        public async Task<Dto.Routes.User.Get.ResponseDto> RunAsync(
            long userId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            PluginHook.Before(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, userId);

            var user = await GetUser(
                userId,
                pluginRequestDataDictionary);

            var responseDto = new Dto.Routes.User.Get.ResponseDto
            {
                Username = user.Username,
                DisplayName = user.DisplayName,
                About = user.About,
                IsAdministrator = user.IsAdministrator,
                TimeZoneId = user.TimeZoneId,
                CreatedUtc = user.CreatedUtc,
                SignatureText = user.SignatureText,

                AvatarHashId = user.AvatarId != null ? _avatarHashIdConverter.GetHashFromId(user.AvatarId.Value) : null,

                PluginData = user.PluginData
            };

            PluginHook.After(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, userId, user, responseDto);

            return responseDto;
        }

        public async Task<QueryResult.Dto.Routes.User.Services.Get.UserDto> GetUser(
            long userId,
            Dictionary<string, object> pluginRequestDataDictionary)
        {
            var userQuery = _db
                .Query("User")
                .LeftJoin(
                    "UserAvatar", 
                    i => i.On(
                        "User.UserId",
                        "UserAvatar.UserId"))
                .LeftJoin(
                    "Avatar", 
                    i => i.On(
                        "Avatar.AvatarId",
                        "UserAvatar.AvatarId")
                    .WhereFalse("IsDeleted"))
                .LeftJoin(
                    "UserSignature", 
                    i => i.On(
                        "User.UserId",
                        "UserSignature.UserId"))
                .LeftJoin(
                    "Signature", 
                    i => i.On(
                        "Signature.SignatureId",
                        "UserSignature.SignatureId")
                    .WhereFalse("IsDeleted"))
                .Where("User.UserId", userId)
                .Select(
                    "User.Username",
                    "User.DisplayName",
                    "User.TimeZoneId", 
                    "User.About", 
                    "User.IsAdministrator", 
                    "User.CreatedUtc",
                    "Avatar.AvatarId",
                    "Signature.Text AS SignatureText");

            PluginHook.UserQueryBuilderBefore(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, userId, userQuery);

            var userQueryResultDto = await userQuery.FirstOrDefaultAsync<QueryResult.Dto.Routes.User.Services.Get.UserDto>();

            PluginHook.UserQueryBuilderAfter(_pluginEnumerable, _pluginDataDictionary, pluginRequestDataDictionary, userId, userQueryResultDto);

            return userQueryResultDto;
        }
    }
}
