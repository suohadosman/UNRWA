using IUNRWA_Model;
using IUNRWA_Model.Entity;
using IUNRWA_Model.UNRWAUsers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IUNRWA_Repository
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        #region Users
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Clerick> Clericks { get; set; }
        public DbSet<NCDNurse> NCDNurses { get; set; }
        public DbSet<Pharmacist> Pharmacists { get; set; }
        public DbSet<Tester> Testers { get; set; }
        public DbSet<MeasurementNurse> MeasurementNurses { get; set; }

        #endregion

        #region Entities
        public DbSet<Area> Areas { get; set; }
        public DbSet<ChildCard> ChildCards { get; set; }
        public DbSet<ChildCardMeasurementResult> ChildCardMeasurementResults { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Dose> Doses { get; set; }

        public DbSet<FamilyRegestrationCard> FamilyRegestrationCards { get; set; }
        public DbSet<FollwUpVisit> FollwUpVisits { get; set; }

        public DbSet<HealthCenter> HealthCenters { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<IllnessType> IllnessTypes { get; set; }
        public DbSet<ImmunizationDate> ImmunizationDates { get; set; }
        public DbSet<ImmunizationDateSideEffect> ImmunizationDateSideEffects { get; set; }
        public DbSet<ImmunizationProgramme> ImmunizationProgrammes { get; set; }
        public DbSet<LabTest> LabTests { get; set; }
        public DbSet<LabTestType> labTestTypes { get; set; }
        public DbSet<LateComplication> LateComplications { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineType> MedicineTypes { get; set; }
        public DbSet<MedicinPreview> MedicinPreviews { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<NCDCard> NCDCards { get; set; }
        public DbSet<FollowUpLateComplication> FollowUpLateComplication { get; set; }

        public DbSet<OriginPlace> OriginPlaces { get; set; }
        public DbSet<person> People { get; set; }
        public DbSet<PersonMeasurementResult> PersonMeasurementResults { get; set; }
        public DbSet<Preview> Previews { get; set; }
        public DbSet<PreviewComplaint> PreviewComplaints { get; set; }
        public DbSet<PreviewIllness> PreviewIllnesses { get; set; }

        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<AreaPlace> AreaPlaces { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SideEffect> SideEffects { get; set; }

        public DbSet<StudyLevel> StudyLevels { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TheMeasurement> TheMeasurements { get; set; }
        public DbSet<TimeSlote> TimeSlotes { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }
        public DbSet<PreviewLabTest> PreviewLabTests { get; set; }
        public DbSet<FollowUpLabTest> followUpLabTests { get; set; }

        #endregion
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<person>().HasOne(e => e.Doctor).WithOne(e => e.Person).HasForeignKey<Doctor>(e => e.PersonId);
            modelBuilder.Entity<person>().HasOne(e => e.Clerick).WithOne(e => e.Person).HasForeignKey<Clerick>(e => e.PersonId);
            modelBuilder.Entity<person>().HasOne(e => e.CildCard).WithOne(e => e.Person).HasForeignKey<ChildCard>(e => e.PersonId);
            modelBuilder.Entity<person>().HasOne(e => e.NCDCard).WithOne(e => e.Person).HasForeignKey<NCDCard>(e => e.PersonId);

            #region Navigation
            modelBuilder.Entity<AreaPlace>().Navigation(e => e.Area).AutoInclude();

            modelBuilder.Entity<person>().Navigation(e => e.FamilyCard).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.Nationality).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.Relationship).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.OriginAdress).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.CurrentAddress).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.StudyLevel).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.NCDCard).AutoInclude();
            modelBuilder.Entity<person>().Navigation(e => e.CildCard).AutoInclude();
            //modelBuilder.Entity<person>().Navigation(e => e.Children).AutoInclude(); // to test
            //modelBuilder.Entity<person>().Navigation(e => e.Father).AutoInclude(); // to test

            modelBuilder.Entity<FamilyRegestrationCard>().Navigation(e => e.People).AutoInclude(); // to test

            modelBuilder.Entity<HealthCenter>().Navigation(e => e.AreaPlace).AutoInclude();


            #endregion
            base.OnModelCreating(modelBuilder);

        }
    }
}