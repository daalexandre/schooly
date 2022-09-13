using Schooly.Enums;

namespace Schooly.Models
{
    public record Student ()
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime Birthdate { get; set; }
        public int? EducationLevelId { get; set; }
        public int EducationHistoryId { get; set; }
    }
}
