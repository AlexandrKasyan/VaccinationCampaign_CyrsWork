using System;
using System.Collections.Generic;
using System.Linq;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class AddressGenerate
    {
        public void AddressDataGenerate()
        {
            Random rnd = new Random();

            string[] countruArray = { "Belarus", "Russia", "Poland", "Ukraine", "Croatia", "Germany", "Zimbabwe", "France", "Latvian", "Estonia" };
            string[] localituArray = { "Abidjan", "Perth", "Nagoya", "Odessa", "Cordoba", "Kishinev", "Krakow", "Tashkent", "Qingdao", "Zurich" };
            string[] regionArray = { "Alabama", "Colorado", "Idaho", "Indiana", "Kansas", "Iowa", "Louisiana", "Mississippi", "Nevada", "Ohio" };



            var addresses = new List<Address>();
            for (int i = 0; i < 1000; i++)
            {
                addresses.Add(new Address
                {
                    Coutry = Rand(countruArray),
                    Flat = i,
                    Hous = i.ToString(),
                    Locality = Rand(localituArray),
                    Region = Rand(regionArray)
                });
            }

            ApplicationContext context = new ApplicationContext();

            // context.Addresses.Add(address);
            context.Addresses.AddRange(addresses);
            context.SaveChanges();



            var addressesIds = context.Addresses.Select(x => x.Id).ToArray();
        }

        private static string Rand(string[] array)
        {
            Random rnd = new Random();
            string str = array[rnd.Next(0, array.Length)];
            return str;
        }

    }
}
