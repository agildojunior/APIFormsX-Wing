using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFormsX_Wing.Controllers
{
    [Route("api/answer")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerRepository _answerRepository;

        public AnswerController(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Answer>>> GetAll()
        {
            List<Answer> answers = await _answerRepository.GetAll();
            return Ok(answers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answer>> GetId(int id)
        {
            Answer answer = await _answerRepository.GetId(id);
            return Ok(answer);
        }

        [HttpPost]
        public async Task<ActionResult<Answer>> Create([FromBody] Answer answer)
        {
            Answer newAnswer = await _answerRepository.Create(answer);
            return Ok(newAnswer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Answer>> Edit([FromBody] Answer answer, int id)
        {
            answer.Id = id;
            Answer newAnswer = await _answerRepository.Edit(answer, id);
            return Ok(newAnswer);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _answerRepository.Delete(id);
            return Ok(deleted);
        }
    }
}