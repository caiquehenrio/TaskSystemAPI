using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystemApi.Data;
using TaskSystemApi.Models;
using TaskSystemApi.Repositories.Interfaces;

namespace TaskSystemApi.Repositories
{

    public class UserRepository : IUserRepository
    {

        private readonly TaskSystemDBContex _dbContext;

        public UserRepository(TaskSystemDBContex systemDBContex)
        {

            _dbContext = systemDBContex;

        }

        public async Task<List<UserModel>> FindAllUsers()
        {

            return await _dbContext.Users.ToListAsync();

        }

        public async Task<UserModel> FindById(int id)
        {

            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<UserModel> Add(UserModel user)
        {

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            return user;

        }

        public async Task<UserModel> Update(UserModel user, int id)
        {

            UserModel userById = await FindById(id);

            if(userById == null) 
            {

                throw new Exception($"User for ID {id} was not found in the database.");

            }

            userById.Name = user.Name;
            userById.Email = user.Email;

            _dbContext.Users.Update(userById);
            await _dbContext.SaveChangesAsync();

            return userById;

        }

        public async Task<bool> Delete(int id)
        {

            UserModel userById = await FindById(id);

            if (userById == null)
            {

                throw new Exception($"User for ID {id} was not found in the database.");

            }

            _dbContext.Users.Remove(userById);
            await _dbContext.SaveChangesAsync();

            return true;

        }

    }

}
