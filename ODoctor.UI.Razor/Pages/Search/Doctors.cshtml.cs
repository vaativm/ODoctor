using Microsoft.AspNetCore.Mvc.RazorPages;
using ODoctor.UI.Razor.Interfaces;
using ODoctor.UI.Razor.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ODoctor.UI.Razor.Pages.Search
{
    public class DoctorsModel : PageModel
    {
        private readonly IDoctorSearchService _doctorSearchService;
        
        public ClinicDoctorsViewModel ClinicDoctorsViewModel { get; set; } = new ClinicDoctorsViewModel();

        public DoctorsModel(IDoctorSearchService doctorSearchService)
        {
            _doctorSearchService = doctorSearchService;
        }

        public async Task OnGetAsync(int clinicId, string specialities)
        {
            var selectedSpecialities = specialities.Split(",").Select(int.Parse).ToHashSet<int>();

            ClinicDoctorsViewModel = await _doctorSearchService.GetDoctorsProfile(clinicId, selectedSpecialities);
        }
    }
}
