using ODoctor.Core.Entities;
using System.Threading.Tasks;

namespace ODoctor.Core.Interfaces
{
    public interface IAppointmentService
    {
        Task Book(Appointment appointment);
    }
}
