using Core.Model;

namespace WEBAPI.Model.ProjectDto.Response
{
    public class ProjectResponseDto
    {
        public Guid Id { get; set; }
        public UserNameResponseDto? ResponsibilityUser { get; set; }
        public UserNameResponseDto CreateUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartProjectDate { get; set; }
        public DateTime? EndProjectDate { get; set; }
        public int Status { get; set; }

        public static implicit operator Project(ProjectResponseDto dto)
        {
            if (dto == null) return null;

            return new Project
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                StartProjectDate = dto.StartProjectDate,
                EndProjectDate = dto.EndProjectDate,
                Status = dto.Status,
                CreateUser = dto.CreateUser,
                ResponsibilityUser = dto.ResponsibilityUser,
            };
        }
        public static implicit operator ProjectResponseDto(Project project)
        {
            if (project == null) return null;

            return new ProjectResponseDto
            {
                Id = project.Id,
                Title = project.Title,
                Description = project.Description,
                StartProjectDate = project.StartProjectDate,
                EndProjectDate = project.EndProjectDate,
                Status = project.Status,
                CreateUser = project.CreateUser,
                ResponsibilityUser = project.ResponsibilityUser,
            };
        }

        public static List<ProjectResponseDto>ListConverted(List<Project> list)
        {
            if (list.Count == 0) return null;
        
            var res = new List<ProjectResponseDto>();

            foreach (var item in list)
            {
                res.Add(item);
            }
            return res;
        }
    }
}
