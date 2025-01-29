using DevQuestions.Application.Tags;
using DevQuestions.Domain.Tags;
using Microsoft.EntityFrameworkCore;

namespace DevQuestion.Infrastructure.Postgres.Tags;

public class TagsReadDbContext : DbContext, ITagsReadDbContext
{
    public DbSet<Tag> Tags { get; set; }

    public IQueryable<Tag> TagsRead => Tags.AsNoTracking().AsQueryable();
}