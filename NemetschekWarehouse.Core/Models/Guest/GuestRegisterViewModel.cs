using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NemetschekWarehouse.Core.Models.Guest
{
    public class GuestRegisterViewModel
    {
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(PasswordConfirmation))]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; } =  string.Empty;

        [Required] 
        public string FirstName { get; set; } = string.Empty;

        [Required] 
        public string LastName { get; set; } = string.Empty;
    }
}
