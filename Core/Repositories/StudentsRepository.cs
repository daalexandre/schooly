using Microsoft.EntityFrameworkCore;
using Schooly.Core.IRepositories;
using Schooly.Data;
using Schooly.Models;
using System.Diagnostics;

namespace Schooly.Core.Repositories
{
    public class StudentsRepository : GenericRepository<Student>, IStudentsRepository
    {
        public StudentsRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public override async Task<IEnumerable<Student>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[{nameof(StudentsRepository)}] -> {nameof(All)}");
                return new List<Student>();
            }
        }

        public override async Task<bool> UpdateInsert(Student entity)
        {
            try
            {
                var existingStudent = await dbSet.Where(t => t.Id == entity.Id).FirstOrDefaultAsync();

                if (existingStudent is null)
                    return await Add(entity);

                existingStudent.FirstName = entity.FirstName;
                existingStudent.LastName = entity.LastName;
                existingStudent.Email = entity.Email;
                existingStudent.Birthdate = entity.Birthdate;
                existingStudent.EducationLevelId = entity.EducationLevelId;

                dbSet.Update(existingStudent);

                return true;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[{nameof(StudentsRepository)}] -> {nameof(UpdateInsert)}");
                return false;
            }
        }

        public override async Task<bool> Delete(int id)
        {
            try
            {
                var existingStudent = await dbSet.Where(t => t.Id == id).FirstOrDefaultAsync();
                if (existingStudent is not null)
                {
                    dbSet.Remove(existingStudent);
                    return true;
                }
                return false;
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, $"[{nameof(StudentsRepository)}] -> {nameof(Delete)}");
                return false;
            }
        }

    }
}
