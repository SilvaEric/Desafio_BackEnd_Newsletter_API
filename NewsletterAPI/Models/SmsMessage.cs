using System.ComponentModel.DataAnnotations;

namespace NewsletterAPI.Models
{
	public class SmsMessage
	{
		public int Id { get; private set; }
		public string Phone { get; private set; }
		public string Message { get; private set; }
		public string Status { get; private set;}
		
		public void Update(string status)
		{
			Status = status;
		}
    }
}
