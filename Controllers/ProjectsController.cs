﻿using BugsTrackingSystem.Services;
using BugsTrackingSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BugsTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _serviceProject;
        public ProjectsController(IProjectsService serviceProject)
        {
            _serviceProject = serviceProject;
        }

        [HttpGet]
        

        public async Task<ActionResult<IEnumerable<ProjectViewModel>>> GetAllProjectsAsync()
        {
            return Ok(await _serviceProject.GetAllProjectsAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectViewModel>> GetProjectByIDAsync(int id)
        {
            return Ok(await _serviceProject.GetProjectByIDAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<ProjectViewModel>> CreateProjectAsync(ProjectCreateModel project)
        {
            return Ok(await _serviceProject.CreateProjectAsync(project));
        }
    }
}
