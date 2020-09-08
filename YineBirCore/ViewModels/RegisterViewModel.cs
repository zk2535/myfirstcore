using System.ComponentModel.DataAnnotations;

namespace YineBirCore.ViewModels
{
    public class RegisterViewModel
    { 
        [Required (ErrorMessage = "Lütfen mail adresinizi giriniz")]
        [DataType(DataType.EmailAddress, ErrorMessage ="Lütfen geçerli bir mail adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen bir şifre belirleyiniz")]
        [DataType(DataType.Password, ErrorMessage = "Şifreniz kriterlere uygun değil")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi tekrar giriniz")]
        [Compare("Password", ErrorMessage ="Şifreler eşleşmedi")]
        public string ConfirmPassword { get; set; }


    }
}
