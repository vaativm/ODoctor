using ODoctor.Core.Entities;
using ODoctor.Core.Exceptions;
using ODoctor.Core.Interfaces;
using ODoctor.Core.Specifications;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ODoctor.Core.Services
{
    public class AppointmentService: IAppointmentService
    {
        private readonly IAsynRepository<Appointment> _appointmentAsynRepository;
        public AppointmentService(IAsynRepository<Appointment> appointmentAsynRepository)
        {
            _appointmentAsynRepository = appointmentAsynRepository;
        }

        public async Task Book(Appointment appointment)
        {
            int serviceDuration = appointment?.Token?.Service?.Duration ?? 0;
            int availableTime = appointment?.Token?.Timeslot?.GetAvailableTime() ?? 0;

            if (serviceDuration > availableTime)
            {
                throw new InsufficientTimeException($"{availableTime} is not enough to book a {serviceDuration} minutes service");
            }

            await _appointmentAsynRepository.AddAsync(appointment);
        }   
    }
}
