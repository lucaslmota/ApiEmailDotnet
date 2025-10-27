using MailApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailsController : ControllerBase
    {
        private readonly ILogger<EmailsController> _logger;
        private readonly ISendEmail _sendEmail;
        public EmailsController(ILogger<EmailsController> logger, ISendEmail sendEmail)
        {
            _logger = logger;
            _sendEmail = sendEmail;
        }

        [HttpPost]
        [Route("sendmail")]
        public async Task<IActionResult> TesteEmail(string email, string subject, string body)
        {
            try
            {
                await _sendEmail.SendEmailAsync(email, subject, body);
                _logger.LogInformation($"{StatusCodes.Status200OK} - E-mail enviado com sucesso");
                return Ok("Email enviado com sucesso");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Erro ao enviar o email.");
            }
        }
    }
}