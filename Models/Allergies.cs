using System.ComponentModel.DataAnnotations;

namespace PatientManagement.Models
{
    public class Allergies
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
