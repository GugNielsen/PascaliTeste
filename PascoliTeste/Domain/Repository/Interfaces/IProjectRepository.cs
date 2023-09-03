using DataAccess.Entites;
using DataAccess.Model;

namespace DataAccess.Repository.Interfaces
{
    public interface IProjectRepository : IBaseRepository<Projects>
    {
        Task<bool> UpdateProjectTitleAndDescriptionAsync(Projects project);
        Task<bool> UpdateProjectEndDateAndStatusAsync(Projects project);
        Task<bool> UpdateProjectResponsibilityAsync(Projects project);
        Task<bool> DeleteProjectyAsync(Guid projectId);
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<List<Project>> GetProjectsByStatusAsync(int status);
        Task<List<Project>> GetProjectsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<List<Project>> GetProjectsByTitleOrDescriptionAsync(string keyword);
        Task<List<Project>> GetProjectsByResponsibilityUserIdAsync(Guid responsibilityUserId);
        Task<List<Project>> GetProjectsByCreateUserIdAsync(Guid createUserId);
    }
}
