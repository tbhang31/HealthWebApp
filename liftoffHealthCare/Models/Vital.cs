using System;
using System.Collections.Generic;

namespace liftoffHealthCare.Models
{
    public class Vital
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int HeartRate { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
        public List<Medication> Medications { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public Vital(DateTime date, int heartRate, int systolic, int diastolic, string applicationUserId)
        {
            Date = date;
            HeartRate = heartRate;
            Systolic = systolic;
            Diastolic = diastolic;
            ApplicationUserId = applicationUserId;
        }

        public Vital()
        {
        }
    }
}