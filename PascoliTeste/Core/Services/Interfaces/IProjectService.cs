using Core.Model;

namespace Core.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Guid> CreateAsync(Project project);
        Task<bool> UpdateProjectTitleAndDescriptionAsync(Project project);
        Task<bool> UpdateProjectEndDateAndStatusAsync(Project project);
        Task<bool> UpdateProjectResponsibilityAsync(Project project);
        Task<bool> DeleterPojectAsync(Guid projectId);
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<List<Project>> GetProjectsByStatusAsync(int status);
        Task<List<Project>> GetProjectsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Project>> GetProjectsByTitleOrDescriptionAsync(string keyword);
        Task<List<Project>> GetProjectsByResponsibilityUserIdAsync(Guid responsibilityUserId);
        Task<List<Project>> GetProjectsByCreateUserIdAsync(Guid createUserId);
    }
}
