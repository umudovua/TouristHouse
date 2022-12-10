using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristHouse.Application.Dtos.User
{
    public class CreateUser
    {
        [Required, StringLength(20)]
        public string? Name { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required, DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }

        [Required, DataType(DataType.Password)]
        public string? Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string? PasswordConfirm { get; set; }
    }
}
