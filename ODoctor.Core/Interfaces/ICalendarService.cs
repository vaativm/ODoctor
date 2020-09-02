using ODoctor.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ODoctor.Core.Interfaces
{
    public interface ICalendarService
    {
        Task<DoctorCalendarDTO> GetDoctorCalendar(int doctorId, int calendarId);
    }
}
