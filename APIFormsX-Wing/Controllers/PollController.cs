using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFormsX_Wing.Controllers
{
    [Route("api/poll")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollRepository _pollRepository;

        public PollController(IPollRepository pollRepository)
        {
            _pollRepository = pollRepository;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<Poll>>> GetAll()
        {
            List<Poll> polls = await _pollRepository.GetAll();
            return Ok(polls);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Poll>>> GetId(int id)
        {
            Poll poll = await _pollRepository.GetId(id);
            return Ok(poll);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<Poll>> Create([FromBody] Poll poll)
        {
            Poll newPoll = await _pollRepository.Create(poll);
            return Ok(newPoll);
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<Poll>> Edit([FromBody] Poll poll, int id)
        {
            poll.Id = id;
            Poll newPoll = await _pollRepository.Edit(poll, id);
            return Ok(newPoll);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _pollRepository.Delete(id);
            return Ok(deleted);
        }
    }
}