using DevQuestions.Domain.Tags;

namespace DevQuestions.Application.Tags;

public interface ITagsReadDbContext
{
    IQueryable<Tag> TagsRead { get; }
}