using Microsoft.AspNetCore.Mvc;
using NewsletterAPI.Interfaces;
using NewsletterAPI.Validates;

namespace NewsletterAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class SmsMessageController : ControllerBase
	{
		private readonly ISmsMessageRepository _repository;

		public SmsMessageController(ISmsMessageRepository repository)
		{
			_repository = repository;
		}
		
		[HttpGet("/[action]")]
		public async Task<IActionResult> GetMessagesByStatus(string status)
		{
			if (! ValidateStatusRequest.StatusValids.Any(x => x == status))
				return BadRequest("O status fornecido deve ser um dos seguintes: 'ENVIADO', 'RECEBIDO', 'ERRO DE ENVIO'.");

			var messages = await _repository.GetMessages(status);

			if (messages.Count() == 0)
				return NotFound("Nenhuma mensagem foi registrada com o status fornecido");

			return Ok(messages);
		}

		[HttpPut("/[action]/{id}")]
		public async Task<IActionResult> UpdateStatus(string status, int id)
		{
			if (!ValidateStatusRequest.StatusValids.Any(x => x == status))
				return BadRequest("O status fornecido deve ser um dos seguintes: 'ENVIADO', 'RECEBIDO', 'ERRO DE ENVIO'.");
			 
			if (!await _repository.SmsMessageExists(id))
				return BadRequest("Não existe uma mensagem com o ID fornecido");

			if (!await _repository.UpdateStatusMessage(id, status))
				throw new Exception("Erro ao atualizar status de Menssagem");

			return Ok();
		}

	}
}
