using System;
using System.Collections.Generic;

namespace WebAPI_Test.Models
{
    public class Pet
    {
        public int IdPet { get; set; }
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public short IsMale { get; set; }
        public DateTime DateRegistered { get; set; }
        public DateTime ApprocimateDateOfBirth { get; set; }
        public DateTime DateAdopted { get; set; }

        public BreedType BreedType { get; set; }

        public virtual ICollection<VolunteerPet> VolunteerPets { get; set; }

    }

}
