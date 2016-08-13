using System.Threading.Tasks;

namespace Common
{
    internal class EmailClient
    {
        public static async Task Send(string emailAddress, string orderSent, string message)
        {
            await Task.FromResult(false);
        }
    }
}