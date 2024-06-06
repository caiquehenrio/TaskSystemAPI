using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace TaskSystemApi.Enums
{

    public enum Status
    {

        [Description("To do")]
        ToDo = 1,

        [Description("In Progress")]
        InProgress = 2,

        [Description("Concluded")]
        Concluded = 3

    }

}
