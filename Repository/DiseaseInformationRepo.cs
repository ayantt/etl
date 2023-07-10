using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class DiseaseInformationRepo : IDiseaseInformationRepo
    {
        private ApplicationDBContext dbContext;

        public DiseaseInformationRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<DiseaseInformation> DiseaseInformationGetAll()
        {
            return dbContext.DiseaseInformation.ToList();
        }

        public DiseaseInformation DiseaseInformationGetById(int id)
        {
            return dbContext.DiseaseInformation.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
