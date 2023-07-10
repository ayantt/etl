using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface IAllergiesDetailRepo
    {
        List<Allergies_Details> AllergiesDetailsGetAll();
        List<Allergies_Details> AllergiesDetailsGetByPatientId(int id);
        void AllergiesDetailsInsert(Allergies_Details details);
    }
}
