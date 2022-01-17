using System.ComponentModel.DataAnnotations;

namespace BLL.Models.Account
{
    public class UserModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string PlaceOfWork { get; set; }

        [Required]
        public string Education { get; set; }
    }
}
