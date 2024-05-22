using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Models
{
    public class DiseaseInformation
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
