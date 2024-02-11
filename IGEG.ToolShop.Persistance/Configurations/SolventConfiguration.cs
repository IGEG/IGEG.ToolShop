using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class SolventConfiguration : IEntityTypeConfiguration<Solvent>
    {
        public void Configure(EntityTypeBuilder<Solvent> builder)
        {
            builder.HasData(
                new Solvent { Id = 1, Name = "Ацетон", Price = 240.00m },
                new Solvent { Id = 2, Name = "646", Price = 220.00m },
                new Solvent { Id = 3, Name = "650", Price = 340.00m },
                new Solvent { Id = 4, Name = "647", Price = 210.00m },
                new Solvent { Id = 5, Name = "Универсальный", Price = 290.00m },
                new Solvent { Id = 6, Name = "Уайт-Спирит", Price = 210.00m },
                new Solvent { Id = 7, Name = "Нефрас 80/120", Price = 220.00m },
                new Solvent { Id = 8, Name = "Нефрас 130/150", Price = 230.00m },
                new Solvent { Id = 9, Name = "Обезжириватель", Price = 250.00m },
                new Solvent { Id = 10, Name = "Сольвент", Price = 190.00m },
                new Solvent { Id = 11, Name = "Ксилол", Price = 240.00m },
                new Solvent { Id = 12, Name = "Толуол", Price = 240.00m },
                new Solvent { Id = 13, Name = "Бутилацетат", Price = 200.00m },
                new Solvent { Id = 14, Name = "Этилацетат", Price = 210.00m },
                new Solvent { Id = 15, Name = "Смывка флексографии", Price = 200.00m },
                new Solvent { Id = 16, Name = "Спирты", Price = 250.00m },
                new Solvent { Id = 17, Name = "Р4(Р5)", Price = 220.00m },
                new Solvent { Id = 18, Name = "Дихлорметан", Price = 600.00m });
        }
    }
}
