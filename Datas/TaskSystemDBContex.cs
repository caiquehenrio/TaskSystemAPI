using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Models;
using TaskSystemApi.Data.Map;

namespace TaskSystemApi.Data
{

    public class TaskSystemDBContex : DbContext
    {

        public TaskSystemDBContex(DbContextOptions<TaskSystemDBContex> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        
        public DbSet<TaskModel> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());


            
            base.OnModelCreating(modelBuilder);

        }

    }

}
