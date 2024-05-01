using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class ProvinceRepository
    : BaseRepository<ProvinceModel>,
      IProvinceRepository<ProvinceModel>
  {
    public ProvinceRepository(ApplicationDbContext context)
      : base(context) { }

    public new async Task<IEnumerable<ProvinceModel>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    )
    {
      var data = await base.GetWithPaginationAsync(page, limit, sort, order, filter, filterBy);
      data.ToList()
        .ForEach(province =>
        {
          if (Context.Entry(province).Reference(p => p.Country).IsLoaded == false)
          {
            Context.Entry(province).Reference(p => p.Country).Load();
          }
        });
      return data;
    }

    public Task<ProvinceModel> AddAsync(RegisterProvinceApplicationResponse entity)
    {
      var province = new ProvinceModel
      {
        ProvinceId = Guid.Parse(entity.ProvinceId),
        Name = entity.Name,
        CountryId = Guid.Parse(entity.CountryId),
        Disabled = entity.Disabled,
      };
      return AddAsync(province);
    }

    public Task<ProvinceModel> UpdateAsync(Guid id, UpdateProvinceApplicationResponse entity)
    {
      var province = new ProvinceModel { ProvinceId = id };
      if (entity.Name != null)
      {
        province.Name = entity.Name;
      }
      if (entity.CountryId != null)
      {
        province.CountryId = Guid.Parse(entity.CountryId);
      }
      if (entity.Disabled != null)
      {
        province.Disabled = (bool)entity.Disabled;
      }
      return UpdateAsync(id, province);
    }
  }
}
