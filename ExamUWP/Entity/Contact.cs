using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamUWP.Entity
{
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public override string ToString()
        {
            return string.Format($"Name:{Name} --- Phone:{PhoneNumber}");
        }

    }
}
