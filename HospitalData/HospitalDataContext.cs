using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


using Microsoft.Build.Tasks;



namespace HospitalData
{
    public class HospitalDataContext :IdentityDbContext<User>
    {
        public HospitalDataContext(DbContextOptions<HospitalDataContext>options) : 
            base(options) 
        { 
        
        
        }
        public DbSet<ApplicationUser>ApplicationUsers{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            modelBuilder.UseSerialColumns();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<string>>()
                .HasKey(login => new { login.LoginProvider, login.ProviderKey });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment>Appointments { get; set; }
        public DbSet<Policlinic> Policlinics { get; set;}
        public DbSet<Branch> Branches { get; set; }
       
    }

}
