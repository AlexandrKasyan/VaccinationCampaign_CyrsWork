using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    public class VaccineGenerate
    {

        public void VaccineDataGenerate()
        {
            Random rnd = new Random();
            ApplicationContext context = new ApplicationContext();
            string[] DescriptionsArray = { "Рекомбинантная жидкая", "Рекомбинантная (рДНК)", "СмитКляйн Бичем-Биомед", "Центр Генной Инженерии", "АаКДС+ИПВ+Хиб+ГВ", "Анатоксин дифтерийно-столбнячный", "Анатоксин с содержанием антигенов", "Анатоксин адсорбированный", "Цельноклеточная АКДС вакцина", "АаКДС (с содержанием антигена)" };
            string[] ManufacturerArray = { "Санофи Пастер, Франция", "Серум Инститьют, Индия", "ГлаксоСмитКляйн, Бельгия", "Вектор, Россия", "Индия", "Мерк Шарп и Доум, США", "Санофи Пастер, Франция", "Институт иммунологии ИНК, Хорватия", "Пфайзер, США", "Уэст Пойнт, США" };
            var diseaseId = context.Diseases.Select(x => x.Id).ToArray();


            var vaccine = new List<Vaccine>();
            for (int i = 0; i < 1000; i++)
            {
                vaccine.Add(new Vaccine
                {
                    DescriptionVacc = Rand(DescriptionsArray),
                    Dose = rnd.Next(100),
                    Manufacturer = Rand(ManufacturerArray),
                    DiseaseId = diseaseId[rnd.Next(0, diseaseId.Length)]
                });            
            }

            // context.Addresses.Add(address);
            context.Vaccines.AddRange(vaccine);
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

