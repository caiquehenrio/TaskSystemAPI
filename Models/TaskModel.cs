using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Enums;

namespace TaskSystemApi.Models
{

    public class TaskModel
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public int? UserId { get; set; }
        public virtual UserModel? User { get; set; }

    }

}
