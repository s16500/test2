using System;

namespace WebAPI_Test.Models
{
    public class VolunteerPet
    {
        public int IdVolunteer { get; set; }
        public int IdPet { get; set; }
        public DateTime DateAccepted { get; set; }
        public virtual Pet Pet { get; set; }
        public virtual Volunterr Volunterr { get; set; }

    }
}
