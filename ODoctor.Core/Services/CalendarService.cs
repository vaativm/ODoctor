using ODoctor.Core.DTOs;
using ODoctor.Core.Entities;
using ODoctor.Core.Interfaces;
using ODoctor.Core.Specifications;
using System.Threading.Tasks;

namespace ODoctor.Core.Services
{
    public class CalendarService : ICalendarService
    {
        private readonly IAsynRepository<Calendar> _calendarRepository;
        public CalendarService(IAsynRepository<Calendar> calendarRepository)
        {
            _calendarRepository = calendarRepository;
        }
        public async Task<DoctorCalendarDTO> GetDoctorCalendar(int doctorId, int clinicId)
        {
            var doctorCalendarDTO = new DoctorCalendarDTO();
            var calendar = await _calendarRepository.GetEntityAsync(new DoctorCalendarSpecification(doctorId, clinicId));

            if (calendar != null)
            {
                doctorCalendarDTO= new DoctorCalendarDTO()
                {
                    ClinicId = calendar.ClinicId,
                    ClinicName = calendar?.Clinic?.Name,
                    DoctorId = calendar.DoctorId,
                    DoctorName = calendar?.Doctor?.FullName,
                    Services = calendar?.Clinic?.Services,
                    Timeslots = calendar?.Timeslots
                };
            }

            return doctorCalendarDTO;
        }
    }
}
