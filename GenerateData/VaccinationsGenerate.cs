using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class VaccinationsGenerate
    {
        Random rnd = new Random();
        public void VaccinationsDataGenerate()
        {
            Random rnd = new Random();

            ApplicationContext context = new ApplicationContext();
            string[] nameVaccine = { "АКДС", "Бубо-Кок", "Инфанрикс", "Пентаксим", "Тетраксим", "Инфанрикс-гекса", "АДАСЕЛЬ", "Твинрикс", "Инфанрикс", "Биовак" };
            var patientsId = context.Patients.Select(x => x.Id).ToArray();
            var vaccineId = context.Vaccines.Select(x => x.Id).ToArray();
            var medicalInsId = context.Institution.Select(x => x.Id).ToArray();


            var vaccinations = new List<Vaccination>();
            for (int i = 0; i < 1000; i++)
            {
                vaccinations.Add(new Vaccination
                {
                    NameVaccine = Rand(nameVaccine),
                    Date = RandomDay(),
                    NamberDose = rnd.Next(100),
                    PatientId = patientsId[rnd.Next(0, patientsId.Length)],
                    VaccineId = vaccineId[rnd.Next(0, vaccineId.Length)],
                    MedicalInsId = medicalInsId[rnd.Next(0, medicalInsId.Length)],
        
                    
                });
            }

            // context.Addresses.Add(address);
            context.Vaccinations.AddRange(vaccinations);
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
            DateTime start = new DateTime(2015, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rnd.Next(range));
        }
    }
}
