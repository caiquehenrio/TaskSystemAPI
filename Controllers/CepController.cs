using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Integration.Interface;
using TaskSystemApi.Integration.Response;

namespace TaskSystemApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {

        private readonly IViaCepIntegration _viaCepIntegration;

        public CepController(IViaCepIntegration viaCepIntegration) 
        {

            _viaCepIntegration = viaCepIntegration;

        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListAddressData(string cep) 
        {

            var responseData = await _viaCepIntegration.ObtainDataViaCep(cep);

            if(responseData == null) 
            {

                return BadRequest("CEP not found!");

            }

            return Ok(responseData);

        }

    }

}
