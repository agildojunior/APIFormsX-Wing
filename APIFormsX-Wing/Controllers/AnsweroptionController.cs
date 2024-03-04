using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFormsX_Wing.Controllers
{
    [Route("api/answeroption")]
    [ApiController]
    public class AnsweroptionController : ControllerBase
    {
        private readonly IAnsweroptionRepository _answeroptionRepository;

        public AnsweroptionController(IAnsweroptionRepository answeroptionRepository)
        {
            _answeroptionRepository = answeroptionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Answeroption>>> GetAll()
        {
            List<Answeroption> answeroptions = await _answeroptionRepository.GetAll();
            return Ok(answeroptions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Answeroption>> GetId(int id)
        {
            Answeroption answeroption = await _answeroptionRepository.GetId(id);
            return Ok(answeroption);
        }

        [HttpPost]
        public async Task<ActionResult<Answeroption>> Create([FromBody] Answeroption answeroption)
        {
            Answeroption newAnsweroption = await _answeroptionRepository.Create(answeroption);
            return Ok(newAnsweroption);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Answeroption>> Edit([FromBody] Answeroption answeroption, int id)
        {
            answeroption.Id = id;
            Answeroption newAnsweroption = await _answeroptionRepository.Edit(answeroption, id);
            return Ok(newAnsweroption);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _answeroptionRepository.Delete(id);
            return Ok(deleted);
        }
    }
}