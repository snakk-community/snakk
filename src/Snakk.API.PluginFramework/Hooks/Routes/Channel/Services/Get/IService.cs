namespace Snakk.API.PluginFramework.Hooks.Routes.Channel.Services.Get
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
            QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto channelQueryResultDto,
            dynamic responseData);

        void ChannelQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long channelId,
            SqlKata.Query channelQuery);

        void ChannelQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long channelId,
            QueryResult.Dto.Routes.Channel.Services.Get.ChannelDto channelQueryResultDto);

    }
}
