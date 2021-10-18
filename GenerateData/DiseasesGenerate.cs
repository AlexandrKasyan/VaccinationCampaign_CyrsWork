using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class DiseasesGenerate
    {
        public void DiseasesDataGenerate()
        {
            Random rnd = new Random();
            ApplicationContext context = new ApplicationContext();
            string[] nameDisArray = { "Гепатит В", "Грипп", "Дифтерия", "Коклюш", "Корь", "Краснуха", "Паротит эпидемический (свинка)", "Пневмококковая инфекция", "Полиомиелит", "Столбняк и дифтерия" };

            var diseases = new List<Disease>();
            for (int i = 0; i < 1000; i++)
            {
                diseases.Add(new Disease
                {

                    NameDis = Rand(nameDisArray),
                    Code = rnd.Next(500),

                });

                // context.Addresses.Add(address);

            }
            context.Diseases.AddRange(diseases);
            context.SaveChanges();
        }

        private static string Rand(string[] array)
        {
            Random rnd = new Random();
            string str = array[rnd.Next(0, array.Length)];
            return str;
        }
    }
}
