using brk.Todo.Domain.User.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace brk.Todo.Infra.Persistence.User.Mappings;

public class UserModelMapping : IEntityTypeConfiguration<UserModel>
{
    public void Configure(EntityTypeBuilder<UserModel> builder)
    {
        builder.HasKey(m=>m.Id);
        builder.ToTable("Users");
        builder.HasIndex(m=>m.Email).IsUnique();

        builder.Property(m=>m.Email)
        .IsRequired()
        .HasMaxLength(250);

        builder.Property(m=>m.Password)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(m=>m.Name)
        .IsRequired(false)
        .HasMaxLength(100);

        builder.Property(m=>m.Family)
        .IsRequired(false)
        .HasMaxLength(200);
        
    }
}
