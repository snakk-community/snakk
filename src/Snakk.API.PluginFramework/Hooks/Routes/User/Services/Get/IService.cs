namespace Snakk.API.PluginFramework.Hooks.Routes.User.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            object pluginRequestData,
            dynamic pluginData,
            long userId);

        void After(
            object pluginRequestData,
            dynamic pluginData,
            long userId,
            QueryResult.Dto.Routes.User.Services.Get.UserDto userQueryResultDto,
            dynamic responseData);

        void UserQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long userId,
            SqlKata.Query userQuery);

        void UserQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long userId,
            QueryResult.Dto.Routes.User.Services.Get.UserDto userQueryResultDto);

    }
}
