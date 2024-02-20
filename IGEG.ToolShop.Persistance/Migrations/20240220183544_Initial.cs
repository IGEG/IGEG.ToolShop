using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IGEG.ToolShop.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Img = table.Column<string>(type: "text", nullable: true),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsMenu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Url = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    SmallDescription = table.Column<string>(type: "text", nullable: true),
                    BigDescription = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsMenu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductOptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    DateOfView = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Count = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SmallDescription = table.Column<string>(type: "text", nullable: true),
                    BigDescription = table.Column<string>(type: "text", nullable: true),
                    Images = table.Column<string>(type: "text", nullable: true),
                    URL = table.Column<string>(type: "text", nullable: true),
                    SpesialPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    Volume = table.Column<int>(type: "integer", nullable: true),
                    IsOpen = table.Column<bool>(type: "boolean", nullable: false),
                    IsClose = table.Column<bool>(type: "boolean", nullable: false),
                    DateOfSaller = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateOfUpdate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Views = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductModel",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    ProductOptionId = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    OldPrice = table.Column<decimal>(type: "numeric(10,2)", nullable: true),
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductModel", x => new { x.ProductId, x.ProductOptionId });
                    table.ForeignKey(
                        name: "FK_ProductModel_ProductOptions_ProductOptionId",
                        column: x => x.ProductOptionId,
                        principalTable: "ProductOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductModel_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Img", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Оборудование для регенерации растворителей", "oi oi-cog", "Дистилляторы", "distillars" },
                    { 2, "Термопакеты для сбора отработанного остатка дистилляции", "oi oi-droplet", "Пакеты Rec-Bag", "Rec-Bag" }
                });

            migrationBuilder.InsertData(
                table: "NewsMenu",
                columns: new[] { "Id", "BigDescription", "Image", "Name", "SmallDescription", "Title", "Url" },
                values: new object[,]
                {
                    { 1, "В первую очередь на производительность установки дистилляции растворителя влияет продолжающееся накопление шлама в дистилляционной емкости, длительное отсутствие внимания и устаревание электрических компонентов.\r\nПодобно автомобилю и наиболее важному оборудованию, система регенерации растворителей на месте требует регулярного технического обслуживания, ежедневного, еженедельного, ежемесячного, ежеквартального и ежегодного. Также как и в случае с автомобилем, производительность машины будет снижена, если некоторые элементы технического обслуживания не будут устранены, когда это необходимо. Без надлежащего технического обслуживания проблемы с производительностью могут привести к дополнительным расходам, которые можно было бы предотвратить.\r\nПроблемы нагрева термального масла\r\nДистилляционная установка требует источника нагрева, достаточно сильного, чтобы преодолеть физические свойства перегоняемого растворителя. Наиболее распространенными источниками нагрева являются диатермическое  масло с электрическим нагревом или паровая рубашка.\r\nДиатермическое масло необходимо заменять ежегодно. Несвоевременная замена теплового масла приведет к нагарообразованию масляной рубашки.\r\nНагар накапливается как на боковых стенках бака, так и на нагревательных элементах. Отложения на боковых стенках действуют как изолятор, препятствующий эффективной передаче тепла. Наросты на нагревательных элементах приводят к выходу из строя нагревателя.\r\nНакопление шлама на нагревательных поверхностях\r\nДистилляционная установка будет накапливать осадок на нагревательных поверхностях при постоянном использовании. Скопление шлама на нагревательных поверхностях снижает эффективность нагрева, требуя больше времени для обработки растворителя и больше энергии для работы системы.\r\n\r\nДистиллятор растворителя требует ежедневной очистки поверхности нагрева, по крайней мере, после каждой разгрузки.\r\nНакопление шлама на ненагреваемых поверхностях\r\nСкопление шлама на ненагреваемых поверхностях может привести к загрязнению дистиллята, так как частицы ила улетучиваются с парами растворителя.\r\nПроблемы с электрическими компонентами\r\nУстаревание электрических компонентов также является фактором, негативно влияющим на эффективность дистилляции.\r\nПЛК, усилители, датчики и другие устройства со временем выводятся из употребления производителями. \r\nИногда возможна индивидуальная замена. Тем не менее, часто требуются модификации для размещения компонентов для прямой замены.\r\nУстаревание ПЛК  может потребовать всего нового программного обеспечения или программ для поддержки сменного устройства. Если вы решите использовать неподдерживаемые устройства, они могут ухудшить производительность дистилляции, когда начнутся сбои с более длительным временем выполнения заказа, при поиске метода замены или требуя от операторов обходных путей процесса.\r\nНезапланированные расходы могут увеличиться\r\nПродолжительное использование неэффективной дистилляционной установки влияет на весть процесс перегонки.\r\nВместо того чтобы эффективно очищать ваш растворитель, большое количество растворителя отправляется в отходы и требует покупки увеличенного объема чистого растворителя. Ценное время оператора требуется, чтобы сосредоточиться на дистилляционной установке, а не на других рабочих обязанностях.\r\nДля продолжения работы системы требуется больше времени на техническое обслуживание и трудозатраты. Снижение производительности дистилляционной установки напрямую влияет на общую стоимость работы.\r\nНаши рекомендации.\r\nКак и в случае с автомобилем, невыполнение профилактического и планового технического обслуживания приведет к долгосрочным и потенциально дорогостоящим проблемам с производительностью. \r\nОчистка бака\r\nЕжедневно очищать бак от образований накипи. Таким образом улучшается тепловой обмен между стенками испарительного бака дистиллятора и обрабатываемым растворителем.\r\nКонтроль диатермического масла\r\nКонтролировать в холодном состоянии уровень диатермического масла.\r\nОчистка контура конденсации паров.\r\nПериодически продувать сжатым воздухом с давлением коллектора паров в баке дистиллятора в сторону выхода дистиллята и в обратном направлении для вычистки возможных образований, сформировавшихся в трубопроводе и конденсоре. Периодически производить очистку сжатым воздухом внешней поверхности конденсора\r\nРекомендуется замена диатермического масла после 1000 часов работы. Тип масла: АМТ-300, МТ-300.  При каждой замене диатермического масла необходимо проверить стравливающий воздушный  клапан на крышке.\r\nОчистка нагревательного элемента.\r\nПри эксплуатации дистиллятора на электрическом резисторе происходит налипание \r\nнакипи. Для нормального теплообмена необходимо ежегодно производить его очистку.\r\n", "Img/news/hand-tool.png", null, "Почему производительность установки дистилляции растворителя со временем ухудшается?\r\nСуществует несколько распространенных причин снижения производительности установок для дистилляции растворителя. Изучите несколько наиболее распространенных проблем и узнайте, как их можно решить.\r\nИмеется ли на вашем предприятии дистилляционная установка для переработки загрязненных растворителей? Если она есть, то это очень здорово!  Это означает, что вы экономите на расходах при покупке нового растворителя, снижаете плату за утилизацию опасных отходов и заботитесь об окружающей среде!\r\nОднако знаете ли вы, что производительность установки для дистилляции растворителя со временем будет ухудшаться, что в конечном итоге будет стоить вам части сэкономленных средств?\r\nОсновные проблемы с которыми Вы сможете столкнуться при уменьшении  производительности установки дистилляции растворителя.\r\n", "Техниечское обслуживание и проблемы эксплуатации дистилляторов растворителей UltraClean", "technichescoe-obsluzhivanie-distillatorov-rastrvoriteley" },
                    { 2, "Как определить емкость блока регенерации растворителя\r\nПрежде всего, если вы собираетесь начать химическую переработку, вы должны понимать, какие мощности необходимы для переработки. Это, в свою очередь, покажет размер бака, который требуется вашему заводу. Существует 4 параметра, которые необходимо знать  для определения производительности установки регенерации растворителя.\r\nДля начала спросите себя: какой суточный объем  растворителя образуется? Это можно проверить по отходам растворителей, которые в настоящее время перерабатываются и/или вывозятся за пределы предприятия для переработки или утилизации растворителей. Для этого определите, сколько отходов растворителя образуется ежедневно, еженедельно, ежемесячно и/или ежеквартально. Затем проверьте свои цифры, просмотрев актуальную документы об отходах, чтобы убедиться, что ваши данные верны. Еще одна проверка заключается в проверке количества растворителя, приобретенного для очистки.\r\nНапример, допустим, вы считаете, что среднесуточный объем образующихся отходов растворителя составляет 10 литров. Следующим шагом будет просмотр документов, чтобы определить общее количество отработанного растворителя, отгружаемого ежемесячно или ежеквартально. Допустим, ответ — 6 бочек в месяц. Чтобы проверить математику, мы умножим 6 бочек на 200 литров, чтобы получить 1 200 литров в месяц. Затем, чтобы преобразовать это значение в дневной расход, просто разделите 1 200 литров на 22 рабочих дня. Ответ: 54,5 литров отходов, образующихся каждый день. Это тревожный сигнал, так как 54,5 литра в день — это совсем другое число, чем первоначальные 10 литров. Мы рекомендуем вам ознакомиться с документами об отходах, чтобы убедиться в фактической отгрузке отходов.  \r\nПосле определения ваших текущих потребностей в чистящем растворителе вы также должны определить свои будущие потребности. Вам следует обсудить будущие потребности в переработке растворителей с производственным отделом, чтобы спрогнозировать будущие объемы. Установка дистилляции растворителя должна прослужить не менее 5 лет, но обычно служит в пределах 15-20 лет. Это означает, что вы должны смотреть на свои потребности в использовании в течение следующего десятилетия.\r\nСледующим шагом будет определение времени, необходимого для работы установки дистилляции растворителя. Некоторые предприятия предпочитают не включать свои установки по переработке растворителей на ночь или в выходные дни. Тем не менее, с современными технологиями, предоставляемыми нашими установками, вполне возможно эксплуатировать регенератор  24 часа в сутки, 7 дней в неделю. Важно осознавать, что машины нуждаются в техническом обслуживании и ремонте. Просто нереально предполагать, что машина будет работать постоянно. Механические проблемы будут возникать время от времени. Хорошее эмпирическое правило для предприятий, приобретающих дистилляционное оборудование, заключается в том, что время безотказной работы должно составлять 85 %.. Тем не менее, некоторые предприятия будут иметь более высокое время безотказной работы, чем другие. Это связано с тем, что время безотказной работы почти полностью зависит от персонала, в который входят оператор машины, отдел технического обслуживания и руководитель процесса. Когда-то блестящая программа утилизации на месте может измениться за одну ночь, когда сменится оператор или другой ключевой персонал. Еще один важный момент, который следует отметить, заключается в том, что время безотказной работы не будет оставаться постоянным. Когда предприятие впервые внедряет установку дистилляции растворителя, большое внимание уделяется процессу, что приводит к значительному увеличению времени безотказной работы. К сожалению, когда волнение уляжется и наступит реальность повседневной рутинной работы, установка по переработке растворителей, скорее всего, не будет иметь такого же высокого уровня концентрации и внимания. Мы отмечаем это как поучительную историю, чтобы убедиться, что предприятия точно оценивают время безотказной работы.\r\nБыло бы здорово, если бы единственным требованием для поиска идеального регенератора растворителей было количество отходов, которое он перерабатывает за день. Но это не так. Есть два других фактора, которые необходимо учитывать: температура кипения растворителя (растворителей), которые будут извлечены с помощью оборудования для дистилляции растворителя, и процентное содержание загрязняющих веществ в потоке отходов очистки растворителя. Чем выше температура кипения и процентное содержание загрязняющих веществ в растворителе, тем больше времени потребуется машине для обработки отходов. Оба фактора независимо друг от друга влияют на размер устройства, необходимого для объекта. Растворитель с более высокой температурой кипения означает, что для прохождения процесса дистилляции требуется больше энергии. Это приводит к увеличению времени, необходимого для достижения агрегатом правильной температуры, что продлевает цикл восстановления. В то время как более высокое загрязнение означает, что машинам придется чаще сливать остаток, чтобы гарантировать, что материал не станет слишком вязким для обработки. Больше циклов слива означает больше времени.\r\nПодведем итоги.\r\nНадеемся, что эта статья помогла Вам  получить достоверную информацию о том, как вы можете определить идеальную установку для дистилляции растворителя для вашего предприятия. Мы помогли вам понять четыре фактора, которые необходимо учитывать при определении производительности вашей установки по регенерации растворителей: \r\nобъем отходов растворителя,\r\n время работы,\r\n температура кипения\r\n и процент загрязнения. \r\n", "Img/news/help.png", null, "Восстановление растворителя на месте проще, чем вы думаете. Но прежде чем вы приобретете дистиллятор, вам необходимо определить мощность, которая потребуется вашему оборудованию. Есть четыре критерия, которые необходимо изучить, чтобы определить требуемую производительность установки по регенерации растворителя: объем отходов растворителя, время работы, температура кипения и процент загрязнения.", "4 основных параметря для выбора дистиллятора", "pomosh-v-vibore-distillatora-rastvoriteley" }
                });

            migrationBuilder.InsertData(
                table: "ProductOptions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Без опций" },
                    { 2, "С генератором вакуума" },
                    { 3, "С автоматической загрузкой" },
                    { 4, "Упаковка 50 шт." }
                });

            migrationBuilder.InsertData(
                table: "Solvents",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Ацетон", 240.00m },
                    { 2, "646", 220.00m },
                    { 3, "650", 340.00m },
                    { 4, "647", 210.00m },
                    { 5, "Универсальный", 290.00m },
                    { 6, "Уайт-Спирит", 210.00m },
                    { 7, "Нефрас 80/120", 220.00m },
                    { 8, "Нефрас 130/150", 230.00m },
                    { 9, "Обезжириватель", 250.00m },
                    { 10, "Сольвент", 190.00m },
                    { 11, "Ксилол", 240.00m },
                    { 12, "Толуол", 240.00m },
                    { 13, "Бутилацетат", 200.00m },
                    { 14, "Этилацетат", 210.00m },
                    { 15, "Смывка флексографии", 200.00m },
                    { 16, "Спирты", 250.00m },
                    { 17, "Р4(Р5)", 220.00m },
                    { 18, "Дихлорметан", 600.00m }
                });

            migrationBuilder.InsertData(
                table: "Works",
                columns: new[] { "Id", "Count", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Одна смена 8 часов" },
                    { 2, 2, "Две смены 16 часов" },
                    { 3, 3, "Непрерывная работа 24 часа" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "BigDescription", "CategoryId", "DateOfSaller", "DateOfUpdate", "Images", "IsClose", "IsOpen", "Name", "SmallDescription", "SpesialPrice", "URL", "Views", "Volume" },
                values: new object[,]
                {
                    { 1, "Дистиллятор растворителей ULtraCliean 20EX на 20 литров обладает компактным размером и эргономичным дизайном.На панели приборов удобно расположены тумблер для выбора температурного режима и таймер дистилляции. LED дисплей позволяет отображать оставшееся врем перегонки,общее врем работы дистиллятора. Специальный индикатор показывает в какой промежуток времени идет нагрев масла.", 1, new DateTime(2024, 2, 20, 21, 35, 42, 948, DateTimeKind.Local).AddTicks(8218), null, "https://www.solventrecyclingmachine.com/wp-content/uploads/2021/11/standard-solvent-recycling-unit.png", false, false, "Дистиллятор ULtraCliean 20EX", "Установка для дистилляции загрязненных растворителей ULtraCliean 20EX с объемом загрузки 20 литров", null, "UltraClean20Ex", 0, 20 },
                    { 2, "Пакеты Rec-Bag для дистиллятора ULtraCliean 20EX имеют плотную структуру, что позволяет их использовать при аккуратной работе более одного раза. Данные термопакеты обладают высокой термостойкостью, до 200 градусов Цельсия. Пакеты рек бэг изготовлены из специальных термостойких пластиков с гомогенной структурой.Термопакеты \"Rec Bag\" поставляются упаковкой по 50 штук. Использование термопакетов rec-bag актуально при дистилляции растворителей загрязненных красками, лаками, любыми твердыми частицами.", 2, new DateTime(2024, 2, 20, 21, 35, 42, 948, DateTimeKind.Local).AddTicks(8276), null, "Img/rec-bag30.png", false, false, "Пакеты Rec-Bag 20 литров", "Пакеты Rec-Bag для дистиллятора ULtraCliean 20EX", null, "RecBag20Ex", 0, null }
                });

            migrationBuilder.InsertData(
                table: "ProductModel",
                columns: new[] { "ProductId", "ProductOptionId", "Id", "Name", "OldPrice", "Price" },
                values: new object[,]
                {
                    { 1, 1, 0, null, 490000.00m, 400000.00m },
                    { 1, 2, 0, null, 690000.00m, 560000.00m },
                    { 1, 3, 0, null, 570000.00m, 490000.00m },
                    { 2, 4, 0, null, 19000.00m, 15000.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductModel_ProductOptionId",
                table: "ProductModel",
                column: "ProductOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsMenu");

            migrationBuilder.DropTable(
                name: "ProductModel");

            migrationBuilder.DropTable(
                name: "Solvents");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "Works");

            migrationBuilder.DropTable(
                name: "ProductOptions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
