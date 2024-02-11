using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "Дистиллятор ULtraCliean 20EX",
                    SmallDescription = "Установка для дистилляции загрязненных растворителей ULtraCliean 20EX с объемом загрузки 20 литров",
                    BigDescription = "Дистиллятор растворителей ULtraCliean 20EX на 20 литров обладает компактным размером и эргономичным дизайном.На панели приборов удобно расположены тумблер для выбора температурного режима и таймер дистилляции. LED дисплей позволяет отображать оставшееся врем перегонки,общее врем работы дистиллятора. Специальный индикатор показывает в какой промежуток времени идет нагрев масла.",
                    Images = "https://www.solventrecyclingmachine.com/wp-content/uploads/2021/11/standard-solvent-recycling-unit.png",
                    URL = "UltraClean20Ex",
                    Volume = 20,
                    CategoryId = 1
                },
                new Product
                {
                    Id = 2,
                    Name = "Пакеты Rec-Bag 20 литров",
                    SmallDescription = "Пакеты Rec-Bag для дистиллятора ULtraCliean 20EX",
                    BigDescription = "Пакеты Rec-Bag для дистиллятора ULtraCliean 20EX имеют плотную структуру, что позволяет их использовать при аккуратной работе более одного раза. Данные термопакеты обладают высокой термостойкостью, до 200 градусов Цельсия. Пакеты рек бэг изготовлены из специальных термостойких пластиков с гомогенной структурой.Термопакеты \"Rec Bag\" поставляются упаковкой по 50 штук. Использование термопакетов rec-bag актуально при дистилляции растворителей загрязненных красками, лаками, любыми твердыми частицами.",
                    Images = "Img/rec-bag30.png",
                    URL = "RecBag20Ex",
                    CategoryId = 2
                });
        }
    }
}
