using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Repository
{
    public class PatientInformationRepo : IPatientInformationRepo
    {
        public ApplicationDBContext dBContext;

        public PatientInformationRepo(ApplicationDBContext dBContext)
        {
            this.dBContext = dBContext ?? throw new ArgumentNullException(nameof(dBContext));
        }

        public int PatientInformationInsert(PatientInformation patientInformation)
        {
            dBContext.PatientInformation.Add(patientInformation);
            dBContext.SaveChanges();

            return patientInformation.Id;
        }
    }
}
