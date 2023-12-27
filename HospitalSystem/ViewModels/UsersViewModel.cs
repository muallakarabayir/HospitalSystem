using Microsoft.AspNetCore.Identity;
namespace HospitalSystem.ViewModels
{
    public class UsersViewModel:IdentityUser
    {
        public const string WebSite_Admin = "Admin";
        public const string WebSite_Patient = "Patient";
        public const string WebSite_Doctor = "Doctor";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Phone {  get; set; }
        public int IdentityNo {  get; set; }
        
    }
}
