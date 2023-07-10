using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface IAllergiesRepo
    {
        List<Allergies> AllergiesGetAll();
        Allergies AllergiesGetById(int id);
    }
}
