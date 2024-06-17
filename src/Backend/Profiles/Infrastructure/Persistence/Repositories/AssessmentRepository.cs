using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Profiles.Application.Repositories;
using Profiles.Application.Responses;
using Profiles.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace Profiles.Infrastructure.Persistence.Repositories
{
  public class AssessmentRepository(ApplicationDbContext context)
    : BaseRepository<AssessmentModel>(context),
      IAssessmentRepository<AssessmentModel>
  {
    public async Task<AssessmentModel> AddAsync(RegisterAssessmentApplicationResponse entity)
    {
      var assessment = new AssessmentModel
      {
        AssessmentId = Guid.Parse(entity.AssessmentId),
        ProfessionalId = Guid.Parse(entity.ProfessionalId),
        RoleId = Guid.Parse(entity.RoleId),
        SquadId = Guid.Parse(entity.SquadId),
      };

      var role =
        await Context
          .Set<RoleModel>()
          .Include(r => r.RolePerSkills)
          .ThenInclude(rps => rps.Skill)
          .ThenInclude(s => s.SubSkills)
          .FirstOrDefaultAsync(r => r.RoleId == assessment.RoleId)
        ?? throw new Exception("Role not found");

      foreach (var rolePerSkill in role.RolePerSkills)
      {
        foreach (var subSkill in rolePerSkill.Skill.SubSkills)
        {
          assessment.Results.Add(
            new ResultModel
            {
              ResultId = Guid.NewGuid(),
              AssessmentId = assessment.AssessmentId,
              SubSkillId = subSkill.SubSkillId,
              Result = 0,
              DateTime = DateTime.UtcNow,
            }
          );
        }
      }

      return await base.AddAsync(assessment);
    }

    public Task<AssessmentModel> UpdateAsync(Guid id, UpdateAssessmentApplicationResponse entity)
    {
      var Assessment = new AssessmentModel { AssessmentId = id };
      if (entity.ProfessionalId != null)
      {
        Assessment.ProfessionalId = Guid.Parse(entity.ProfessionalId);
      }
      if (entity.RoleId != null)
      {
        Assessment.RoleId = Guid.Parse(entity.RoleId);
      }
      if (entity.SquadId != null)
      {
        Assessment.SquadId = Guid.Parse(entity.SquadId);
      }
      return UpdateAsync(id, Assessment);
    }

    public new async Task<IEnumerable<AssessmentModel>> GetWithPaginationAsync(
      int page,
      int limit,
      string? sort = null,
      string order = "asc",
      string? filter = null,
      string? filterBy = null
    )
    {
      var query = Context
        .Set<AssessmentModel>()
        .Include(a => a.Squad)
        .Include(a => a.Professional)
        .Include(a => a.Role)
        .ThenInclude(r => r.RolePerSkills)
        .ThenInclude(rps => rps.Skill)
        .ThenInclude(s => s.SubSkills)
        .ThenInclude(ss => ss.Results)
        .AsQueryable();

      if (!string.IsNullOrEmpty(filter) && !string.IsNullOrEmpty(filterBy))
      {
        query = ApplyFilter(query, filterBy, filter);
      }

      if (!string.IsNullOrEmpty(sort))
      {
        query = ApplySorting(query, sort, order);
      }

      var assessments = await query.Skip((page - 1) * limit).Take(limit).ToListAsync();

      return assessments;
    }

    private IQueryable<AssessmentModel> ApplyFilter(
      IQueryable<AssessmentModel> query,
      string filterBy,
      string filter
    )
    {
      var parameter = Expression.Parameter(typeof(AssessmentModel), "a");
      var property = Expression.Property(parameter, filterBy);
      var value = Expression.Constant(filter);
      Expression filterExpression;

      if (property.Type == typeof(string))
      {
        filterExpression = Expression.Call(property, "Contains", null, value);
      }
      else if (property.Type == typeof(Guid))
      {
        if (Guid.TryParse(filter, out var guidValue))
        {
          value = Expression.Constant(guidValue, typeof(Guid));
          filterExpression = Expression.Equal(property, value);
        }
        else
        {
          throw new ArgumentException("Invalid GUID format");
        }
      }
      else if (property.Type == typeof(bool))
      {
        if (bool.TryParse(filter, out var boolValue))
        {
          value = Expression.Constant(boolValue, typeof(bool));
          filterExpression = Expression.Equal(property, value);
        }
        else
        {
          throw new ArgumentException("Invalid boolean format");
        }
      }
      else if (property.Type == typeof(int))
      {
        if (int.TryParse(filter, out var intValue))
        {
          value = Expression.Constant(intValue, typeof(int));
          filterExpression = Expression.Equal(property, value);
        }
        else
        {
          throw new ArgumentException("Invalid integer format");
        }
      }
      else if (property.Type == typeof(long))
      {
        if (long.TryParse(filter, out var longValue))
        {
          value = Expression.Constant(longValue, typeof(long));
          filterExpression = Expression.Equal(property, value);
        }
        else
        {
          throw new ArgumentException("Invalid long format");
        }
      }
      else
      {
        throw new NotSupportedException($"Filtering not supported for type {property.Type}");
      }

      var lambda = Expression.Lambda<Func<AssessmentModel, bool>>(filterExpression, parameter);
      return query.Where(lambda);
    }

    private IQueryable<AssessmentModel> ApplySorting(
      IQueryable<AssessmentModel> query,
      string sort,
      string order
    )
    {
      var parameter = Expression.Parameter(typeof(AssessmentModel), "a");
      var property = Expression.Property(parameter, sort);
      var lambda = Expression.Lambda(property, parameter);

      var methodName = order.Equals("asc", StringComparison.CurrentCultureIgnoreCase)
        ? "OrderBy"
        : "OrderByDescending";
      var resultExpression = Expression.Call(
        typeof(Queryable),
        methodName,
        new Type[] { query.ElementType, property.Type },
        query.Expression,
        lambda
      );

      return query.Provider.CreateQuery<AssessmentModel>(resultExpression);
    }
  }
}
