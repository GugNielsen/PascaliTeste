using Core.Model;
using System;

namespace WEBAPI.Model.ProjectDto.Request
{
    public class UpdateProjectRequestDto
    {
        public Guid IdProject { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public static implicit operator Project(UpdateProjectRequestDto dto)
        {
            if (dto == null) return null;

            return new Project
            {
                Id = dto.IdProject,
                Title = dto.Title,
                Description = dto.Description,
            };
        }

        public static implicit operator UpdateProjectRequestDto(Project project)
        {
            if (project == null) return null;

            return new UpdateProjectRequestDto
            {
                IdProject = project.Id,
                Title = project.Title,
                Description = project.Description,
            };
        }
    }
}
