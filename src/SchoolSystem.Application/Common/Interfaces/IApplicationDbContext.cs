using Microsoft.EntityFrameworkCore;
using SchoolSystem.Domain.Entities;

namespace SchoolSystem.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Teacher> Teachers { get; }
    DbSet<Student> Students { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
