using Microsoft.EntityFrameworkCore;
using NewsletterAPI.Data;
using NewsletterAPI.Interfaces;
using NewsletterAPI.Models;

namespace NewsletterAPI.Repository
{
	internal class SmsMessageRepository : ISmsMessageRepository
	{

		private readonly NewsletterDbContext _context;

		public SmsMessageRepository(NewsletterDbContext context)
		{
			_context = context;
		}

		public async Task<List<SmsMessage>> GetMessages(string status)
		{
			return await _context.SmsMessages.Where(x => x.Status == status).ToListAsync();
		}

		public async Task<bool> UpdateStatusMessage(int id, string status)
		{
			var smsMessage = await _context.SmsMessages.Where(x => x.Id == id).FirstAsync();

			smsMessage.Update(status);

			if (_context.Entry(smsMessage).State == EntityState.Unchanged)
				return false;

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<bool> SmsMessageExists(int id)
		{
			return await _context.SmsMessages.AnyAsync(x=> x.Id == id);
		}
	}
}
