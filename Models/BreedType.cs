using System;
using System.Collections.Generic;

namespace WebAPI_Test.Models
{
    public class BreedType
    {
        public int IdBreedType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Pet> Pets { get; set; }

    }
}
