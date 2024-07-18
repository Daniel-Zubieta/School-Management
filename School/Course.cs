using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    class Course
    {
        internal int courseId;
        internal string courseName;
        internal int credits;
        internal Teacher Instructor;
        internal List<Student> CourseStudents = new List<Student>();
        internal string schedule;
        internal string description;
        internal string status;
        internal int approvalScore;
        internal double minGPA;

        public Course(int courseIdAux, string courseNameAux, int creditsAux, Teacher InstructorAux, string scheduleAux, string descriptionAux, string statusAux, int approvalScoreAux, double minGPAAux)
        {
            this.courseId = courseIdAux;
            this.courseName = courseNameAux;
            this.credits = creditsAux;
            this.Instructor = InstructorAux;
            this.schedule = scheduleAux;
            this.description = descriptionAux;
            this.status = statusAux;
            this.approvalScore = approvalScoreAux;
            this.minGPA = minGPAAux;
        }
        private int generateId()
        {
            Random random = new Random();
            int fourDigitNumber = random.Next(1000, 10000);
            Console.WriteLine(fourDigitNumber);
            return fourDigitNumber;
        }
    }
}
