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
            AddPoliclinics(context);
        
        }
        private static void AddPoliclinics(HospitalDataContext context)
        {
            var policlinic = context.Policlinics.FirstOrDefault();
            if (policlinic != null)return;

            System.Diagnostics.Debug.WriteLine("defe");
            context.Policlinics.Add(new Policlinic
            {
                Id=1,
                Name="KBB",
                Doctors = {
                    new Doctor { 
                        Id = 1,
                        Name="Gökhan",
                        Surname="Dönmez",
                        
                    },
                    new Doctor{ 
                        Id = 2,
                        Name="Merve",
                        Surname="Develi"

                    }
                
                }
                
            });
            context.Policlinics.Add(new Policlinic
            {
                Id = 2,
                Name = "PDA"
            });
            context.SaveChanges();

        }
       


    }
}
