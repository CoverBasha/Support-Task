using Microsoft.EntityFrameworkCore;
using Support_Web.Models;

namespace Support_Web.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		DbSet<Product> Products { get; set; }
	}
}
