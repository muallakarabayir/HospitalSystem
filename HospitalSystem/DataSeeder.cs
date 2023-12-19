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
            

            context.Policlinics.Add(new Policlinic
            {
                Id=1,
                Name="KBB",
                
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
