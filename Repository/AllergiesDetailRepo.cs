using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class AllergiesDetailRepo : IAllergiesDetailRepo
    {
        public ApplicationDBContext dBContext;

        public AllergiesDetailRepo(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }

        public List<Allergies_Details> AllergiesDetailsGetAll()
        {
            return dBContext.AllergiesDetails.ToList();
        }

        public List<Allergies_Details> AllergiesDetailsGetByPatientId(int id)
        {
            return dBContext.AllergiesDetails.Where(x=>x.PatientID == id).ToList();
        }

        public void AllergiesDetailsInsert(Allergies_Details details)
        {
            dBContext.AllergiesDetails.Add(details);
            dBContext.SaveChanges();
        }
    }
}
