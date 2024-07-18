using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using School.Utils;



namespace School.Utils
{
    public class Utils
    {

        static public void PrintMenuStudent()
        {
            printHeader();
            Console.WriteLine("------------------------");
            Console.WriteLine("(1) Add Student");
            Console.WriteLine("(2) Earn Credits");
            Console.WriteLine("(3) View Student Information");
            Console.WriteLine("(4) Exit");
            Console.WriteLine("------------------------");
        }
        static public void PrintMenuTeacher()
        {
            printHeader();
            Console.WriteLine("------------------------");
            Console.WriteLine("(1) Add Teacher");
            Console.WriteLine("(2) View Teacher Information");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("------------------------");
        }
        static public void PrintMenuCourses()
        {
            printHeader();
            Console.WriteLine("------------------------");
            Console.WriteLine("(1) Create Course");
            Console.WriteLine("(2) Enroll Student in a Course");
            Console.WriteLine("(3) Assign Teacher to Course");
            Console.WriteLine("(2) View Course Information");
            Console.WriteLine("(3) Exit");
            Console.WriteLine("------------------------");
        }
        public static void addStudent() 
        {
            int studentID = 0;
            string studentFirstName = string.Empty;
            string studentLastName = string.Empty;
            string address = string.Empty;
            string phoneNumber = string.Empty;
            string dateOfbirthAux = string.Empty;
            bool dateOfbirthFlag=false;
            string enrollmentDateAux = string.Empty;
            bool enrollmentDateFlag = false;
            string major = string.Empty;
            DateTime dateOfbirth;
            DateTime enrollmentDate;
            
            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student First Name:");
            studentFirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(studentFirstName))
            {
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Name is Empty or Invalid");
                Console.WriteLine("Please Enter the Student First Name:");
                studentFirstName = Console.ReadLine();
            }

            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student Last Name:");
            studentLastName = Console.ReadLine();
            while (string.IsNullOrEmpty(studentLastName))
            {
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Name is Empty or Invalid");
                Console.WriteLine("Please Enter the Student Last Name:");
                studentLastName = Console.ReadLine();
            }

            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student Address:");
            address = Console.ReadLine();
            while (string.IsNullOrEmpty(address))
            {
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Address is Empty or Invalid");
                Console.WriteLine("Please Enter the Student Address");
                address = Console.ReadLine();
            }

            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student Phone Number:");
            phoneNumber = Console.ReadLine();
            if (!isInt(phoneNumber)) 
            {
                phoneNumber = string.Empty;
            }
            while (string.IsNullOrEmpty(phoneNumber))
            {
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Phone Number is Empty or Invalid");
                Console.WriteLine("Please Enter the Student Phone Number");
                phoneNumber = Console.ReadLine();
                if (!isInt(phoneNumber))
                {
                    phoneNumber = string.Empty;
                }
            }

            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student Date Of Birth in the following Format e.g. mm/dd/yy");
            dateOfbirthAux = Console.ReadLine();
            dateOfbirthFlag = IsValidDateTime(dateOfbirthAux);
            while (!dateOfbirthFlag)
            {
                dateOfbirthAux = string.Empty;
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Date of Birth is Empty or Invalid");
                Console.WriteLine("Please Enter the Student Date Of Birth in the following Format e.g. mm/dd/yy");
                dateOfbirthAux = Console.ReadLine();
                dateOfbirthFlag = IsValidDateTime(dateOfbirthAux);                
            }
            dateOfbirth = DateTime.Parse(dateOfbirthAux);
        
            printHeader();
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Console.WriteLine("Please Enter the Student Date Of Enrollment in the following Format e.g. mm/dd/yy");
            enrollmentDateAux = Console.ReadLine();
            enrollmentDateFlag = IsValidDateTime(enrollmentDateAux);
            while (!enrollmentDateFlag)
            {
                enrollmentDateAux = string.Empty;
                printHeader();
                printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
                Console.WriteLine("Date of Enrollment is Empty or Invalid");
                Console.WriteLine("Please Enter the Student Date Of Birth in the following Format e.g. mm/dd/yy");
                enrollmentDateAux = Console.ReadLine();
                enrollmentDateFlag = IsValidDateTime(enrollmentDateAux);
            }
            enrollmentDate = DateTime.Parse(enrollmentDateAux);

            Student student = new Student(studentFirstName, studentLastName,address, phoneNumber, major, dateOfbirth, enrollmentDate);

            //Student Data
            printHeader();
            Console.WriteLine("New Student was created" + Environment.NewLine);
            printStudentData(studentFirstName, studentLastName, address, phoneNumber, dateOfbirthAux, enrollmentDateAux, major);
            Thread.Sleep(1500);
            Console.WriteLine("Press Any Key to back to the Menu");
            Console.ReadLine();
        }

        public static void addTeacher()
        {
            //Department(string): Department the teacher belongs to.
            //Specialization(string): Area of specialization of the teacher.
            //Salary(decimal): Salary of the teacher.
            int teacherID = 0;
            string teacherFirstName = string.Empty;
            string teacherLastName = string.Empty;
            string teacherAddress = string.Empty;
            string phoneNumber = string.Empty;
            string dateOfbirthAux = string.Empty;
            bool dateOfbirthFlag = false;
            string hireDateAux = string.Empty;
            bool hireDateFlag = false;
            string deparment = string.Empty;
            string specialiation = string.Empty;
            string salaryAux = string.Empty;
            double salary = 0;
            DateTime dateOfbirth;
            DateTime hireDate;

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher First Name:");
            teacherFirstName = Console.ReadLine();
            while (string.IsNullOrEmpty(teacherFirstName))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Name is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher First Name:");
                teacherFirstName = Console.ReadLine();
            }

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Last Name:");
            teacherLastName = Console.ReadLine();
            while (string.IsNullOrEmpty(teacherLastName))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Name is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Last Name:");
                teacherLastName = Console.ReadLine();
            }

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Address:");
            teacherAddress = Console.ReadLine();
            while (string.IsNullOrEmpty(teacherAddress))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Please Enter the Teacher Address");
                teacherAddress = Console.ReadLine();
            }

            //Teacher Phone Number
            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Phone Number:");
            phoneNumber = Console.ReadLine();
            if (!isInt(phoneNumber))
            {
                phoneNumber = string.Empty;
            }
            while (string.IsNullOrEmpty(phoneNumber))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Phone Number is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Phone Number");
                phoneNumber = Console.ReadLine();
                if (!isInt(phoneNumber))
                {
                    phoneNumber = string.Empty;
                }
            }

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Date Of Birth in the following Format e.g. mm/dd/yy");
            dateOfbirthAux = Console.ReadLine();
            dateOfbirthFlag = IsValidDateTime(dateOfbirthAux);
            while (!dateOfbirthFlag)
            {
                dateOfbirthAux = string.Empty;
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Date of Birth is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Date Of Birth in the following Format e.g. mm/dd/yy");
                dateOfbirthAux = Console.ReadLine();
                dateOfbirthFlag = IsValidDateTime(dateOfbirthAux);
            }
            dateOfbirth = DateTime.Parse(dateOfbirthAux);
            //Teacher Hire Date
            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Date Of Hire in the following Format e.g. mm/dd/yy");
            hireDateAux = Console.ReadLine();
            hireDateFlag = IsValidDateTime(hireDateAux);
            while (!hireDateFlag)
            {
                hireDateAux = string.Empty;
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Date of Enrollment is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Date Of Hire in the following Format e.g. mm/dd/yy");
                hireDateAux = Console.ReadLine();
                hireDateFlag = IsValidDateTime(hireDateAux);
            }
            hireDate = DateTime.Parse(hireDateAux);
            //End Teacher Hire Date

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Deparment:");
            deparment = Console.ReadLine();
            while (string.IsNullOrEmpty(deparment))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Please Enter the Teacher Deparment");
                deparment = Console.ReadLine();
            }

            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Specialiation:");
            specialiation = Console.ReadLine();
            while (string.IsNullOrEmpty(specialiation))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Please Enter the Teacher Specialiation");
                specialiation = Console.ReadLine();
            }

            //Teacher Salary
            printHeader();
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Console.WriteLine("Please Enter the Teacher Salary:");
            phoneNumber = Console.ReadLine();
            if (!isDouble(salaryAux))
            {
                salaryAux = string.Empty;
            }
            while (string.IsNullOrEmpty(salaryAux))
            {
                printHeader();
                printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
                Console.WriteLine("Salary is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Salary");
                salaryAux = Console.ReadLine();
                if (!isDouble(salaryAux))
                {
                    salaryAux = string.Empty;
                }

                else
                {
                    salary = double.Parse(salaryAux);
                    if (salary < 0)
                    {
                        salaryAux = string.Empty;
                    }
                    else 
                    {
                        salary = double.Parse(salaryAux);
                    }
                }                                     
            }
            //End Salary

            Teacher teacher = new Teacher(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, deparment, specialiation, salary, dateOfbirth, hireDate);

            //Teacher Data
            printHeader();
            Console.WriteLine("New Teacher was created" + Environment.NewLine);
            printTeacherData(teacherFirstName, teacherLastName, teacherAddress, phoneNumber, dateOfbirthAux, hireDateAux, deparment, specialiation, salaryAux);
            Thread.Sleep(1500);
            Console.WriteLine("Press Enter Key to back to the Menu");
            Console.ReadLine();            
        }

        public static void createCourse()
        {
            int courseId;
            string courseName = string.Empty;
            int credits = 0;
            string creditsAux= string.Empty;
            Teacher Instructor;
            List<Student> CourseStudents = new List<Student>();
            string schedule = string.Empty;
            bool scheduleFlag = false;
            string description = string.Empty;
            string status = string.Empty;
            int approvalScore = 0;
            double minGPA = 0;

            //Course Name
            printHeader();
            printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
            Console.WriteLine("Please Enter the Course Name:");
            courseName = Console.ReadLine();
            while (string.IsNullOrEmpty(courseName))
            {
                printHeader();
                printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
                Console.WriteLine("Name is Empty or Invalid");
                Console.WriteLine("Please Enter the Course Name:");
                courseName = Console.ReadLine();
            }
            //End Course Name

            //Course Credits
            printHeader();
            printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
            Console.WriteLine("Please Enter the Course Credits:");
            creditsAux = Console.ReadLine();
            if (!isInt(creditsAux))
            {
                creditsAux = string.Empty;
            }
            while (string.IsNullOrEmpty(creditsAux))
            {
                printHeader();
                printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
                Console.WriteLine("Credits is Empty or Invalid");
                Console.WriteLine("Please Enter the Course Credits");
                creditsAux = Console.ReadLine();
                if (!isDouble(creditsAux))
                {
                    creditsAux = string.Empty;
                }

                else
                {
                    credits = int.Parse(creditsAux);
                    if (credits < 0)
                    {
                        creditsAux = string.Empty;
                    }
                    else
                    {
                        credits = int.Parse(creditsAux);
                    }
                }
            }
            //End Course Credits

            //Course Schedule
            printHeader();
            printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
            Console.WriteLine("Please Enter the Teacher Date Of Hire in the following Format e.g. mm/dd/yy");
            schedule = Console.ReadLine();
            scheduleFlag = IsValidTime(schedule);
            while (!scheduleFlag)
            {
                schedule = string.Empty;
                printHeader();
                printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
                Console.WriteLine("Date of Enrollment is Empty or Invalid");
                Console.WriteLine("Please Enter the Teacher Date Of Hire in the following Format e.g. mm/dd/yy");
                schedule = Console.ReadLine();
                scheduleFlag = IsValidDateTime(schedule);
            }
            printCourseData(courseName, credits, schedule, description, status, approvalScore, minGPA);
            schedule = Console.ReadLine();
            //hireDate = DateTime.Parse(schedule);
            //End Course Schedule
        }

        static bool IsValidDateTime(string dateInString)
        {
            DateTime temp;
            if (DateTime.TryParse(dateInString, out temp))
            {
                return true;
            }
            return false;
        }

        public static bool IsValidTime(string timeInString)
        {
            //TimeSpan timeOutput;
            //return TimeSpan.TryParse(timeInString, out timeOutput);
            DateTime dt;
            bool passed = false;
            try
            {
                dt = Convert.ToDateTime(timeInString);
                timeInString = dt.ToString("HH:mm"); //if you want 12 hour time  ToString("hh:mm")
                passed = true;
            }
            catch (Exception ex)
            {
                passed = false; 
            }
            return passed;
        }

        static bool isDouble(string doubleInString)
        {
            if (!double.TryParse(doubleInString, out _))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        static bool isInt(string intInString)
        {
            if (!double.TryParse(intInString, out _))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void printHeader() 
        {
            Console.Clear();
            Console.WriteLine("******************************");
            Console.WriteLine("***School Management System***" + Environment.NewLine);
        }
        static void printStudentData(string studentFirstName, string studentLastName, string address, string phoneNumber,string dateOfBirth, string enrollmentDate, string major)
        {
            //Console.WriteLine("******************************" + Environment.NewLine);
            //Console.WriteLine("***School Management System***" + Environment.NewLine);
            //Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine("*********Student Data*********" + Environment.NewLine);
            Console.WriteLine("First Name:  " + studentFirstName);
            Console.WriteLine("Last Name:   " + studentLastName);
            Console.WriteLine("Address:     " + address);
            Console.WriteLine("Phone #:     " + phoneNumber);
            Console.WriteLine("Birth Date:  " + dateOfBirth);
            Console.WriteLine("Enroll Date: " + enrollmentDate);
            Console.WriteLine("Major:       " + major);
            Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine("" + Environment.NewLine);
        }

        static void printTeacherData(string teacherFirstName, string teacherLastName, string teacherAddress, string phoneNumber, string dateOfBirth, string hireDate, string deparment, string specialiation, string salary)
        {
            //Console.WriteLine("******************************" + Environment.NewLine);
            //Console.WriteLine("***School Management System***" + Environment.NewLine);
            //Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine("*********Teacher Data*********" + Environment.NewLine);
            Console.WriteLine("First Name:    " + teacherFirstName);
            Console.WriteLine("Last Name:     " + teacherLastName);
            Console.WriteLine("Address:       " + teacherAddress);
            Console.WriteLine("Phone #:       " + phoneNumber);
            Console.WriteLine("Birth Date:    " + dateOfBirth);
            Console.WriteLine("Enroll Date:   " + hireDate);
            Console.WriteLine("Department     " + deparment);
            Console.WriteLine("Specialiation: " + specialiation);
            Console.WriteLine("Salary:        " + salary);
            Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine("" + Environment.NewLine);
        }

        static void printCourseData(string courseName, int credits, string schedule, string description, string status, int approvalScore, double minGPA)
        {
            Console.WriteLine("*********Course Data*********" + Environment.NewLine);
            Console.WriteLine("Course Name:    " + courseName);
            Console.WriteLine("Course Credits:     " + credits);
            Console.WriteLine("Schedule:       " + schedule);
            Console.WriteLine("Description:       " + description);
            Console.WriteLine("Status:    " + status);
            Console.WriteLine("Approval Score:   " + approvalScore);
            Console.WriteLine("Minimun GPA     " + minGPA);
            Console.WriteLine("******************************" + Environment.NewLine);
            Console.WriteLine("" + Environment.NewLine);
        }

        public static void PrintListOfStudents(List<Student> listOfStudentsAux)
        {
            //listOfStudentsAux.ForEach(x => Console.WriteLine("",x.studentFirstName, x.studentLastName));
            //Student studentFound;
            List<Student> listOfStudentsFound = new List<Student>();
            string studentNameToSearch = string.Empty;
            string studentNameAux = string.Empty;

            printHeader();
            Console.WriteLine("*********Search Student*********" + Environment.NewLine);
            Console.WriteLine("Enter the Student Name: ");
            studentNameToSearch = Console.ReadLine();

            foreach (Student studentAux in listOfStudentsAux)
            {            
                studentNameAux = studentAux.studentFirstName;
                
                if (String.Equals(studentNameToSearch, studentNameAux))
                {
                    listOfStudentsFound.Add(studentAux);
                }
                
            }

            if (listOfStudentsFound.Count > 0)
            {
                foreach (Student item in listOfStudentsFound)
                {
                    Console.WriteLine("");
                    item.PrintData();
                }
                //Thread.Sleep(1000);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                
            }
            else 
            {
                printHeader();
                Console.WriteLine("No student with that name was found" + Environment.NewLine);
                Console.WriteLine("Press any key to back to the Menu...");
                Console.ReadKey();
            }
            
        }
    }
}       
     


