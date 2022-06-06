using System;
using System.ComponentModel.DataAnnotations;

namespace liftoffHealthCare.ViewModels
{
    public class AddVitalViewModel
    {
        public int Id { get; set; }
        public int VitalId { get; set; }

        [Required(ErrorMessage = "Vitals must have a date associated with them")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Vitals must have a heart rate")]
        public int HeartRate { get; set; }

        [Required(ErrorMessage = "Vitals must have a systolic blood pressure(top number)")]
        public int Systolic { get; set; }

        [Required(ErrorMessage = "Vitals must have a diastolic blood pressure(bottom number)")]
        public int Diastolic { get; set; }

        public AddVitalViewModel()
        {
        }
    }
}
