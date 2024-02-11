using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            builder.HasData(
                new Work { Id = 1, Count = 1, Name = "Одна смена 8 часов" },
                new Work { Id = 2, Count = 2, Name = "Две смены 16 часов" },
                new Work { Id = 3, Count = 3, Name = "Непрерывная работа 24 часа" });
        }
    }
}
