namespace WebApplication1.Models
{
    public class NCD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<NCD_Details> NCD_Details { get; set; }
    }
}
