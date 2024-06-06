using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Integration.Interface;
using TaskSystemApi.Integration.Refit;
using TaskSystemApi.Integration.Response;

namespace TaskSystemApi.Integration
{

    public class ViaCepIntegration : IViaCepIntegration
    {

        private readonly IViaCepRefit _viaCepRefit;

        public ViaCepIntegration(IViaCepRefit viaCepRefit) 
        {

            _viaCepRefit = viaCepRefit;

        }

        public async Task<ViaCepResponse> ObtainDataViaCep(string cep) 
        {

            var responseData = await _viaCepRefit.ObtainDataViaCep(cep);

            if(responseData != null && responseData.IsSuccessStatusCode) 
            {

                return responseData.Content;

            }

            return null;

        }

    }

}
