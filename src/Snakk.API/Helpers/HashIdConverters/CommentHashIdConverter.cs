using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface ICommentHashIdConverter : IBaseHashIdConverter
    {
    }

    public class CommentHashIdConverter : BaseHashIdConverter, ICommentHashIdConverter
    {
        public CommentHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("CommentHashidSecretSalt"))
        {
        }
    }
}
