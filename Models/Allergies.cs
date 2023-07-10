namespace WebApplication1.Models
{
    public class Allergies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Allergies_Details> Allergies_Details { get; set; }
    }
}
