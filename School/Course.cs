using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Course
    {
        internal int courseId;
        internal string courseName;
        internal int credits;
        internal Teacher Instructor;
        internal List<Student> ListOfStudents = new List<Student>();
        internal string schedule;
        internal string description;
        internal string status;
        internal int approvalScore;
        internal double minGPA;
        internal bool haveInstructor = false;  

        public Course(int courseIdAux, string courseNameAux, int creditsAux, Teacher InstructorAux, string scheduleAux, string descriptionAux, string statusAux, int approvalScoreAux, double minGPAAux)
        {
            this.courseId = courseIdAux;
            this.courseName = courseNameAux;
            this.credits = creditsAux;
            this.Instructor = InstructorAux;
            this.haveInstructor = true;
            this.schedule = scheduleAux;
            this.description = descriptionAux;
            this.status = statusAux;
            this.approvalScore = approvalScoreAux;
            this.minGPA = minGPAAux;
        }
        //printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
        public Course(string courseNameAux, int creditsAux, string scheduleAux, string descriptionAux, string statusAux, int approvalScoreAux, double minGPAAux)
        {
            this.courseId = generateId();
            this.courseName = courseNameAux;
            this.credits = creditsAux;
            this.Instructor = null;
            this.schedule = scheduleAux;
            this.description = descriptionAux;
            this.status = statusAux;
            this.approvalScore = approvalScoreAux;
            this.minGPA = minGPAAux;
        }
        private int generateId()
        {
            Random random = new Random();
            int idCourse = random.Next(1000, 10000);
            //Console.WriteLine(idCourse);
            return idCourse;
        }
        internal void PrintCourseData()
        {
            //printHeader();
            Console.WriteLine("*********Course Data*********" + Environment.NewLine);
            Console.WriteLine("Course ID:     " + this.courseId);
            Console.WriteLine("Course Name:   " + this.courseName);
            Console.WriteLine("Course Credits:" + this.credits);
            Console.WriteLine("Instructor:    " + this.Instructor);
            Console.WriteLine("Schedule:      " + this.schedule);
            Console.WriteLine("Description:   " + this.description);
            Console.WriteLine("Status:        " + this.status);
            Console.WriteLine("Approval Score:" + this.approvalScore);
            Console.WriteLine("Minimum GPA:   " + this.minGPA);
            Console.WriteLine("******************************" + Environment.NewLine);
            //Console.WriteLine("" + Environment.NewLine);
        }

        internal void enrollStudent(Student studentFound)
        {
            this.ListOfStudents.Add(studentFound);
        }

        internal void printStudents()
        {
            foreach (Student studentAux in this.ListOfStudents)
            {
                studentAux.PrintStudentData();         
            }
        }

        internal void printStudentGrade()
        {
            foreach (Student studentAux in this.ListOfStudents)
            {
                studentAux.PrintStudentData();
            }
        }

        internal void printStudentsGrades()
        {
            foreach (Student studentAux in this.ListOfStudents)
            {

                studentAux.PrintStudentGrade(this.courseId);
            }
            Console.WriteLine("Press Any key to continue...");
            Console.ReadKey();
        }

        internal void printApprovedStudentsGrades()
        {
            Console.WriteLine("<List Of 'Students' Approved>" + Environment.NewLine);
            foreach (Student studentAux in this.ListOfStudents)
            {
                studentAux.PrintStudentGradeIfApproved(this.courseId);
            }
            Console.WriteLine("Press Any key to continue...");
            Console.ReadKey();
        }

        internal void printFailedStudentsGrades()
        {
            Console.WriteLine("<List Of 'Students' Approved>" + Environment.NewLine);
            foreach (Student studentAux in this.ListOfStudents)
            {
                studentAux.PrintStudentGradeIfFailed(this.courseId);
            }
            Console.WriteLine("Press Any key to continue...");
            Console.ReadKey();
        }
        internal bool instructorStatus()
        {
            if (haveInstructor) { return true; }
            else { return false; }
        }
        internal void setTrueInstructorStatus()
        {
            haveInstructor = true;
        }
    }
}
