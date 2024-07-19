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
        internal string studentLastName;        
        internal string address;
        internal string phoneNumber;        
        internal string Major;
        internal double gradePointAvg;
        internal int creditsEarned;
        internal DateTime dateOfbirth;
        internal DateTime enrollmentDate;


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

        public Student(int iD, string studentFirstNameAux, string studentLastNameAux, string addressAux, string phoneNumberAux, string MajorAux, DateTime dateOfbirthAux, DateTime enrollmentDateAux)
        {
            this.studentID = iD;
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
        internal void PrintData()
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
        static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("***School Management System***" + Environment.NewLine);
        }
    }
   
}
