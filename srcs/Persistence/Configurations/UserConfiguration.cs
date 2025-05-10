using Microsoft.EntityFrameworkCore;
using ApiCRUD.srcs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ApiCRUD.srcs.Persistence.Configurations
{
	public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
	{
		public void Configure(EntityTypeBuilder<UserEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(256);

			builder.Property(x => x.Email)
				.IsRequired()
				.HasMaxLength(50);
			builder.HasIndex(x => x.Email).IsUnique();
			
			builder.Property(x => x.Phone)
				.IsRequired()
				.HasMaxLength(50);
			builder.HasIndex(x => x.Phone).IsUnique();
		}
	}
}

