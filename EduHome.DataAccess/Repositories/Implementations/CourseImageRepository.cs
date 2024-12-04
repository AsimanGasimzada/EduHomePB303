using EduHome.Core.Entities;
using EduHome.DataAccess.Contexts;
using EduHome.DataAccess.Repositories.Abstractions;
using EduHome.DataAccess.Repositories.Implementations.Generic;

namespace EduHome.DataAccess.Repositories.Implementations;

internal class CourseImageRepository : Repository<CourseImage>, ICourseImageRepository
{
    public CourseImageRepository(AppDbContext context) : base(context)
    {
    }
}
