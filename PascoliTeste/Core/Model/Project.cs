using System.Collections.Generic;

namespace Core.Model
{
    public class Project
    {
        public Guid Id { get; set; }
        public Guid? ResponsibilityUserId { get; set; }
        public User ResponsibilityUser { get; set; }
        public Guid CreateUserId { get; set; }
        public User CreateUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartProjectDate { get; set; }
        public DateTime? EndProjectDate { get; set; }
        public int Status { get; set; }

        public static implicit operator Project(DataAccess.Entites.Projects projects)
        {
            if (projects == null) return null;

            return new Project
            {
                Id = projects.Id,
                ResponsibilityUserId = projects.ResponsibilityUserId,
                CreateUserId = projects.CreateUserId,
                Title = projects.Title,
                Description = projects.Description,
                StartProjectDate = projects.StartProjectDate,
                EndProjectDate = projects.EndProjectDate,
                Status = projects.Status
            };
        }
        public static implicit operator DataAccess.Entites.Projects(Project project)
        {
            if (project == null) return null;

            return new DataAccess.Entites.Projects
            {
                Id = project.Id,
                ResponsibilityUserId = project.ResponsibilityUserId,
                CreateUserId = project.CreateUserId,
                Title = project.Title,
                Description = project.Description,
                StartProjectDate = project.StartProjectDate,
                EndProjectDate = project.EndProjectDate,
                Status = project.Status
            };
        }
        public static implicit operator Project(DataAccess.Model.Project project)
        {
            if (project == null) return null;

            return new Project
            {
                Id = project.Id,
                ResponsibilityUserId = project.ResponsibilityUserId,
                ResponsibilityUser = project.ResponsibilityUser, // Assuming there is an implicit operator in User class too
                CreateUserId = project.CreateUserId,
                CreateUser = project.CreateUser, // Assuming there is an implicit operator in User class too
                Title = project.Title,
                Description = project.Description,
                StartProjectDate = project.StartProjectDate,
                EndProjectDate = project.EndProjectDate,
                Status = project.Status
            };
        }
        public static implicit operator DataAccess.Model.Project(Project project)
        {
            if (project == null) return null;
            return new DataAccess.Model.Project
            {
                Id = project.Id,
                ResponsibilityUserId = project.ResponsibilityUserId,
                ResponsibilityUser = project.ResponsibilityUser, // Assuming there is an implicit operator in Users class too
                CreateUserId = project.CreateUserId,
                CreateUser = project.CreateUser, // Assuming there is an implicit operator in Users class too
                Title = project.Title,
                Description = project.Description,
                StartProjectDate = project.StartProjectDate,
                EndProjectDate = project.EndProjectDate,
                Status = project.Status
            };
        }

        public static List<Project> listConverte(List<DataAccess.Entites.Projects> listDb)
        {
            if (listDb.Count == 0) return null;

            var list = new List<Project>();

            foreach (var item in listDb)
            {
                list.Add(item);
            }

            return list;
        }
    }
}

