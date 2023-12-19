using System.ComponentModel.DataAnnotations;

public class LoginViewModel
{
    [Required(ErrorMessage = "Identity Number is required")]
    [Display(Name = "Identity Number")]
    public string IdentityNo { get; set; }

    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}