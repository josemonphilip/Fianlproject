using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using rc.Domain;

namespace rc.DAL
{
    public class rcContext : BaseContext<rcContext>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StaffProfile> StaffProfiles { get; set; }

        public DbSet<GeneralPractitioner> GeneralPractitioners { get; set; }
        public DbSet<Ward> Wards { get; set; }
        public DbSet<PatientAdmission> PatientAdmissions { get; set; }
        public DbSet<PatientDailyDiary> PatientDailyDiary { get; set; }
        public DbSet<CarePlan> CarePlans { get; set; }

        public DbSet<PatientVitalSign> PatientVitalSigns { get; set; }

        public DbSet<AssesmentQuestion> AssesmentQuestions { get; set; }
        public DbSet<AssesmentAnswer> AssesmetnAnswers { get; set; }

        public void Commit()
        {
            base.SaveChanges();
        }
    }
}
