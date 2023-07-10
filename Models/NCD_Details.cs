namespace WebApplication1.Models
{
    public class NCD_Details
    {
        public int Id { get; set; }
        public int PatientID { get; set; }
        public int NCDID { get; set; }
        public NCD NCD { get; set; }
    }
}
