using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace F1WM.DatabaseModel
{
	public class F1WMIdentityContext : IdentityDbContext
	{
		public virtual DbSet<F1WMUser> F1WMUsers { get; set; }
		public F1WMIdentityContext(DbContextOptions<F1WMIdentityContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}