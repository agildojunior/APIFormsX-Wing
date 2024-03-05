using APIFormsX_Wing.Models;
using APIFormsX_Wing.Repositorys;
using APIFormsX_Wing.Repositorys.interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

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

        [HttpGet("emailRecovery/{username}")]
        public async Task<ActionResult<bool>> PasswordRecoveryByEmail(string username)
        {
            User userEmail = await _UserRepository.GetByUsername(username);

            //ativar acesso ao login em "https://myaccount.google.com/lesssecureapps"
            string AppEmail = "seu_email@gmail.com";
            string AppSenha = "sua_senha";
            string subject = "Recuperação de Senha";
            string message = $"Olá {userEmail.Username},\n\n" +
                             "Você solicitou uma recuperação de senha. Aqui estão suas informações:\n" +
                             $"Nome de usuário: {userEmail.Username}\n" +
                             $"Sua senha: {userEmail.Password}\n" +
                             "Atenciosamente,\n" +
                             "Equipe X-Wing.";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(AppEmail, AppSenha),
                EnableSsl = true,
            };
            var mailMessage = new MailMessage
            {
                From = new MailAddress(AppEmail),
                Subject = subject,
                Body = message,
                IsBodyHtml = false,
            };

            mailMessage.To.Add(userEmail.Username);

            await smtpClient.SendMailAsync(mailMessage);

            return Ok(true);
        }
    }
}