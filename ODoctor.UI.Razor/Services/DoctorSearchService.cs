using Microsoft.AspNetCore.Mvc.Rendering;
using ODoctor.Core.Entities;
using ODoctor.Core.Interfaces;
using ODoctor.Core.Specifications;
using ODoctor.UI.Razor.Interfaces;
using ODoctor.UI.Razor.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODoctor.UI.Razor.Services
{
    public class DoctorSearchService : Interfaces.IDoctorSearchService
    {
        private readonly IAsynRepository<County> _countyRepository;
        private readonly IAsynRepository<Speciality> _specialityRepository;
        private readonly IAsynRepository<Clinic> _clinicRepository;
        private readonly IAsynRepository<ClinicAssignment> _clinicDoctorsRepository;
        public DoctorSearchService(IAsynRepository<County> countyRepository, IAsynRepository<Speciality> specialityRepository,
            IAsynRepository<Clinic> clinicRepository, IAsynRepository<ClinicAssignment> clinicDoctorsRepository)
        {
            _countyRepository = countyRepository;
            _specialityRepository = specialityRepository;
            _clinicRepository = clinicRepository;
            _clinicDoctorsRepository = clinicDoctorsRepository;
        }
        public async Task<SelectList> GetCounties()
        {
            IList<CountySLViewModel> counties = new List<CountySLViewModel>();

            foreach(var county in await _countyRepository.ListAllAsync())
            {
                counties.Add(new CountySLViewModel() { Id = county.Id, Name = county.Name });
            }

            return new SelectList(counties, "Id", "Name");
        }

        public async Task<SelectList> GetSpecialities()
        {
            IList<SpecialitySLViewModel> specialities = new List<SpecialitySLViewModel>();

            foreach (var speciality in await _specialityRepository.ListAllAsync())
            {
                specialities.Add(new SpecialitySLViewModel() { Id = speciality.Id, Name = speciality.Name });
            }

            return new SelectList(specialities, "Id", "Name");
        }
        public async Task<IList<ClinicViewModel>> GetClinicsInfo(HashSet<int> selectedLocations, HashSet<int> SelectedSpecialities)
        {
            var clinics = await _clinicRepository.ListAsync(new ClinicWithDoctorsFilterSpecification(selectedLocations));
            var clinicsInfo = new List<ClinicViewModel>();

            foreach(Clinic clinic in clinics)
            {
                var clinicInfo = new ClinicViewModel();

                clinicInfo.Id = clinic.Id;
                clinicInfo.Name = clinic.Name;
  
                foreach(var d in clinic.Doctors)
                {
                    if (SelectedSpecialities.Contains(d.Doctor.SpecialityId))
                        clinicInfo.ClinicSpecialities.Add(new ClinicSpeciality() { Id = d.Doctor.SpecialityId, Name = d.Doctor.Speciality.Name });
                }

                clinicsInfo.Add(clinicInfo);
            }

            return clinicsInfo;
        }

        public async Task<ClinicDoctorsViewModel> GetDoctorsProfile(int clinicId, HashSet<int> specialities)
        {
            var clinicDoctors = await _clinicDoctorsRepository.ListAsync(new ClinicDoctorsProfileSpecification(clinicId,specialities));
            ClinicDoctorsViewModel clinicDoctorsViewModel = new ClinicDoctorsViewModel();
            clinicDoctorsViewModel.ClinicName = clinicDoctors.Select(c => c.Clinic.Name).FirstOrDefault();
            clinicDoctorsViewModel.ClinicId = clinicId;
            
            var doctorprofiles = new List<DoctorProfileViewModel>();

            foreach(var clinicDoctor in clinicDoctors)
            {
                var doctorProfile = new DoctorProfileViewModel();
                doctorProfile.FullName = $"Dr. {clinicDoctor.Doctor.FirstName} {clinicDoctor.Doctor.MiddleName} {clinicDoctor.Doctor.LastName}";
                doctorProfile.Speciality = clinicDoctor.Doctor.Speciality.Name;
                clinicDoctorsViewModel.DoctorProfiles.Add(doctorProfile);
            }
            
            return clinicDoctorsViewModel;
        }
    }
}
