using Shared.Domain.ValueObjects;
using Shared.Domain.ValueObjects.Base;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats;

namespace AccessControl.Domain.ValueObjects
{
  public class AvatarValueObject : BaseValueObject<byte[]>
  {
    private const int MaxFileSizeInBytes = 500 * 1024;

    public AvatarValueObject(byte[] value)
      : base(value)
    {
      Name = "Avatar";
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
        using var image = Image.Load(stream);

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
  }
}
