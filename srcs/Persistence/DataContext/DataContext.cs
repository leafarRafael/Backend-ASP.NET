using Microsoft.EntityFrameworkCore;
using ApiCRUD.srcs.Domain.Entities;
using ApiCRUD.srcs.Persistence.Configurations;


namespace ApiCRUD.srcs.Persistence.DataContext
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions options) : base(options){}

		public DbSet<UserEntity> Users { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration<UserEntity>(new UserConfiguration());
		}
	}
}

