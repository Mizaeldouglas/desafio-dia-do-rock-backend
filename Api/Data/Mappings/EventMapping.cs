using Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mappings;

public class EventMapping : IEntityTypeConfiguration<EventModel>
{
    public void Configure(EntityTypeBuilder<EventModel> builder)
    {
        builder.ToTable("Events");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Image).IsRequired(false);
        
        builder.Property(x => x.Title).IsRequired();
        
        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(1000)
            .HasColumnType("TEXT")
            .HasDefaultValue("No description");
        
        builder.Property(x => x.Address)
            .IsRequired()
            .HasMaxLength(700)
            .HasColumnType("TEXT");
        
        builder.Property(x => x.Datetime)
            .IsRequired()
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("NOW()")
            .ValueGeneratedOnAdd()
            .ValueGeneratedOnUpdate();
        
        builder.Property(x => x.Lat).IsRequired();
        
        builder.Property(x => x.Lng).IsRequired();
    }
}