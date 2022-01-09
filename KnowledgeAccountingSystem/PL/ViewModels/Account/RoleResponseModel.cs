using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL.ViewModels.Account
{
    public class RoleResponseModel
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
