using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface INCDDetailsRepo
    {
        List<NCD_Details> NCDDetailssGetAll();
        List<NCD_Details> NCDDetailssGetByPatientId(int id);
        void NCDDetailsInsert(NCD_Details details);
    }
}
