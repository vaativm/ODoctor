using ODoctor.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ODoctor.Core.Interfaces
{
    public interface IDoctorSearchService
    {
        //Task<IList<ClinicInfoDTO>> GetClinicsInfo(HashSet<int> selectedLocations, HashSet<int> slectedSpecialities);
        Task<ClinicDoctorsDTO> GetDoctorsProfile(int clinicId, HashSet<int> specialities);
    }
}
