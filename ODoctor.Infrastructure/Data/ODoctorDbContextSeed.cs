using Microsoft.Extensions.Logging;
using ODoctor.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ODoctor.Infrastructure.Data
{
    public class ODoctorDbContextSeed
    {
        public static async Task SeedAsync(ODoctorDbContext oDoctorDbContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                if (!oDoctorDbContext.Specialities.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredSpecialities());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Countries.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredCountries());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Counties.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredCounties());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Clinics.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredClinics());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Doctors.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredDoctors());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.ClinicAssignments.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredClinicAssignments());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Patients.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredPatients());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Services.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredServices());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Calendars.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredCalendars());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.CalendarServiceAssignments.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredCalendarServiceAssignments());
                    await oDoctorDbContext.SaveChangesAsync();
                }

                if (!oDoctorDbContext.Timeslots.Any())
                {
                    oDoctorDbContext.AddRange(GetPreConfiguredTimeslots());
                    await oDoctorDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var logger = loggerFactory.CreateLogger<ODoctorDbContextSeed>();
                    logger.LogError(ex.Message);

                    await SeedAsync(oDoctorDbContext, loggerFactory, retryForAvailability);
                }
            }
        }

        static IEnumerable<Speciality> GetPreConfiguredSpecialities()
        {
            return new List<Speciality>()
            {
                new Speciality() { Id = 1, Name = "Dentist" },
                new Speciality() { Id = 2, Name = "General Physician" },
                new Speciality() { Id = 3, Name = "Gynacologist" }
            };
        }

        static IEnumerable<Country> GetPreConfiguredCountries()
        {
            return new List<Country>()
            {
                new Country() { Id = 1, Code = "+254", Name = "Kenya" }
            };
        }
        static IEnumerable<County> GetPreConfiguredCounties()
        {
            return new List<County>()
            {
                new County() { Id = 1, Code = "001", Name = "Machakos", CountryId = 1 },
                new County() { Id = 2, Code = "002", Name = "Nairobi", CountryId = 1 }
            };
        }

        static IEnumerable<Clinic> GetPreConfiguredClinics()
        {
            return new List<Clinic>()
            {
                new Clinic() { Id = 1, Name = "Kathiani Hospital", CountyId = 1 },
                new Clinic() { Id = 2, Name = "Kenyatta National Hospital", CountyId = 2 },
                new Clinic() { Id = 3, Name = "Machakos Level 5 Hospital", CountyId = 1 },
                new Clinic() { Id = 4, Name = "Nairobi Hospital", CountyId = 2 },
            };
        }

        static IEnumerable<Doctor> GetPreConfiguredDoctors()
        {
            return new List<Doctor>()
            {
                new Doctor() { Id = 1, FirstName = "Amoth", MiddleName = "Otieno", LastName = "Ouma", SpecialityId = 1 },
                new Doctor() { Id = 2, FirstName = "James", MiddleName = "Kelly", LastName = "Kamula", SpecialityId = 2 },
                new Doctor() { Id = 3, FirstName = "John", MiddleName = "Mutunga", LastName = "Sila", SpecialityId = 2 },
                new Doctor() { Id = 4, FirstName = "Kennedy", MiddleName = "Wambua", LastName = "Sila", SpecialityId = 1 },
                new Doctor() { Id = 5, FirstName = "Mercy", MiddleName = "Mutanu", LastName = "Munyao", SpecialityId = 1 },
                new Doctor() { Id = 6, FirstName = "Lydia", MiddleName = "Wayua", LastName = "Musyoki", SpecialityId = 3 },
                new Doctor() { Id = 7, FirstName = "Timothy", MiddleName = "Mwendwa", LastName = "Munyao", SpecialityId = 3 }
            };
        }

        static IEnumerable<ClinicAssignment> GetPreConfiguredClinicAssignments()
        {
            return new List<ClinicAssignment>()
            {
                new ClinicAssignment() { ClinicId= 1, DoctorId=1 },
                new ClinicAssignment() { ClinicId= 1, DoctorId=2},
                new ClinicAssignment() { ClinicId= 1, DoctorId=5},
                new ClinicAssignment() { ClinicId= 3, DoctorId=6},
                new ClinicAssignment() { ClinicId= 3, DoctorId=7},
                new ClinicAssignment() { ClinicId= 2, DoctorId=3},
                new ClinicAssignment() { ClinicId= 4, DoctorId=4}
            };
        }
        static IEnumerable<Patient> GetPreConfiguredPatients()
        {
            return new List<Patient>()
            {
                new Patient() { Id = 1, UserId = 1, FirstName = "Admin", LastName = "Odoctor" }
            };
        }
        static IEnumerable<Service> GetPreConfiguredServices()
        {
            return new List<Service>()
            {
                new Service() { Id = 1, Name = "Consultation", Duration = 10, Price = 200, Access = Access.Public },
                new Service() { Id = 2, Name = "Wound dressing", Duration = 30, Price = 1000, Access = Access.Public }
            };
        }
        static IEnumerable<Calendar> GetPreConfiguredCalendars()
        {
            return new List<Calendar>()
            {
                new Calendar() { Id = 1, DoctorId = 1 , ClinicId = 1},
                new Calendar() { Id = 2, DoctorId = 4 , ClinicId = 1 }
            };
        }
        static IEnumerable<CalendarServiceAssignment> GetPreConfiguredCalendarServiceAssignments()
        {
            return new List<CalendarServiceAssignment>()
            {
                new CalendarServiceAssignment() { CalendarId = 1 , ServiceId = 1 },
                new CalendarServiceAssignment() { CalendarId = 2 , ServiceId = 2 }
            };
        }
        static IEnumerable<Timeslot> GetPreConfiguredTimeslots()
        {
            return new List<Timeslot>()
            {
                new Timeslot() { Id = 1,  CalendarId = 1, Date = DateTime.Now.Date, Status = TimeslotStatus.Available, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(4) },
                new Timeslot() { Id = 2,  CalendarId = 2, Date = DateTime.Now.Date, Status = TimeslotStatus.Available, StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(2) }
            };
        }
    }
}