namespace Snakk.API.PluginFramework.Hooks.Routes.Thread.Comment.List.Services.Get
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
            QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto commentQueryResultDto,
            dynamic responseData);

        void CommentListQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long threadId,
            SqlKata.Query commentListQuery);

        void CommentListQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long threadId,
            QueryResult.Dto.Routes.Thread.Comment.List.Services.Get.CommentListDto commentListQueryResultDto);

    }
}
