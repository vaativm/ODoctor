using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ODoctor.Core.Interfaces;
using ODoctor.UI.Razor.Models;
using System.Threading.Tasks;

namespace ODoctor.UI.Razor.Pages.Calendar
{
    public class IndexModel : PageModel
    {
        private ICalendarService _calendarService;
        public IndexModel(ICalendarService calendarService)
        {
            _calendarService = calendarService;
        }

        public DoctorCalendarViewModel DoctorCalendar { get; set; }
        public async Task OnGetAsync(int doctorId, int clinicId)
        {
            var doctorCalendar = await  _calendarService.GetDoctorCalendar(doctorId, clinicId);
            DoctorCalendar = new DoctorCalendarViewModel()
            {
                ClinicId = doctorCalendar.ClinicId,
                ClinicName = doctorCalendar.ClinicName,
                DoctorId = doctorCalendar.DoctorId,
                DoctorName = doctorCalendar.DoctorName,
                Services = new SelectList(doctorCalendar.Services, "Id", "Name"),
                Timeslots = doctorCalendar.Timeslots
            };
        }
    }
}