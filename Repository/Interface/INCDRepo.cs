using WebApplication1.Models;

namespace WebApplication1.Repository.Interface
{
    public interface INCDRepo
    {
        List<NCD> NCDGetAll();
        NCD NCDGetById(int id);
    }
}
