using System.Threading.Tasks;

namespace Snakk.API.Routes.Channel.Thread.List
{
    public interface IGet
    {
        Task<object> RunAsync(string groupUrlIdentifier);
    }

    public class Get : IGet
    {
        public Get()
        {
        }

        public async Task<object> RunAsync(string groupUrlIdentifier)
        {
            await Task.Run(() => { System.Threading.Thread.Sleep(1); });

            return new {
                groupUrlIdentifier = groupUrlIdentifier
            };
        }
    }
}
