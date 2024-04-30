using Profiles.Domain.Entities.Structs;
using Profiles.Domain.ValueObjects;

namespace Profiles.Domain.Entities
{
  internal sealed class ProfessionalEntity
  {
    public ProfessionalIdValueObject ProfessionalId { get; set; }
    public NameValueObject Name { get; set; }
    public DisabledValueObject Disabled { get; set; }
    public EmailValueObject Email { get; set; }

    public ProfessionalEntity() { }

    public ProfessionalEntity(ProfessionalStruct data)
    {
      ProfessionalId = data.ProfessionalId;
      Name = data.Name;
      Email = data.Email;
      Disabled = data.Disabled;
    }

    public void Register(NameValueObject name, EmailValueObject email)
    {
      ProfessionalId = new ProfessionalIdValueObject(Guid.NewGuid().ToString());
      Email = email;
      Name = name;
      Disabled = new DisabledValueObject(false);
    }

    public void Enable()
    {
      Disabled = new DisabledValueObject(false);
    }

    public void Disable()
    {
      Disabled = new DisabledValueObject(true);
    }

    public void UpdateName(NameValueObject name)
    {
      Name = name;
    }

    public void UpdateEmail(EmailValueObject email)
    {
      Email = email;
    }
  }
}
