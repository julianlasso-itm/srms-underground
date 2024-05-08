using Shared.Application.Interfaces;

namespace Shared.Infrastructure.Services
{
  public class StoreService : IStoreService
  {
    public string AddAsync(byte[] data)
    {
      Console.WriteLine("Adding data to store");
      return "https://store.com/data/1";
    }

    public void RemoveAsync(string path)
    {
      Console.WriteLine("Removing data from store");
    }
  }
}
