using Core.Model;
using System;

namespace WEBAPI.Model.ProjectDto.Request
{
    public class UpdateResponsibilityProjectRequestDto
    {
        public Guid IdProject { get; set; }
        public Guid ResponsibilityUserId { get; set; }

        public static implicit operator Project(UpdateResponsibilityProjectRequestDto dto)
        {
            if (dto == null) return null;

            return new Project
            {
                Id = dto.IdProject,
                ResponsibilityUserId = dto.ResponsibilityUserId,
            };
        }

        public static implicit operator UpdateResponsibilityProjectRequestDto(Project project)
        {
            if (project == null) return null;

            return new UpdateResponsibilityProjectRequestDto
            {
                IdProject = project.Id,
                ResponsibilityUserId = project.ResponsibilityUserId.Value,
            };
        }
    }
}
