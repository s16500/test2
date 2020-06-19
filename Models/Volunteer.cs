using System;
using System.Collections.Generic;

namespace WebAPI_Test.Models
{
    public class Volunterr
    {
        public int IdVolunterr { get; set; }
        public int IdSupervisor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Addess { get; set; }
        public string Email { get; set; }
        public DateTime StartingDate { get; set; }
        public ICollection<VolunteerPet> VolunteerPets { get; set; }

    }
}