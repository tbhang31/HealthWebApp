using liftoffHealthCare.Models;
using System;
using System.Collections.Generic;

namespace liftoffHealthCare.ViewModels
{
    public class VitalsMedicationViewModel
    {
        public int VitalsId { get; set; }
        public DateTime Date { get; set; }
        public int HeartRate { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public string MedText { get; set; }

        public VitalsMedicationViewModel (Vital vitals, List<VitalMedication> vitalMedications)
        {
            VitalsId = vitals.Id;
            Date = vitals.Date;
            HeartRate = vitals.HeartRate;
            Systolic = vitals.Systolic;
            Diastolic = vitals.Diastolic;

            MedText = "";
            for(int i=0; i< vitalMedications.Count; i++)
            {
                MedText += vitalMedications[i].Medication.Name + " " + vitalMedications[i].Medication.Dosage + vitalMedications[i].Medication.DosageDescription;
                if (i<vitalMedications.Count-1)
                {
                    MedText += ", ";
                }
            }
        }
    }
}
