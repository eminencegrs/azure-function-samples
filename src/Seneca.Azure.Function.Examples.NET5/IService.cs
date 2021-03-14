using System.Threading.Tasks;

namespace Seneca.AzureFunctions.NET5.Sample
{
    public interface IService
    {
        Task Handle();
    }
}
