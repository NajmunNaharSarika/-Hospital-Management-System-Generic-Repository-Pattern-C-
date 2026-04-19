using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsProject.Models
{
    internal class Patient:BcPerson
    {
        public int DoctorId { get; set; }
        public int Age { get; set; }
        public string Disease { get; set; }
    }
}
