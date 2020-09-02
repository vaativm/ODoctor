using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ODoctor.UI.Razor.Interfaces;
using ODoctor.UI.Razor.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODoctor.UI.Razor.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly IDoctorSearchService _doctorSearchService;
        public IndexModel(IDoctorSearchService doctorSearchService)
        {
            _doctorSearchService = doctorSearchService;
        }

        public SelectList Specialities { get; set; } 
        public SelectList Counties { get; set; }
        
        [BindProperty(SupportsGet =true)]
        public HashSet<int> SelectedLocations { get; set; }

        [BindProperty(SupportsGet = true)]
        public HashSet<int> SelectedSpecialities { get; set; }
        public IList<ClinicViewModel> Clinics { get; set; } = new List<ClinicViewModel>();
       

        public async Task OnGetAsync()
        {
            Specialities = await _doctorSearchService.GetSpecialities();
            Counties = await _doctorSearchService.GetCounties();

            Clinics = await _doctorSearchService.GetClinicsInfo(SelectedLocations, SelectedSpecialities);
        }

        public void OnPostAsync()
        {

        }
    }
}