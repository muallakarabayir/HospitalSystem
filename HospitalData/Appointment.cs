using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HospitalData
{
    public class Appointment
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public User User { get; set; }
        [Required]
        public Doctor Doctor { get; set; }
    }
    public class Doctor
    {
        [Required]
        [Key]
        public int Id {  get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        public Branch Branch { get; set; }
        public ICollection<Appointment> Appointments { get; set; }

        
    }
    public class User
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public int IdentityNo { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }
        [Required]
        [Display(Name = "Mail")]
        public string Email { get; set; }
        [Required]
        [MaxLength(11)]
        [Display(Name = "Phone")]
        public int Phone { get; set; }
        [Display(Name="Password")]
        public int Password { get; set; }
        public ICollection<Appointment> Appointments { get; set; }



    }
    public class Policlinic
    {
        [Required]
        [Key]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
        public ICollection <User> Users { get; set; }
    }   

    public class Branch
    {
        [Required]
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Doctor> Doctors { get; set; }
    }
    
    
}
