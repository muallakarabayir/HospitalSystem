using HospitalData;
using System.Linq;

namespace HospitalSystem
{
    public static class DataSeeder
    {
        public static void Seed(this IHost host)
        {
            using var scope=host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<HospitalDataContext>();
            context.Database.EnsureCreated();
            
        }
       /* private static void AddBranchs(HospitalDataContext context)
        {
            var branch = context.Branches.FirstOrDefault();
            if(branch != null )
            {
                return;
            }
            context.Branches.Add( new Branch
            {
                Id=1,
                Name= "Gediatric",
                Doctors = new List< Doctor> 
                { 
                   new Doctor {Name="Gökhan"},
                   new Doctor{Name="Merve"}
                }


            });
            context.Branches.Add(new Branch
            {
                Id = 2,
                Name = "General Surgery",
                Doctors = new List<Doctor>
                {
                   new Doctor {Name="Gökhan"},
                   new Doctor{Name="Merve"}
                }


            });


            context.SaveChanges();
        }*/
    }
}
