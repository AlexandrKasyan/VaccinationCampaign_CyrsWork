using System;
using System.Collections.Generic;
using VaccinationCampaignUI.Data;
using VaccinationCampaignUI.Models;

namespace GenerateData
{
    class Program
    {
        static void Main(string[] args)
        {
            AddressGenerate address = new AddressGenerate();
            address.AddressDataGenerate();
            PatientGenerate patientGenerate = new PatientGenerate();
            patientGenerate.PatientDataGenerate();
            AppealsGenerate appealsGenerate = new AppealsGenerate();
            appealsGenerate.AppealsDataGenerate();
            InstitutionGenerate institutionGenerate = new InstitutionGenerate();
            institutionGenerate.InstitutionDataGenerate();
            VaccineGenerate vaccineGenerate = new VaccineGenerate();
            vaccineGenerate.VaccineDataGenerate();
            VaccinationsGenerate vaccinationsGenerate = new VaccinationsGenerate();
            vaccinationsGenerate.VaccinationsDataGenerate();




        }

    }
}
