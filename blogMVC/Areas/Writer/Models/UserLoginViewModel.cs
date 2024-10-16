using System.ComponentModel.DataAnnotations;

namespace blogMVC.Areas.Writer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adını giriniz")]
        public string Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre giriniz")]
        public string Password { get; set; }
    }
}
