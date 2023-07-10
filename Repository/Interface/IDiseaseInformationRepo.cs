using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface IDiseaseInformationRepo
    {
        List<DiseaseInformation> DiseaseInformationGetAll();
        DiseaseInformation DiseaseInformationGetById(int id);
    }
}
