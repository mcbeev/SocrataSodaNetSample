using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebApplication.Models
{
    public class Student
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime EnrolledOn { get; set; }
    }
}
