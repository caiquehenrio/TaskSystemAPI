using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystemApi.Data;
using TaskSystemApi.Models;
using TaskSystemApi.Repositories.Interfaces;

namespace TaskSystemApi.Repositories
{

    public class TaskRepository : ITaskRepository
    {

        private readonly TaskSystemDBContex _dbContext;

        public TaskRepository(TaskSystemDBContex systemDBContex)
        {

            _dbContext = systemDBContex;

        }

        public async Task<List<TaskModel>> FindAllTasks()
        {

            return await _dbContext.Tasks
                .Include(x => x.User)
                .ToListAsync();

        }

        public async Task<TaskModel> FindById(int id)
        {

            return await _dbContext.Tasks
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<TaskModel> Add(TaskModel task)
        {

            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;

        }

        public async Task<TaskModel> Update(TaskModel task, int id)
        {

            TaskModel taskById = await FindById(id);

            if(taskById == null) 
            {

                throw new Exception($"Task for ID {id} was not found in the database.");

            }

            taskById.Name = task.Name;
            taskById.Description = task.Description;
            taskById.Status = task.Status;
            taskById.UserId = task.UserId;

            _dbContext.Tasks.Update(taskById);
            await _dbContext.SaveChangesAsync();

            return taskById;

        }

        public async Task<bool> Delete(int id)
        {

            TaskModel taskById = await FindById(id);

            if (taskById == null)
            {

                throw new Exception($"Task for ID {id} was not found in the database.");

            }

            _dbContext.Tasks.Remove(taskById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }

}
