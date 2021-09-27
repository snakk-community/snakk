namespace Snakk.API.PluginFramework.Hooks.Routes.Comment.Services
{
    public interface IGet : IPlugin
    {
        void Before(
            long commentId,
            Dto.Routes.Comment.Get.ResponseDto responseDto);

        void After(
            long commentId,
            Dto.Routes.Comment.Get.ResponseDto responseDto);

        void CommentQueryBuilderBefore(
            long commentId,
            SqlKata.Query commentQuery);

        void CommentQueryBuilderAfter(
            long commentId,
            QueryResult.Dto.Routes.Comment.Services.Get.CommentDto commentQueryResultDto);

    }
}
