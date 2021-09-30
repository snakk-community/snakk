namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Thread.List.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            object pluginRequestData,
            dynamic pluginData,
            long channelId);

        void After(
            object pluginRequestData,
            dynamic pluginData,
            long channelId,
            QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto threadQueryResultDto,
            dynamic responseData);

        void ThreadListQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long channelId,
            SqlKata.Query threadListQuery);

        void ThreadListQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long channelId,
            QueryResult.Dto.Routes.Channel.Thread.List.Services.Get.ThreadListDto threadListQueryResultDto);

    }
}
