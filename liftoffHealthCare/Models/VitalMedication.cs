namespace liftoffHealthCare.Models
{
    public class VitalMedication
    {
        public int VitalId { get; set; }
        public Vital Vitals { get; set; }
        public int MedicationId { get; set; }
        public Medication Medication { get; set; }

        public VitalMedication()
        {
        }
    }
}