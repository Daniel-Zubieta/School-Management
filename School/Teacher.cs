using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    public class Teacher
    {
        internal int teacherID;
        internal string teacherFirstName;
        internal string teacherLastName;
        internal string address;
        internal string phoneNumber;
        internal string deparment;
        internal string specialiation;
        internal double salary;
        internal DateTime dateOfbirth;
        internal DateTime hireDate;
        //Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, deparment, specialiation, salary, dateOfbirth, hireDate);

        public Teacher(string teacherFirstNameAux, string teacherLastNameAux, string addressAux, string phoneNumberAux, string deparmentAux, string specialiationAux,double salaryAux, DateTime dateOfbirthAux, DateTime hireDateAux)
        {
            this.teacherFirstName = teacherFirstNameAux;
            this.teacherLastName = teacherLastNameAux;
            this.address = addressAux;
            this.phoneNumber = phoneNumberAux;
            this.deparment = deparmentAux;
            this.specialiation = specialiationAux;
            this.salary = salaryAux;
            this.dateOfbirth = dateOfbirthAux;
            this.hireDate = hireDateAux;
            this.salary = salaryAux;
        }

        public Teacher(int iDAux, string teacherFirstNameAux, string teacherLastNameAux, string addressAux, string phoneNumberAux, string deparmentAux, string specialiationAux, double salaryAux, DateTime dateOfbirthAux, DateTime hireDateAux)
        {
            this.teacherID = iDAux;
            this.teacherFirstName = teacherFirstNameAux;
            this.teacherLastName = teacherLastNameAux;
            this.address = addressAux;
            this.phoneNumber = phoneNumberAux;
            this.deparment = deparmentAux;
            this.specialiation = specialiationAux;
            this.salary = salaryAux;
            this.dateOfbirth = dateOfbirthAux;
            this.hireDate = hireDateAux;
            this.salary = salaryAux;
        }
        internal void PrintTeacherData()
        {
            //printHeader();
            Console.WriteLine("*********Teacher Information*********" + Environment.NewLine);
            Console.WriteLine("Teacher ID:     " + this.teacherID);
            Console.WriteLine("First Name:     " + this.teacherFirstName);
            Console.WriteLine("Last Name:      " + this.teacherLastName);
            Console.WriteLine("Address:        " + this.address);
            Console.WriteLine("Phone #:        " + this.phoneNumber);
            Console.WriteLine("Deparment:      " + this.deparment);
            Console.WriteLine("Specialization: " + this.specialiation);
            Console.WriteLine("Salary:         " + this.salary);
            Console.WriteLine("Birth Date::    " + this.dateOfbirth);
            Console.WriteLine("Hire Date:      " + this.hireDate);
            Console.WriteLine("*************************************" + Environment.NewLine);
            //Console.WriteLine("" + Environment.NewLine);
        }
    }
}
