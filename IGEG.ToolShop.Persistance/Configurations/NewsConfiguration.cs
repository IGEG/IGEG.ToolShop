﻿using IGEG.ToolShop.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IGEG.ToolShop.Persistance.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasData(
               new News { Id = 1, Url = "technichescoe-obsluzhivanie-distillatorov-rastrvoriteley",
                   Image = "Img/news/hand-tool.png",
                   Title = "Техниечское обслуживание и проблемы эксплуатации дистилляторов растворителей UltraClean",
                   SmallDescription = "Почему производительность установки дистилляции растворителя со временем ухудшается?\r\nСуществует несколько распространенных причин снижения производительности установок для дистилляции растворителя. Изучите несколько наиболее распространенных проблем и узнайте, как их можно решить.\r\nИмеется ли на вашем предприятии дистилляционная установка для переработки загрязненных растворителей? Если она есть, то это очень здорово!  Это означает, что вы экономите на расходах при покупке нового растворителя, снижаете плату за утилизацию опасных отходов и заботитесь об окружающей среде!\r\nОднако знаете ли вы, что производительность установки для дистилляции растворителя со временем будет ухудшаться, что в конечном итоге будет стоить вам части сэкономленных средств?\r\nОсновные проблемы с которыми Вы сможете столкнуться при уменьшении  производительности установки дистилляции растворителя.\r\n", BigDescription = "В первую очередь на производительность установки дистилляции растворителя влияет продолжающееся накопление шлама в дистилляционной емкости, длительное отсутствие внимания и устаревание электрических компонентов.\r\nПодобно автомобилю и наиболее важному оборудованию, система регенерации растворителей на месте требует регулярного технического обслуживания, ежедневного, еженедельного, ежемесячного, ежеквартального и ежегодного. Также как и в случае с автомобилем, производительность машины будет снижена, если некоторые элементы технического обслуживания не будут устранены, когда это необходимо. Без надлежащего технического обслуживания проблемы с производительностью могут привести к дополнительным расходам, которые можно было бы предотвратить.\r\nПроблемы нагрева термального масла\r\nДистилляционная установка требует источника нагрева, достаточно сильного, чтобы преодолеть физические свойства перегоняемого растворителя. Наиболее распространенными источниками нагрева являются диатермическое  масло с электрическим нагревом или паровая рубашка.\r\nДиатермическое масло необходимо заменять ежегодно. Несвоевременная замена теплового масла приведет к нагарообразованию масляной рубашки.\r\nНагар накапливается как на боковых стенках бака, так и на нагревательных элементах. Отложения на боковых стенках действуют как изолятор, препятствующий эффективной передаче тепла. Наросты на нагревательных элементах приводят к выходу из строя нагревателя.\r\nНакопление шлама на нагревательных поверхностях\r\nДистилляционная установка будет накапливать осадок на нагревательных поверхностях при постоянном использовании. Скопление шлама на нагревательных поверхностях снижает эффективность нагрева, требуя больше времени для обработки растворителя и больше энергии для работы системы.\r\n\r\nДистиллятор растворителя требует ежедневной очистки поверхности нагрева, по крайней мере, после каждой разгрузки.\r\nНакопление шлама на ненагреваемых поверхностях\r\nСкопление шлама на ненагреваемых поверхностях может привести к загрязнению дистиллята, так как частицы ила улетучиваются с парами растворителя.\r\nПроблемы с электрическими компонентами\r\nУстаревание электрических компонентов также является фактором, негативно влияющим на эффективность дистилляции.\r\nПЛК, усилители, датчики и другие устройства со временем выводятся из употребления производителями. \r\nИногда возможна индивидуальная замена. Тем не менее, часто требуются модификации для размещения компонентов для прямой замены.\r\nУстаревание ПЛК  может потребовать всего нового программного обеспечения или программ для поддержки сменного устройства. Если вы решите использовать неподдерживаемые устройства, они могут ухудшить производительность дистилляции, когда начнутся сбои с более длительным временем выполнения заказа, при поиске метода замены или требуя от операторов обходных путей процесса.\r\nНезапланированные расходы могут увеличиться\r\nПродолжительное использование неэффективной дистилляционной установки влияет на весть процесс перегонки.\r\nВместо того чтобы эффективно очищать ваш растворитель, большое количество растворителя отправляется в отходы и требует покупки увеличенного объема чистого растворителя. Ценное время оператора требуется, чтобы сосредоточиться на дистилляционной установке, а не на других рабочих обязанностях.\r\nДля продолжения работы системы требуется больше времени на техническое обслуживание и трудозатраты. Снижение производительности дистилляционной установки напрямую влияет на общую стоимость работы.\r\nНаши рекомендации.\r\nКак и в случае с автомобилем, невыполнение профилактического и планового технического обслуживания приведет к долгосрочным и потенциально дорогостоящим проблемам с производительностью. \r\nОчистка бака\r\nЕжедневно очищать бак от образований накипи. Таким образом улучшается тепловой обмен между стенками испарительного бака дистиллятора и обрабатываемым растворителем.\r\nКонтроль диатермического масла\r\nКонтролировать в холодном состоянии уровень диатермического масла.\r\nОчистка контура конденсации паров.\r\nПериодически продувать сжатым воздухом с давлением коллектора паров в баке дистиллятора в сторону выхода дистиллята и в обратном направлении для вычистки возможных образований, сформировавшихся в трубопроводе и конденсоре. Периодически производить очистку сжатым воздухом внешней поверхности конденсора\r\nРекомендуется замена диатермического масла после 1000 часов работы. Тип масла: АМТ-300, МТ-300.  При каждой замене диатермического масла необходимо проверить стравливающий воздушный  клапан на крышке.\r\nОчистка нагревательного элемента.\r\nПри эксплуатации дистиллятора на электрическом резисторе происходит налипание \r\nнакипи. Для нормального теплообмена необходимо ежегодно производить его очистку.\r\n" },
               new News { Id = 2, Url = "pomosh-v-vibore-distillatora-rastvoriteley",
                   Image = "Img/news/help.png",
                   Title = "4 основных параметря для выбора дистиллятора",
                   SmallDescription = "Восстановление растворителя на месте проще, чем вы думаете. Но прежде чем вы приобретете дистиллятор, вам необходимо определить мощность, которая потребуется вашему оборудованию. Есть четыре критерия, которые необходимо изучить, чтобы определить требуемую производительность установки по регенерации растворителя: объем отходов растворителя, время работы, температура кипения и процент загрязнения.", BigDescription = "Как определить емкость блока регенерации растворителя\r\nПрежде всего, если вы собираетесь начать химическую переработку, вы должны понимать, какие мощности необходимы для переработки. Это, в свою очередь, покажет размер бака, который требуется вашему заводу. Существует 4 параметра, которые необходимо знать  для определения производительности установки регенерации растворителя.\r\nДля начала спросите себя: какой суточный объем  растворителя образуется? Это можно проверить по отходам растворителей, которые в настоящее время перерабатываются и/или вывозятся за пределы предприятия для переработки или утилизации растворителей. Для этого определите, сколько отходов растворителя образуется ежедневно, еженедельно, ежемесячно и/или ежеквартально. Затем проверьте свои цифры, просмотрев актуальную документы об отходах, чтобы убедиться, что ваши данные верны. Еще одна проверка заключается в проверке количества растворителя, приобретенного для очистки.\r\nНапример, допустим, вы считаете, что среднесуточный объем образующихся отходов растворителя составляет 10 литров. Следующим шагом будет просмотр документов, чтобы определить общее количество отработанного растворителя, отгружаемого ежемесячно или ежеквартально. Допустим, ответ — 6 бочек в месяц. Чтобы проверить математику, мы умножим 6 бочек на 200 литров, чтобы получить 1 200 литров в месяц. Затем, чтобы преобразовать это значение в дневной расход, просто разделите 1 200 литров на 22 рабочих дня. Ответ: 54,5 литров отходов, образующихся каждый день. Это тревожный сигнал, так как 54,5 литра в день — это совсем другое число, чем первоначальные 10 литров. Мы рекомендуем вам ознакомиться с документами об отходах, чтобы убедиться в фактической отгрузке отходов.  \r\nПосле определения ваших текущих потребностей в чистящем растворителе вы также должны определить свои будущие потребности. Вам следует обсудить будущие потребности в переработке растворителей с производственным отделом, чтобы спрогнозировать будущие объемы. Установка дистилляции растворителя должна прослужить не менее 5 лет, но обычно служит в пределах 15-20 лет. Это означает, что вы должны смотреть на свои потребности в использовании в течение следующего десятилетия.\r\nСледующим шагом будет определение времени, необходимого для работы установки дистилляции растворителя. Некоторые предприятия предпочитают не включать свои установки по переработке растворителей на ночь или в выходные дни. Тем не менее, с современными технологиями, предоставляемыми нашими установками, вполне возможно эксплуатировать регенератор  24 часа в сутки, 7 дней в неделю. Важно осознавать, что машины нуждаются в техническом обслуживании и ремонте. Просто нереально предполагать, что машина будет работать постоянно. Механические проблемы будут возникать время от времени. Хорошее эмпирическое правило для предприятий, приобретающих дистилляционное оборудование, заключается в том, что время безотказной работы должно составлять 85 %.. Тем не менее, некоторые предприятия будут иметь более высокое время безотказной работы, чем другие. Это связано с тем, что время безотказной работы почти полностью зависит от персонала, в который входят оператор машины, отдел технического обслуживания и руководитель процесса. Когда-то блестящая программа утилизации на месте может измениться за одну ночь, когда сменится оператор или другой ключевой персонал. Еще один важный момент, который следует отметить, заключается в том, что время безотказной работы не будет оставаться постоянным. Когда предприятие впервые внедряет установку дистилляции растворителя, большое внимание уделяется процессу, что приводит к значительному увеличению времени безотказной работы. К сожалению, когда волнение уляжется и наступит реальность повседневной рутинной работы, установка по переработке растворителей, скорее всего, не будет иметь такого же высокого уровня концентрации и внимания. Мы отмечаем это как поучительную историю, чтобы убедиться, что предприятия точно оценивают время безотказной работы.\r\nБыло бы здорово, если бы единственным требованием для поиска идеального регенератора растворителей было количество отходов, которое он перерабатывает за день. Но это не так. Есть два других фактора, которые необходимо учитывать: температура кипения растворителя (растворителей), которые будут извлечены с помощью оборудования для дистилляции растворителя, и процентное содержание загрязняющих веществ в потоке отходов очистки растворителя. Чем выше температура кипения и процентное содержание загрязняющих веществ в растворителе, тем больше времени потребуется машине для обработки отходов. Оба фактора независимо друг от друга влияют на размер устройства, необходимого для объекта. Растворитель с более высокой температурой кипения означает, что для прохождения процесса дистилляции требуется больше энергии. Это приводит к увеличению времени, необходимого для достижения агрегатом правильной температуры, что продлевает цикл восстановления. В то время как более высокое загрязнение означает, что машинам придется чаще сливать остаток, чтобы гарантировать, что материал не станет слишком вязким для обработки. Больше циклов слива означает больше времени.\r\nПодведем итоги.\r\nНадеемся, что эта статья помогла Вам  получить достоверную информацию о том, как вы можете определить идеальную установку для дистилляции растворителя для вашего предприятия. Мы помогли вам понять четыре фактора, которые необходимо учитывать при определении производительности вашей установки по регенерации растворителей: \r\nобъем отходов растворителя,\r\n время работы,\r\n температура кипения\r\n и процент загрязнения. \r\n" });
        }
    }
}
