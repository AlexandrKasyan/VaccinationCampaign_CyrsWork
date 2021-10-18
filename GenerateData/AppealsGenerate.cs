using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class AppealsGenerate
    {
        public void AppealsDataGenerate()
        {
            Random rnd = new Random();
            ApplicationContext context = new ApplicationContext();
            string[] discriptions = { "Болезненные ощущения", "Аллергическая сыпь", "Покраснения и уплотнения", "отек", "уплотнения лимфоузлов", "повышение температуры", "потеря аппетита", "появлении сыпи", "ощущение недомогания", " головная боль" };
            
            string[] recommendations = { "Избегать заметных физических и эмоциональных нагрузок.",
                "При повышении температуры выше 38° используют жаропонижающие",
                "Внимательно следите за состоянием организма, если у привитого.",
                "Лучше избегать продуктов – облигатных аллергенов.",
                "В первые 7-10 дней старайтесь избегать контакта с другими людьми. ",
                "Рекомендуется через 3 – 4 недели после прививки сделать общий анализ мочи",
                "Постоянные отклонения от нормального самочувствия – повод вызвать врача.",
                "Повод присмотреть небольшой земельный участок"};

            string[] doctor = { "Касьян", "Корнеев", "Болотникова", "Иванова", "Дубинов", "Климанский", "Киркоров", "Пантюшечкина", "Кончиков", "Хомчук" };

            var patientsId = context.Patients.Select(x => x.Id).ToArray();



            var appeals = new List<Appeal>();
            for (int i = 0; i < 1000; i++)
            {
                appeals.Add(new Appeal
                {
                    Description = Rand(discriptions),
                    Data = RandomDay(),
                    Recommendation = Rand(recommendations),
                    Doctor = Rand(doctor),
                    PatientId = patientsId[rnd.Next(0, patientsId.Length)]
                });
            }

            // context.Addresses.Add(address);
            context.Appeals.AddRange(appeals);
            context.SaveChanges();
        }

        private static string Rand(string[] array)
        {
            Random rnd = new Random();
            string str = array[rnd.Next(0, array.Length)];
            return str;
        }

        DateTime RandomDay()
        {
            Random rnd = new Random();
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
