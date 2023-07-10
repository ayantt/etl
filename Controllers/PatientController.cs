using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Enum;
using WebApplication1.Models;
using WebApplication1.Repository.Interface;

namespace WebApplication1.Controllers
{
    public class PatientController : Controller
    {
        public IAllergiesRepo allergiesRepo;
        public INCDRepo nCDRepo;
        public IDiseaseInformationRepo diseaseInformationRepo;
        public IPatientInformationRepo patientInformationRepo;
        public IAllergiesDetailRepo allergiesDetailRepo;
        public INCDDetailsRepo ncdDetailsRepo;

        public PatientController(IAllergiesRepo allergiesRepo, INCDRepo nCDRepo, 
                                IDiseaseInformationRepo diseaseInformationRepo, IPatientInformationRepo patientInformationRepo, 
                                IAllergiesDetailRepo allergiesDetailRepo, INCDDetailsRepo ncdDetailsRepo)
        {
            this.allergiesRepo = allergiesRepo;
            this.nCDRepo = nCDRepo;
            this.diseaseInformationRepo = diseaseInformationRepo;
            this.patientInformationRepo = patientInformationRepo;
            this.allergiesDetailRepo = allergiesDetailRepo;
            this.ncdDetailsRepo = ncdDetailsRepo;
        }

        public IActionResult Index()
        {
            ViewBag.Allergies = allergiesRepo.AllergiesGetAll();
            ViewBag.NCD = nCDRepo.NCDGetAll();
            ViewBag.DiseaseInfo = diseaseInformationRepo.DiseaseInformationGetAll();

            var enumValues = Epilepsy.GetValues(typeof(Epilepsy)).Cast<Epilepsy>();

            var selectListItems = enumValues.Select(e => new SelectListItem
            {
                Text = e.ToString(),
                Value = ((int)e).ToString()
            }).ToList();

            ViewBag.Epilepsy = selectListItems;

            return View();
        }

        [HttpPost]
        public IActionResult SavePatientInfo(PatientInformation patientInformation, List<int> allergies_Details, List<int> nCD_Details)
        {
            int patientId = patientInformationRepo.PatientInformationInsert(patientInformation);

            foreach (var item in nCD_Details)
            {
                ncdDetailsRepo.NCDDetailsInsert(new NCD_Details
                {
                    PatientID = patientId,
                    NCDID = item
                });
            }

            foreach (var item in allergies_Details)
            {
                allergiesDetailRepo.AllergiesDetailsInsert(new Allergies_Details
                {
                    PatientID = patientId,
                    AllergiesID = item
                });
            }

            return RedirectToAction("Index", "Patient");
        }
    }
}
