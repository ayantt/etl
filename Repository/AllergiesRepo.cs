using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class AllergiesRepo : IAllergiesRepo
    {
        private ApplicationDBContext dbContext;

        public AllergiesRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<Allergies> AllergiesGetAll()
        {
            return dbContext.Allergies.ToList();
        }

        public Allergies AllergiesGetById(int id)
        {
            return dbContext.Allergies.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
