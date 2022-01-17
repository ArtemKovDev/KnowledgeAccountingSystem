using System.Collections.Generic;

namespace PL.ViewModels.Account
{
    public class ResponseModel
    {
        public bool IsSuccessful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
