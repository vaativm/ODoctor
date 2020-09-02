namespace ODoctor.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using ODoctor.Core.Entities;
    using ODoctor.Core.Entities.CalendarAggregate;
    using ODoctor.Core.Entities.ClinicAggregate;
    using ODoctor.Core.Entities.DoctorAggregate;

    public class ODoctorDbContext : DbContext
    {
        public ODoctorDbContext(DbContextOptions<ODoctorDbContext> options) :
            base(options)
        {

        }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorAssignment> ClinicAssignments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CalendarServiceAssignment> CalendarServiceAssignments { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorAssignment>()
                .HasKey(c => new { c.ClinicId, c.DoctorId });

            modelBuilder.Entity<CalendarServiceAssignment>()
                .HasKey(c => new { c.CalendarId, c.ServiceId });

            modelBuilder.Entity<Calendar>(ConfigureCalendar);
        }

        private void ConfigureClinic(EntityTypeBuilder<Clinic> builder)
        {
            var doctorsNavigation = builder.Metadata.FindNavigation(nameof(Clinic.Doctors));
            var servicesNavigation = builder.Metadata.FindNavigation(nameof(Clinic.Services));

            doctorsNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            servicesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(c => c.Address);
            builder.OwnsOne(c => c.Contact);
        }

        private void ConfigureDoctor(EntityTypeBuilder<Doctor> builder)
        {
            var calendarNavigation = builder.Metadata.FindNavigation(nameof(Doctor.Calendar));

            calendarNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(d => d.Contact);
        }
        private void ConfigureCalendar(EntityTypeBuilder<Calendar> builder)
        {
            var timeslotNavigation = builder.Metadata.FindNavigation(nameof(Calendar.Timeslots));
            var servicesNavigation = builder.Metadata.FindNavigation(nameof(Calendar.Services));

            timeslotNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
            servicesNavigation.SetPropertyAccessMode(PropertyAccessMode.Field);
        }

    }

    public class ODoctorDbContextFactory: IDesignTimeDbContextFactory<ODoctorDbContext>
    {
        public ODoctorDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ODoctorDbContext>();
            optionsBuilder.UseSqlServer("Server=VINCENT-PC\\SQLEXPRESS;Database=ODoctorDb;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new ODoctorDbContext(optionsBuilder.Options);
        }
    }
}
