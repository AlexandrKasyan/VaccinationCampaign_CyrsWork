using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class PatientGenerate
    {
        public void PatientDataGenerate()
        {
            Random rnd = new Random();
            ApplicationContext context = new ApplicationContext();
            string[] nameArray = { "Александр", "Богдан", "Валентин", "Василий", "Виталий", "Виктор", "Евгений", "Мирослав", "Юлиан", "Никита" };
            string[] lastNameArray = { "Касьян", "Черных", "Долгих", "Грымау", "Штаненко", "Кручёных", "Минадзе", "Мейе", "Грицевецу", "Точко" };
            var addressesId = context.Addresses.Select(x => x.Id).ToArray();


            var patients = new List<Patient>();
            for (int i = 0; i < 1000; i++)
            {
                patients.Add(new Patient
                {
                    Name = Rand(nameArray),
                    LastName = Rand(lastNameArray),
                    Sex = rnd.Next(100) < 50,
                    Passport = rnd.Next(99999999).ToString(),
                    AddressId = addressesId[rnd.Next(0, addressesId.Length)]
                });
            }

            // context.Addresses.Add(address);
            context.Patients.AddRange(patients);
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
