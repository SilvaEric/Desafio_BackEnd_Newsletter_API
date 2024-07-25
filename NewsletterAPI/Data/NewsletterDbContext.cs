using Microsoft.EntityFrameworkCore;
using NewsletterAPI.Models;

namespace NewsletterAPI.Data
{
	public class NewsletterDbContext : DbContext
	{
		private readonly IConfiguration _configuration;

		public NewsletterDbContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public DbSet<SmsMessage> SmsMessages { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlite(_configuration.GetConnectionString("Sqlite"));
			
		}
	}
}
