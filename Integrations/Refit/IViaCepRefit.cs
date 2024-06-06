using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Integration.Response;

namespace TaskSystemApi.Integration.Refit
{

    public interface IViaCepRefit
    {

        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> ObtainDataViaCep(string cep);

    }

}
