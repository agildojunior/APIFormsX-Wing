using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFormsX_Wing.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;

        public UserController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _UserRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> GetId(int id)
        {
            User user = await _UserRepository.GetId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User user) 
        { 
            User newUser = await _UserRepository.Create(user);
            return Ok(newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Edit([FromBody] User user, int id)
        {
            user.Id = id;
            User newUser = await _UserRepository.Edit(user, id);
            return Ok(newUser);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(int id)
        {
            bool deleted = await _UserRepository.Delete(id);
            return Ok(deleted);
        }
    }
}
