using Microsoft.AspNetCore.Mvc.Rendering;
using ODoctor.UI.Razor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODoctor.UI.Razor.Interfaces
{
    public interface IDoctorSearchService
    {
        Task<SelectList> GetCounties();
        Task<SelectList> GetSpecialities();
        Task<IList<ClinicViewModel>> GetClinicsInfo(HashSet<int> selectedLocations, HashSet<int> slectedSpecialities);
        Task<ClinicDoctorsViewModel> GetDoctorsProfile(int clinicId ,HashSet<int> specialities);
    }
}
