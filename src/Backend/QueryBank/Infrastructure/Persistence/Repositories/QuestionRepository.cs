using Microsoft.EntityFrameworkCore;
using QueryBank.Application.Repositories;
using QueryBank.Application.Responses;
using QueryBank.Infrastructure.Persistence.Models;
using Shared.Infrastructure.Persistence.Repositories;

namespace QueryBank.Infrastructure.Persistence.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository<Question>
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }

        public Task<Question> AddAsync(RegisterQuestionApplicationResponse entity)
        {
            var question = new Question
            {
                QuestionId = Guid.Parse(entity.QuestionId),
                Name = entity.Name,
                Disabled = entity.Disabled,
            };
            return AddAsync(question);
        }

        public Task<Question> UpdateAsync(Guid id, UpdateQuestionApplicationResponse entity)
        {
            var question = new Question { QuestionId = id };
            if (entity.Name != null)
            {
                question.Name = entity.Name;
            }
            if (entity.Disabled != null)
            {
                question.Disabled = (bool)entity.Disabled;
            }
            return UpdateAsync(id, question);
        }
    }
}
