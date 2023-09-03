namespace WEBAPI.Model.ProjectDto
{
    using Core.Model;
    using System;

    namespace WEBAPI.Model.ProjectDto
    {
        public class UpdateStatusProjectRequestDto
        {
            public Guid Id { get; set; }
            public int Status { get; set; }

            public static implicit operator Project(UpdateStatusProjectRequestDto dto)
            {
                if (dto == null) return null;

                return new Project
                {
                    Id = dto.Id,
                    Status = dto.Status,
                };
            }

            public static implicit operator UpdateStatusProjectRequestDto(Project project)
            {
                if (project == null) return null;

                return new UpdateStatusProjectRequestDto
                {
                    Id = project.Id,
                    Status = project.Status,
                };
            }
        }
    }

}
