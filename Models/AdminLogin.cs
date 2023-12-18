using System.ComponentModel.DataAnnotations;

namespace webProjeOdev8.Models
{
    public class AdminLogin
    {

        [Required(ErrorMessage = "Kullanici adiniz hatali")]
        [EmailAddress(ErrorMessage = "Gecerli bir e-mail adresi giriniz")]
        public string KullaniciAdi { get; set; }

        public string? Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }

        [Required(ErrorMessage = "Sifreniz hatali")]
        public string Sifre { get; set; }

        public string Role { get; set; } = "admin";
    }
}

