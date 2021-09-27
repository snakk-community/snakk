namespace Snakk.API.PluginFramework.Hooks.Routes.Comment.Services.Get
{
    public interface IService : IPlugin
    {
        void Before(
            object pluginRequestData,
            dynamic pluginData,
            long commentId);

        void After(
            object pluginRequestData,
            dynamic pluginData,
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto,
            dynamic responseData);

        void CommentQueryBuilderBefore(
            object pluginRequestData,
            dynamic pluginData,
            long commentId,
            SqlKata.Query commentQuery);

        void CommentQueryBuilderAfter(
            object pluginRequestData,
            dynamic pluginData,
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto);

    }
}
