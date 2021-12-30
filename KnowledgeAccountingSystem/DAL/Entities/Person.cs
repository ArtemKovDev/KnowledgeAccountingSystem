using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Person : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PlaceOfWork { get; set; }

        public string Education { get; set; }

        public ICollection<PersonSkill> Skills { get; set; }       
    }
}
