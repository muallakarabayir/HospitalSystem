using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalData
{
    public class HospitalDataContext :DbContext
    {
        public HospitalDataContext(DbContextOptions<HospitalDataContext>options) : 
            base(options) 
        { 
        
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment>Appointments { get; set; }
        public DbSet<Policlinic> Policlinics { get; set;}
        public DbSet<Branch> Branches { get; set; }
    }
}
