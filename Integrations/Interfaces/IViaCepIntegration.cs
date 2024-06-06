using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Integration.Response;

namespace TaskSystemApi.Integration.Interface
{

    public interface IViaCepIntegration
    {

        Task<ViaCepResponse> ObtainDataViaCep(string cep);

    }

}
