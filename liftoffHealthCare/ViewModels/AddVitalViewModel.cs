using liftoffHealthCare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace liftoffHealthCare.ViewModels
{
    public class AddVitalViewModel
    {

        [Required(ErrorMessage = "Vitals must have a date associated with them")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vitals must have a heart rate")]
        public int HeartRate { get; set; }

        [Required(ErrorMessage = "Vitals must have a systolic blood pressure(top number)")]
        public int Systolic { get; set; }

        [Required(ErrorMessage = "Vitals must have a diastolic blood pressure(bottom number)")]
        public int Diastolic { get; set; }

        public List<Medication> Medications { get; set; }
        public int MedicationId { get; set; }

        public AddVitalViewModel(List<Medication> medications)
        {
            Medications = medications;
        }

        public AddVitalViewModel()
        {
        }
    }
}
