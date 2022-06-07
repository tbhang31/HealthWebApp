using liftoffHealthCare.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace liftoffHealthCare.ViewModels
{
    public class AddMedicationViewModel
    {
        public int MedicationId { get; set; }

        [Required(ErrorMessage ="You must include the medication name (brand name or generic)")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must include the medication dose(number only)")]
        public double Dosage { get; set; }

        [Required(ErrorMessage = "You must include the metric of the medication you take")]
        public DosageDescription DosageDescription { get; set; }

        [Required(ErrorMessage = "You must include the dose metric")]
        public List<SelectListItem> DosageDescriptions { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(DosageDescription.mg.ToString(),((int)DosageDescription.mg).ToString()),
            new SelectListItem(DosageDescription.g.ToString(),((int)DosageDescription.g).ToString()),
            new SelectListItem(DosageDescription.mL.ToString(),((int)DosageDescription.mL).ToString()),
            new SelectListItem(DosageDescription.L.ToString(),((int)DosageDescription.L).ToString()),
            new SelectListItem(DosageDescription.oz.ToString(),((int)DosageDescription.oz).ToString()),
            new SelectListItem(DosageDescription.tsp.ToString(),((int)DosageDescription.tsp).ToString()),
            new SelectListItem(DosageDescription.tbsp.ToString(),((int)DosageDescription.tbsp).ToString())
        };

        [Required(ErrorMessage = "You must include how many times you can take the medication")]
        public Instructions Instruction { get; set; }

        public List<SelectListItem> Times { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(Instructions.select.ToString(),((int)Instructions.daily).ToString()),
            new SelectListItem(Instructions.daily.ToString(),((int)Instructions.daily).ToString()),
            new SelectListItem(Instructions.bid.ToString(),((int)Instructions.bid).ToString()),
            new SelectListItem(Instructions.tid.ToString(),((int)Instructions.tid).ToString()),
            new SelectListItem(Instructions.qid.ToString(),((int)Instructions.q2h).ToString()),
            new SelectListItem(Instructions.prn.ToString(),((int)Instructions.prn).ToString()),
            new SelectListItem(Instructions.other.ToString(),((int)Instructions.other).ToString()),
        };


    }
}
