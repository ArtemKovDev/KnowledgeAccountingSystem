using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels.Account
{
    public class DeleteUserModel
    {
        [Required, MinLength(5), MaxLength(20)]
        public string Email { get; set; }
    }
}
