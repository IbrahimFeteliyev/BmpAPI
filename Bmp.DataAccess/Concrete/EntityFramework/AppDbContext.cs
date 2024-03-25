using Bmp.Core.Entity.Models;
using Bmp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Bmp.DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=IT-WEB2\SQLEXPRESS;Database=BmpAPI;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<AboutLanguage> AboutLanguages { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<AdvantageLanguage> AdvantageLanguages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Department> Departments { get; set; }

        public DbSet<DepartmentLanguage> DepartmentLanguages { get; set; }
        public DbSet<DepartmentFeature> DepartmentFeatures { get; set; }
        public DbSet<DepartmentFeatureLanguage> DepartmentFeatureLanguages { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorLanguage> DoctorLanguages { get; set; }
        public DbSet<DoctorEducation> DoctorEducations { get; set; }
        public DbSet<DoctorEducationLanguage> DoctorEducationLanguages { get; set; }
        public DbSet<DoctorWorkExperience> DoctorWorkExperiences { get; set; }
        public DbSet<DoctorWorkExperienceLanguage> DoctorWorkExperienceLanguages { get; set; }
        public DbSet<HospitalBranch> HospitalBranchs { get; set; }
        public DbSet<HospitalBranchLanguage> HospitalBranchLanguages { get; set; }
        public DbSet<HospitalBranchFeature> HospitalBranchFeatures { get; set; }
        public DbSet<HospitalBranchFeatureLanguage> HospitalBranchFeatureLanguages { get; set; }
        public DbSet<HospitalBranchPhoto> HospitalBranchPhotos { get; set; }
        public DbSet<Introduction> Introductions { get; set; }
        public DbSet<IntroductionLanguage> IntroductionLanguages { get; set; }
        public DbSet<ShortInfo> ShortInfos { get; set; }
        public DbSet<ShortInfoLanguage> ShortInfoLanguages { get; set; }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedDate = DateTime.UtcNow;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
