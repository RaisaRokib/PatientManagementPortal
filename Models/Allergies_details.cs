namespace PatientManagement.Models
{
    public class Allergies_Details
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int AllergiesId { get; set; }
        public Patient Patient { get; set; }
        public Allergies Allergies { get; set; }
    }
}
