using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class NCDRepo : INCDRepo
    {
        private ApplicationDBContext dbContext;

        public NCDRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<NCD> NCDGetAll()
        {
            return dbContext.NCD.ToList();
        }

        public NCD NCDGetById(int id)
        {
            return dbContext.NCD.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
