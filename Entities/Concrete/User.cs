using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "E-Posta alanı gereklidir. ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı gereklidir."), DataType(DataType.Password, ErrorMessage = "Şifre düzgün formatta değil.")]
        public string Password { get; set; }

        [NotMapped, Compare("Password", ErrorMessage = "Şifreler eşleşmiyor."), DataType(DataType.Password, ErrorMessage = "Şifre düzgün formatta değil.")]
        public string PasswordRepeat { get; set; }

        [Required(ErrorMessage = "İsim alanı gereklidir.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyisim alanı gereklidir.")]
        public string LastName { get; set; }   

        [Required(ErrorMessage = "Rol alanı gereklidir.")]
        public byte RoleId { get; set; }

        public Role Role { get; set; }

    }
}
