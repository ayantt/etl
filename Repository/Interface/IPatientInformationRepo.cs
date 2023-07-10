using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface IPatientInformationRepo
    {
        public int PatientInformationInsert(PatientInformation patientInformation);
    }
}
