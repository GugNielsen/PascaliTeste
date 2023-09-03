using Core.Model;

namespace WEBAPI.Model.ProjectDto.Request
{
    public class CreateProjectRequestDto
    {
        public Guid CreateUserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static implicit operator Project(CreateProjectRequestDto dto)
        {
            if (dto == null) return dto;


            return new Project
            {
                CreateUserId = dto.CreateUserId,
                Title = dto.Title,
                Description = dto.Description,
            };
        }

        public static implicit operator CreateProjectRequestDto(Project project)
        {
            return new CreateProjectRequestDto
            {
                CreateUserId = project.CreateUserId,
                Title = project.Title,
                Description = project.Description,
            };
        }
    }
}
