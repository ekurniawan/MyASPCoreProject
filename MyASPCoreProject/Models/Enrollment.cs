using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPCoreProject.Models
{
    public enum Grade
    {
        A,B,C,D,E,F
    }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int MyStudentID { get; set; }
        public Grade? Grade { get; set; }
        public Course Course { get; set; }
        public MyStudent MyStudent { get; set; }
    }
}
