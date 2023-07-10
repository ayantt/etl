using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class NCDDetailsRepo : INCDDetailsRepo
    {
        public ApplicationDBContext dbContext;

        public NCDDetailsRepo(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<NCD_Details> NCDDetailssGetAll()
        {
            return dbContext.NCD_Details.ToList();
        }

        public List<NCD_Details> NCDDetailssGetByPatientId(int id)
        {
            return dbContext.NCD_Details.Where(x=>x.PatientID== id).ToList();
        }

        public void NCDDetailsInsert(NCD_Details details)
        {
            dbContext.NCD_Details.Add(details);
            dbContext.SaveChanges();
        }
    }
}
