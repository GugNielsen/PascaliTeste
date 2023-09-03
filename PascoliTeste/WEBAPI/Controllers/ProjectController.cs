using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Model;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WEBAPI.Model.ProjectDto.WEBAPI.Model.ProjectDto;
using WEBAPI.Model.ProjectDto.Request;
using WEBAPI.Model.ProjectDto.Response;
using Core.Services;
using Microsoft.AspNetCore.Authorization;

namespace WEBAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
  
  
        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProjectRequestDto project)
        {
            try
            {
                Guid result = await _projectService.CreateAsync(project);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateTitleAndDescription")]
        public async Task<IActionResult> UpdateProjectTitleAndDescription(UpdateProjectRequestDto project)
        {
            try
            {
                bool result = await _projectService.UpdateProjectTitleAndDescriptionAsync(project);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateStatus")]
        public async Task<IActionResult> UpdateProjectEndDateAndStatus(UpdateStatusProjectRequestDto project)
        {
            try
            {
                bool result = await _projectService.UpdateProjectEndDateAndStatusAsync(project);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpPatch]
        [Route("UpdateResponsibility")]
        public async Task<IActionResult> UpdateResponsibility(UpdateResponsibilityProjectRequestDto project)
        {
            try
            {
                bool result = await _projectService.UpdateProjectResponsibilityAsync(project);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAsync([FromBody] Guid projectId)
        {
            try
            {
                bool result = await _projectService.DeleterPojectAsync(projectId);
                    return Ok(result);
            }
               catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }

        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetProjectById(Guid id)
        {
            try
            {
                ProjectResponseDto result = await _projectService.GetProjectByIdAsync(id);
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByStatus/{status}")]
        public async Task<IActionResult> GetProjectsByStatus(int status)
        {
            try
            {
                List<ProjectResponseDto> result = ProjectResponseDto.ListConverted( await _projectService.GetProjectsByStatusAsync(status));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByDateRange/{startDate}/{endDate}")]
        public async Task<IActionResult> GetProjectsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                List<ProjectResponseDto> result = ProjectResponseDto.ListConverted(await _projectService.GetProjectsByDateRangeAsync(startDate, endDate));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByTitleOrDescription/{keyword}")]
        public async Task<IActionResult> GetProjectsByTitleOrDescription(string keyword)
        {
            try
            {
               List<ProjectResponseDto> result = ProjectResponseDto.ListConverted(await _projectService.GetProjectsByTitleOrDescriptionAsync(keyword));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByResponsibilityUserId/{responsibilityUserId}")]
        public async Task<IActionResult> GetProjectsByResponsibilityUserId(Guid responsibilityUserId)
        {
            try
            {
                List<ProjectResponseDto> result = ProjectResponseDto.ListConverted(await _projectService.GetProjectsByResponsibilityUserIdAsync(responsibilityUserId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetByCreateUserId/{createUserId}")]
        public async Task<IActionResult> GetProjectsByCreateUserId(Guid createUserId)
        {
            try
            {
                List<ProjectResponseDto> result = ProjectResponseDto.ListConverted(await _projectService.GetProjectsByCreateUserIdAsync(createUserId));
                return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(new { errors = ex.Errors });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
            }
        }
    }
}
