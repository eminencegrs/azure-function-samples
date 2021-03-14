using System.Threading.Tasks;

namespace Seneca.AzureFunctions.NET5.Sample
{
    public class Service : IService
    {
        public Task Handle()
        {
            return Task.CompletedTask;
        }
    }
}
