using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DiseaseId { get; set; }
        public DiseaseInformation Disease { get; set; }

        [Required]
        public Epilepsy Epilepsy { get; set; }

        public ICollection<NCD_Details> NCDs { get; set; }
        public ICollection<Allergies_Details> Allergies { get; set; }
    }
}
