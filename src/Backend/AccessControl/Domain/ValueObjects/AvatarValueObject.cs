using HeyRed.ImageSharp.Heif.Formats.Avif;
using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Webp;
using SixLabors.ImageSharp.Processing;

namespace AccessControl.Domain.ValueObjects
{
  public class AvatarValueObject : BaseValueObject<byte[]>
  {
    public new byte[] Value
    {
      get => GetResizedAvatarInWebpFormat(base.Value);
    }

    private const int MaxFileSizeInBytes = 500 * 1024;
    private const int MaxWidth = 200;
    private const int MaxHeight = 200;
    private readonly DecoderOptions _decoderOptions;

    public AvatarValueObject(byte[] value)
      : base(value)
    {
      Name = "Avatar";
      _decoderOptions = new DecoderOptions()
      {
        Configuration = new Configuration(
          new AvifConfigurationModule(),
          new JpegConfigurationModule(),
          new GifConfigurationModule(),
          new PngConfigurationModule(),
          new WebpConfigurationModule()
        )
      };
      Validate();
    }

    public override void Validate()
    {
      if (Value == null || Value.Length == 0)
      {
        AddError(new ErrorValueObject(Name, $"{Name} is empty or null"));
        return;
      }

      if (Value.Length > MaxFileSizeInBytes)
      {
        AddError(
          new ErrorValueObject(Name, $"{Name} size exceeds the maximum allowed size of 500 KB")
        );
        return;
      }

      try
      {
        using var stream = new MemoryStream(Value);
        using var image = Image.Load(_decoderOptions, stream);

        if (
          image.Metadata.DecodedImageFormat != null
          && !IsAllowedFormat(image.Metadata.DecodedImageFormat)
        )
        {
          AddError(new ErrorValueObject(Name, $"{Name} format is not supported"));
          return;
        }

        if (image.Width != image.Height)
        {
          AddError(new ErrorValueObject(Name, $"{Name} dimensions are not square"));
          return;
        }
      }
      catch (Exception exception)
      {
        AddError(new ErrorValueObject(Name, $"{Name} is not a valid image: " + exception.Message));
      }
    }

    private static bool IsAllowedFormat(IImageFormat format)
    {
      return format.Name.Equals("JPEG", StringComparison.OrdinalIgnoreCase)
        || format.Name.Equals("PNG", StringComparison.OrdinalIgnoreCase)
        || format.Name.Equals("GIF", StringComparison.OrdinalIgnoreCase)
        || format.Name.Equals("AVIF", StringComparison.OrdinalIgnoreCase)
        || format.Name.Equals("WEBP", StringComparison.OrdinalIgnoreCase);
    }

    public byte[] GetResizedAvatarInWebpFormat(byte[] value)
    {
      using var stream = new MemoryStream(value);
      using var image = Image.Load(_decoderOptions, stream);

      if (image.Width != MaxWidth || image.Height != MaxHeight)
      {
        image.Mutate(x =>
          x.Resize(
            new ResizeOptions { Size = new Size(MaxWidth, MaxHeight), Mode = ResizeMode.Crop }
          )
        );
      }

      using var outputStream = new MemoryStream();
      image.SaveAsWebp(outputStream);
      return outputStream.ToArray();
    }
  }
}
