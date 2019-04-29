using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRegistrationMVCProject.Models
{
    public class StudentViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public string Course { get; set; }
        public string TeacherName { get; set; }
        public string Email { get; set; }
    }
}