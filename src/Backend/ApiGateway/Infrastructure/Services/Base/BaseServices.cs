using Grpc.Net.Client;
using ProtoBuf.Grpc.Client;

namespace ApiGateway.Infrastructure.Services.Base
{
  public abstract class BaseServices<TMicroServiceClient>
    where TMicroServiceClient : class
  {
    private readonly HttpClientHandler? _httpClientHandler;
    private GrpcChannel? _channel;
    protected TMicroServiceClient Client { get; private set; } = default!;

    public BaseServices(HttpClientHandler? httpClientHandler = null)
    {
      _httpClientHandler = httpClientHandler;
    }

    protected void CreateChannel(string baseAddress)
    {
      if (_channel is null)
      {
        _channel = GrpcChannel.ForAddress(
          baseAddress,
          new GrpcChannelOptions
          {
            HttpClient = _httpClientHandler is null ? null : new HttpClient(_httpClientHandler)
          }
        );
        Client = _channel.CreateGrpcService<TMicroServiceClient>();
      }
    }
  }
}
