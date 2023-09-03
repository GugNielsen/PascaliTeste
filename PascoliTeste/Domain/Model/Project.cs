using DataAccess.Entites;

namespace DataAccess.Model
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid? ResponsibilityUserId { get; set; }
        public Users ResponsibilityUser { get; set; }
        public Guid CreateUserId { get; set; }
        public Users CreateUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartProjectDate { get; set; }
        public DateTime? EndProjectDate { get; set; }
        public int Status { get; set; }

    
    }
}
