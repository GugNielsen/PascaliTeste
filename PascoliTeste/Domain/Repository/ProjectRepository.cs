using Dapper;
using DataAccess.Context;
using DataAccess.Entites;
using DataAccess.Model;
using DataAccess.Repository.GenereicRepository;
using DataAccess.Repository.Interfaces;

public class ProjectRepository : BaseRepository<Projects>, IProjectRepository
{
    private readonly IDataContext _dataContext;

    public ProjectRepository(IDataContext dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> UpdateProjectTitleAndDescriptionAsync(Projects project)
    {
        string query = @"UPDATE Projects 
                         SET Title = @Title, Description = @Description
                         WHERE Id = @Id";
        int rowsAffected = await _dataContext.Connection.ExecuteAsync(query, new { project.Id, project.Title, project.Description });
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateProjectEndDateAndStatusAsync(Projects project)
    {
        string query = @"UPDATE Projects 
                         SET EndProjectDate = @EndProjectDate, Status = @Status
                         WHERE Id = @Id";
        int rowsAffected = await _dataContext.Connection.ExecuteAsync(query, new { project.Id, project.EndProjectDate, project.Status });
        return rowsAffected > 0;
    }

    public async Task<bool> UpdateProjectResponsibilityAsync(Projects project)
    {
        string query = @"UPDATE Projects 
                         SET  ResponsibilityUserId = @ResponsibilityUserId
                         WHERE Id = @Id";
        int rowsAffected = await _dataContext.Connection.ExecuteAsync(query, new { project.Id, project.ResponsibilityUserId });
        return rowsAffected > 0;
    }

    public async Task<bool> DeleteProjectyAsync(Guid projectId)
    {
        string query = @"DELETE Projects 
                         WHERE Id = @projectId";
        int rowsAffected = await _dataContext.Connection.ExecuteAsync(query, new { projectId });
        return rowsAffected > 0;
    }

    public async Task<Project> GetProjectByIdAsync(Guid id)
    {
        string query = @"
            SELECT 
                p.*, 
                cu.*,
                ru.* 
            FROM 
                Projects p 
            LEFT JOIN 
                Users cu ON p.CreateUserId = cu.UserId 
            LEFT JOIN 
                Users ru ON p.ResponsibilityUserId = ru.UserId 
            WHERE 
                p.Id = @Id";

        var project = await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                return project;
            },
            new { Id = id },
            splitOn: "UserId,UserId");

        return project.FirstOrDefault();
    }

    public async Task<List<Project>> GetProjectsByStatusAsync(int status)
    {
        string query = @"
            SELECT 
                p.*, 
                cu.*,
                ru.* 
            FROM 
                Projects p 
            LEFT JOIN 
                Users cu ON p.CreateUserId = cu.UserId 
            LEFT JOIN 
                Users ru ON p.ResponsibilityUserId = ru.UserId 
            WHERE 
                p.Status = @Status";

        var projects = new List<Project>();

        await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                projects.Add(project);
                return project;
            },
            new { Status = status },
            splitOn: "UserId,UserId");

        return projects;
    }

    public async Task<List<Project>> GetProjectsByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        string query = @"
            SELECT 
                p.*, 
                cu.*,
                ru.* 
            FROM 
                Projects p 
            LEFT JOIN 
                Users cu ON p.CreateUserId = cu.UserId 
            LEFT JOIN 
                Users ru ON p.ResponsibilityUserId = ru.UserId 
            WHERE 
                p.StartProjectDate >= @StartDate AND p.EndProjectDate <= @EndDate";

        var projects = new List<Project>();

        await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                projects.Add(project);
                return project;
            },
            new { StartDate = startDate, EndDate = endDate },
            splitOn: "UserId,UserId");

        return projects;
    }

    public async Task<List<Project>> GetProjectsByTitleOrDescriptionAsync(string keyword)
    {
        string query = @"
            SELECT 
                p.*, 
                cu.*,
                ru.* 
            FROM 
                Projects p 
            LEFT JOIN 
                Users cu ON p.CreateUserId = cu.UserId 
            LEFT JOIN 
                Users ru ON p.ResponsibilityUserId = ru.UserId 
            WHERE 
                p.Title LIKE @Keyword OR p.Description LIKE @Keyword";

        var projects = new List<Project>();

        await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                projects.Add(project);
                return project;
            },
            new { Keyword = "%" + keyword + "%" },
            splitOn: "UserId,UserId");

        return projects;
    }

    public async Task<List<Project>> GetProjectsByResponsibilityUserIdAsync(Guid responsibilityUserId)
    {
        string query = @"
            SELECT 
                p.*, 
                cu.*,
                ru.* 
            FROM 
                Projects p 
            LEFT JOIN 
                Users cu ON p.CreateUserId = cu.UserId 
            LEFT JOIN 
                Users ru ON p.ResponsibilityUserId = ru.UserId 
            WHERE 
                p.ResponsibilityUserId = @ResponsibilityUserId";

        var projects = new List<Project>();

        await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                projects.Add(project);
                return project;
            },
            new { ResponsibilityUserId = responsibilityUserId },
            splitOn: "UserId,UserId");

        return projects;
    }

    public async Task<List<Project>> GetProjectsByCreateUserIdAsync(Guid createUserId)
    {
        string query = @"
        SELECT 
            p.*, 
            cu.*,
            ru.* 
        FROM 
            Projects p 
        LEFT JOIN 
            Users cu ON p.CreateUserId = cu.UserId 
        LEFT JOIN 
            Users ru ON p.ResponsibilityUserId = ru.UserId 
        WHERE 
            p.CreateUserId = @CreateUserId";

        var projects = new List<Project>();

        await _dataContext.Connection.QueryAsync<Project, Users, Users, Project>(
            query,
            (project, createUser, responsibilityUser) =>
            {
                project.CreateUser = createUser;
                project.ResponsibilityUser = responsibilityUser;
                projects.Add(project);
                return project;
            },
            new { CreateUserId = createUserId },
            splitOn: "UserId,UserId");

        return projects;
    }
}
