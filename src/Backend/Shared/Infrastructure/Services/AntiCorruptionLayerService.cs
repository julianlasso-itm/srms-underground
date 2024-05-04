namespace Shared.Infrastructure.Services
{
  public class AntiCorruptionLayerService<TAntiCorruptionLayer>
    where TAntiCorruptionLayer : class, new()
  {
    private readonly TAntiCorruptionLayer _antiCorruptionLayer;

    public AntiCorruptionLayerService()
    {
      _antiCorruptionLayer = new TAntiCorruptionLayer();
    }

    public TAntiCorruptionLayer GetAntiCorruptionLayer()
    {
      return _antiCorruptionLayer;
    }
  }
}
