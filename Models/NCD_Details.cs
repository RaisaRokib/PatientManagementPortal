namespace PatientManagement.Models
{
    public class NCD_Details
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int NCDId { get; set; }
        public Patient Patient { get; set; }
        public NCD NCD { get; set; }
    }
}
