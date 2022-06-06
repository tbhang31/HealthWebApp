using liftoffHealthCare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace liftoffHealthCare.ViewModels
{
    public class AddVitalMedicationViewModel
    {
        [Required(ErrorMessage = "Vitals Entry ID required")]
        public int VitalId { get; set; }

        public Vital Vitals { get; set; }

        [Required(ErrorMessage = "Medication Entry ID required")]
        public int MedicationId { get; set; }

        public List<SelectListItem> Medications { get; set; }

        public AddVitalMedicationViewModel(Vital vitals, List<Medication> possibleMedications)
        {
            Medications = new List<SelectListItem>();

            foreach (var medication in possibleMedications)
            {
                Medications.Add(new SelectListItem
                {
                    Value = medication.Id.ToString(),
                    Text = medication.Name
                });
            }
            Vitals = vitals;
        }

        public AddVitalMedicationViewModel()
        {
        }
    }
}

