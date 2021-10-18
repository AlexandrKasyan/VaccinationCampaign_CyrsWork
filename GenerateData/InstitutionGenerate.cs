using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
   public class InstitutionGenerate
    {
        public void InstitutionDataGenerate()
        {
            Random rnd = new Random();
            ApplicationContext context = new ApplicationContext();
            string[] nameArray = { "1-я центральная районная поликлиника",
                "17-я городская клиническая поликлиника",
                "36-я городская поликлиника",
                "22-я городская поликлиника", 
                "5-я городская клиническая",
                "10-я городская клиническая ",
                "11-я городская клиническая",
                "ТЦ МОМО",
                "УП Универмаг Беларусь",
                "37-я городская поликлиника" };
            string[] addressArray = { "г. Минск, пр. Рокоссовского, 134", "г. Минск, ул. Я. Лучины, 28", "г. Минск, ул.Р.Люксембург,112", "г.Минск, ул. Филатова, 13", "г.Минск, ул. Герасименко, 49", "г.Минск, ул. Алеся Бачило, 9", "г. Минск. ул. Филатова, 9", "г. Минск, Партизанский просп., 52", "г. Минск ул. Ульяновская,5", "г. Минск, пр. Рокоссовского, 134" };
            var appealsId = context.Appeals.Select(x => x.Id).ToArray();


            var institutions = new List<MedicalInstitution>();
            for (int i = 0; i < 1000; i++)
            {
                institutions.Add(new MedicalInstitution
                {
                    NameMedInst = Rand(nameArray),
                    AdressMedInst = Rand(addressArray),
                    AppealId = appealsId[rnd.Next(0, appealsId.Length)]
                    
                });
            }

            // context.Addresses.Add(address);
            context.Institution.AddRange(institutions);
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
