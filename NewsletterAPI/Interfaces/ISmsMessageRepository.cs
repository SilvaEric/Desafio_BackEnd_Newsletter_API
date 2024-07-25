using NewsletterAPI.Models;

namespace NewsletterAPI.Interfaces
{
	public interface ISmsMessageRepository
	{
		Task<List<SmsMessage>> GetMessages(string status);

		Task<bool> UpdateStatusMessage(int id, string status);

		Task<bool> SmsMessageExists(int id);
	}
}
