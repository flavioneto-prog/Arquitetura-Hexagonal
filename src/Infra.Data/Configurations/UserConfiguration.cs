using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("TB_USERS");

            builder.Property(user => user.Id)
                .HasColumnType("uuid")
                .ValueGeneratedOnAdd();

            builder.HasKey(user => user.Id);

            builder.Property(user => user.Name)
                .HasColumnType("varchar")
                .HasColumnName("Name")
                .IsRequired();

            builder.Property(user => user.Email)
                .HasColumnType("varchar")
                .HasColumnName("Email")
                .IsRequired();
        }
    }
}