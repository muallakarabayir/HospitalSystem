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
            AddBranchs(context);
        }
        private static void AddBranchs(HospitalDataContext context)
        {
            var branch= context.Branches.FirstOrDefault();
            if (branch != null) return;
            
          
          
     
            context.SaveChanges();
        }
    }
}
