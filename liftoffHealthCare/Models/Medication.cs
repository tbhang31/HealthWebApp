namespace liftoffHealthCare.Models
{
    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Dosage { get; set; }
        public DosageDescription DosageDescription { get; set; }
        public Instructions Instruction { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public Medication(string name, double dosage, DosageDescription dosageDescription, Instructions instruction, string applicationUserId)
        {
            Name = name;
            Dosage = dosage;
            DosageDescription = dosageDescription;
            Instruction = instruction;
            ApplicationUserId = applicationUserId;
        }

        public Medication()
        {
        }
    }
}