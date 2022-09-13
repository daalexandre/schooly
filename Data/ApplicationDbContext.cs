using Microsoft.EntityFrameworkCore;
using Schooly.Models;

namespace Schooly.Data
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<EducationHistory> EducationHistories { get; set; }
        public virtual DbSet<EducationLevel> EducationLevels { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {

        }
    }
}
