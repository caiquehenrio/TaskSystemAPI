using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Models;

namespace TaskSystemApi.Repositories.Interfaces
{

    public interface ITaskRepository
    {

        Task<List<TaskModel>> FindAllTasks();

        Task<TaskModel> FindById(int id);

        Task<TaskModel> Add(TaskModel task);

        Task<TaskModel> Update(TaskModel task, int id);

        Task<bool> Delete(int id);

    }

}
