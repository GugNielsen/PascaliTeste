
using Core.Helpers.Validation;
using Core.Model;
using Core.Services.Interfaces;
using DataAccess.Repository.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Components.Web;

namespace Core.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IEmailService _emailService;
        private readonly IUserServices _userServices;

        public ProjectService(IProjectRepository projectRepository, IEmailService emailService, IUserServices userServices)
        {
            _projectRepository = projectRepository;
            _emailService = emailService;
            _userServices = userServices;
        }

        public async Task<Guid> CreateAsync(Project project)
        {
            const int beggar = 1;

            project.StartProjectDate = DateTime.Now;
            project.Status = beggar;

            await ProjectValidatedAsync(project);

            return await _projectRepository.InsertAsync(project);
        }
        public async Task<bool> UpdateProjectTitleAndDescriptionAsync(Project project)
        {
            await ProjectValidatedAsync(project);
            return await _projectRepository.UpdateProjectTitleAndDescriptionAsync(project);
        }

        public async Task<bool> UpdateProjectEndDateAndStatusAsync(Project project)
        {
            const int concluded = 3;
            var projectdb = await GetProjectByIdAsync(project.Id);
            if (projectdb == null) throw new ValidationException(new List<string> { "Projeto não cadastrado" });

            if (projectdb.Status == concluded)
                throw new ValidationException(new List<string> { "Não pode Modficar Projeto já finalizafo" });
      
         

            return await _projectRepository.UpdateProjectEndDateAndStatusAsync(project);
        }
        public async Task<bool> UpdateProjectResponsibilityAsync(Project project)
        {
            const int concluded = 3;
            var projectdb = await GetProjectByIdAsync(project.Id);
            if (projectdb == null) throw new ValidationException(new List<string> { "Projeto não cadastrado" });

            if (projectdb.Status == concluded)
                throw new ValidationException(new List<string> { "Não pode Modficar Projeto já finalizafo" });

            if (project.ResponsibilityUserId == projectdb.ResponsibilityUserId)
                throw new ValidationException(new List<string> { "O usuário com o ID " + project.ResponsibilityUserId + " já é o responsável por este projeto. Por favor, escolha outro usuário ou verifique se este é realmente o usuário que deseja atribuir." });

            var res = await _projectRepository.UpdateProjectResponsibilityAsync(project);

            if (res)
            {
                var user = await _userServices.GetByIdAsync(project.ResponsibilityUserId.Value);

                if (user != null)
                {
                    var emailSubject = "Atualização de Responsabilidade de Projeto";
                    var emailMessage = $"Olá {user.FirstName}, você foi designado como responsável pelo projeto: {project.Title}.";
                    await _emailService.SendEmailAsync(user.Email, emailSubject, emailMessage);
                }
              
            }

            return res;
        }

        public async Task<bool> DeleterPojectAsync(Guid projectId)
        {
            const int concluded = 3;
            var projectdb = await GetProjectByIdAsync(projectId);
            if (projectdb == null) throw new ValidationException(new List<string> { "Projeto não cadastrado" });

            if (projectdb.Status == concluded)
                throw new ValidationException(new List<string> { "Não pode Remover Projeto já finalizado" });

            if (projectdb.ResponsibilityUserId !=null )
                throw new ValidationException(new List<string> { "Não pode Remover Projeto que tenha Resposavel" });

            return await _projectRepository.DeleteProjectyAsync(projectId);
        }
        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task<List<Project>> GetProjectsByStatusAsync(int status)
        {
            var result = await _projectRepository.GetProjectsByStatusAsync(status);
            var list = new List<Project>();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public async Task<List<Project>> GetProjectsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            var result = await _projectRepository.GetProjectsByDateRangeAsync(startDate, endDate);

            var list = new List<Project>();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public async Task<List<Project>> GetProjectsByTitleOrDescriptionAsync(string keyword)
        {
            var result = await _projectRepository.GetProjectsByTitleOrDescriptionAsync(keyword);
            var list = new List<Project>();
            foreach (var item in result)
            {
                list.Add(item);
            }
            return list;
        }

        public async Task<List<Project>> GetProjectsByResponsibilityUserIdAsync(Guid responsibilityUserId)
        {
            var result = await _projectRepository.GetProjectsByResponsibilityUserIdAsync(responsibilityUserId);

            var list = new List<Project>();

            foreach (var item in result)
            {
                list.Add(item);
            }

            return list;
        }

        public async Task<List<Project>> GetProjectsByCreateUserIdAsync(Guid createUserId)
        {
            var result = await _projectRepository.GetProjectsByCreateUserIdAsync(createUserId);
            var list = new List<Project>();

            foreach (var item in result)
            {
                list.Add(item);
            }

            return list;
        }

        private async Task ProjectValidatedAsync(Project project)
        {
            var validator = new ProjectCreateUpdateValidator();
            var validationResult = await validator.ValidateAsync(project);
            if (!validationResult.IsValid)
            {
                var errors = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                throw new ValidationException(errors);
            }
        }

    }
}
