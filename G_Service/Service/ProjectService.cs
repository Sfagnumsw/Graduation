﻿using G_DAL.Entity;
using G_DAL.Interface;
using G_Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_Service.Service
{
    public class ProjectService : IBaseService<Project>
    {
        private readonly ILogger<ProjectService> _logger;
        private readonly IBaseAction<Project> _repos;
        public ProjectService(ILogger<ProjectService> logger, IBaseAction<Project> repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public async Task<Project> Create(Project model)
        {
            Project project = null;
            try
            {
                var projects = await _repos.GetAll();
                if (projects.Where(i => i.Team == model.Team).Any())
                {
                    throw new Exception("Указанная команда уже работает над другим проектом");
                }
                project = await _repos.Create(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return project;
        }

        public async Task<Project> Get(int objId)
        {
            Project project = null;
            try
            {
                project = await _repos.Get(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return project;
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            IEnumerable<Project> projects = new List<Project>();
            try
            {
                projects = await _repos.GetAll();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return projects;
        }

        public async System.Threading.Tasks.Task Remove(int objId)
        {
            try
            {
                await _repos.Remove(objId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }
    }
}
