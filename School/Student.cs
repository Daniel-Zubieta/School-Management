using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Student
    {
        internal int studentID;
        internal string studentFirstName { get; set; }
        internal string studentLastName { get; set; }
        internal string address { get; set; }
        internal string phoneNumber { get; set; }
        internal string Major { get; set; }
        internal double gradePointAvg { get; set; }
        internal int creditsEarned { get; set; }
        internal DateTime dateOfbirth { get; set; }
        internal DateTime enrollmentDate { get; set; }

        internal List<Grade> ListOfGrades = new List<Grade>();


        public Student(string studentFirstNameAux, string studentLastNameAux, string addressAux, string phoneNumberAux, string MajorAux, DateTime dateOfbirthAux, DateTime enrollmentDateAux)
        {
            this.studentFirstName = studentFirstNameAux; 
            this.studentLastName = studentLastNameAux;
            this.address = addressAux;
            this.phoneNumber = phoneNumberAux;
            this.Major = MajorAux;
            this.dateOfbirth = dateOfbirthAux;
            this.enrollmentDate = enrollmentDateAux;
            this.gradePointAvg = 0;
            this.creditsEarned = 0;
        }

        public Student(int iD, string studentFirstNameAux, string studentLastNameAux, string addressAux, string phoneNumberAux, string MajorAux, DateTime dateOfbirthAux, DateTime enrollmentDateAux, double gradePointAvgAux, int creditsEarnedAux)
        {
            this.studentID = iD;
            this.studentFirstName = studentFirstNameAux;
            this.studentLastName = studentLastNameAux;
            this.address = addressAux;
            this.phoneNumber = phoneNumberAux;
            this.Major = MajorAux;
            this.dateOfbirth = dateOfbirthAux;
            this.enrollmentDate = enrollmentDateAux;
            this.gradePointAvg = gradePointAvgAux;
            this.creditsEarned = creditsEarnedAux;
        }
        internal void PrintStudentData()
        {
            //printHeader();
            Console.WriteLine("*********Student Data*********" + Environment.NewLine);
            Console.WriteLine("Student ID:  " + this.studentID);
            Console.WriteLine("First Name:  " + this.studentFirstName);
            Console.WriteLine("Last Name:   " + this.studentLastName);
            Console.WriteLine("Address:     " + this.address);
            Console.WriteLine("Phone #:     " + this.phoneNumber);
            Console.WriteLine("Birth Date:  " + this.dateOfbirth);
            Console.WriteLine("Enroll Date: " + this.enrollmentDate);
            Console.WriteLine("Major:       " + this.Major);
            Console.WriteLine("Grades Avg:  " + this.gradePointAvg);
            Console.WriteLine("Credits:     " + this.creditsEarned);
            Console.WriteLine("******************************" + Environment.NewLine);
            //Console.WriteLine("" + Environment.NewLine);
        }
        internal void PrintStudentBasicData()
        {
            //printHeader();
            Console.WriteLine("*********Student Data*********" + Environment.NewLine);
            Console.WriteLine("Student ID:  " + this.studentID);
            Console.WriteLine("First Name:  " + this.studentFirstName);
            Console.WriteLine("Last Name:   " + this.studentLastName);
            //Console.WriteLine("" + Environment.NewLine);
        }
        static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("***School Management System***" + Environment.NewLine);
        }
        static void earnCredits()
        {
            printHeader();
            Console.WriteLine("Please enter the 'Student ID' That you want to Earn Credits" + Environment.NewLine);

        }

        internal void addGrade(Grade gradeAux)
        {
            this.ListOfGrades.Add(gradeAux);
        }

        internal void PrintStudentGrade(int courseId)
        {
            
            foreach (Grade gradeAux in this.ListOfGrades)
            {
                if (gradeAux.course.courseId == courseId)
                {
                    gradeAux.printGrade();
                }
                
            }
        }
        internal void PrintStudentGradeIfApproved(int courseId)
        {

            foreach (Grade gradeAux in this.ListOfGrades)
            {
                if (gradeAux.course.courseId == courseId)
                {
                    if (gradeAux.score >= gradeAux.course.approvalScore)
                    {
                        gradeAux.printGrade();
                    }
                    
                }

            }
        }
        internal void PrintStudentGradeIfFailed(int courseId)
        {

            foreach (Grade gradeAux in this.ListOfGrades)
            {
                if (gradeAux.course.courseId == courseId)
                {
                    if (gradeAux.score < gradeAux.course.approvalScore)
                    {
                        gradeAux.printGrade();
                    }

                }

            }
        }

    }
   
}
