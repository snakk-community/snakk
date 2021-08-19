using Microsoft.Extensions.Configuration;

namespace Snakk.API.Helpers.HashIdConverters
{
    public interface IUserHashIdConverter : IBaseHashIdConverter
    {
    }

    public class UserHashIdConverter : BaseHashIdConverter, IUserHashIdConverter
    {
        public UserHashIdConverter(IConfiguration configuration)
            : base(configuration.GetValue<string>("UserHashidSecretSalt"))
        {
        }
    }
}
