using System.ComponentModel.DataAnnotations;

namespace YineBirCore.ViewModels
{
    public class LoginViewModel
    {   
        
        [Required(ErrorMessage = "Lütfen mail adresinizi giriniz")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Beni Hatırla")]
        public bool Rememberme { get; set; }


    }
}
