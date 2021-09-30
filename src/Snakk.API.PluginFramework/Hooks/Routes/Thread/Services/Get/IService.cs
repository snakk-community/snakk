namespace Snakk.API.PluginFramework.Hooks.Routes.Thread.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            object pluginRequestData,
            dynamic pluginData,
            long threadId);

        void After(
            object pluginRequestData,
            dynamic pluginData,
            long threadId,
            QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto threadQueryResultDto,
            dynamic responseData);

        void ThreadQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long threadId,
            SqlKata.Query threadQuery);

        void ThreadQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long threadId,
            QueryResult.Dto.Routes.Thread.Services.Get.ThreadDto threadQueryResultDto);
    }
}
