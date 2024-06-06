using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskSystemApi.Models;
using TaskSystemApi.Repositories.Interfaces;

namespace TaskSystemApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {

            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<List<UserModel>>> FindAllUser()
        {

            List<UserModel> users = await _userRepository.FindAllUsers();

            return Ok(users);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> FindById(int id)
        {

            UserModel user = await _userRepository.FindById(id);

            return Ok(user);

        }

        [HttpPost]
        public async Task<ActionResult<UserModel>> Add([FromBody] UserModel userModel)
        {

            UserModel user = await _userRepository.Add(userModel);

            return Ok(user);

        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UserModel>> Update([FromBody] UserModel userModel, int id)
        {

            userModel.Id = id;

            UserModel user = await _userRepository.Update(userModel, id);

            return Ok(user);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> Delete(int id) 
        {

            bool deleted = await _userRepository.Delete(id);

            return Ok(deleted);

        }

    }

}
