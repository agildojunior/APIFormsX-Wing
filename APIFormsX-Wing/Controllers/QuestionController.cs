using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFormsX_Wing.Controllers
{
    [Route("api/question")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Question>>> GetAll()
        {
            List<Question> questions = await _questionRepository.GetAll();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Question>> GetId(int id)
        {
            Question question = await _questionRepository.GetId(id);
            return Ok(question);
        }

        [HttpPost]
        public async Task<ActionResult<Question>> Create([FromBody] Question question)
        {
            Question newQuestion = await _questionRepository.Create(question);
            return Ok(newQuestion);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Question>> Edit([FromBody] Question question, int id)
        {
            question.Id = id;
            Question editedQuestion = await _questionRepository.Edit(question, id);
            return Ok(editedQuestion);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool deleted = await _questionRepository.Delete(id);
            return Ok(deleted);
        }
    }
}