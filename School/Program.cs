using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using School.Utils;

namespace School
{
    public class Program
    {
        public static void Main()
        {
            //Course FirstCourse = new Course(1, "1");
            //Course SecondCourse = new Course(2, "2");
            //List<Course> CoursesList = new List<Course>();

            string optionSelected = "0";

            List<Student> listOfStudents = new List<Student>();
            List<Teacher> listOfTeachers = new List<Teacher>();
            List<Course> listOfCourses = new List<Course>();
            CreatedTestData(listOfStudents, listOfTeachers, listOfCourses);
            
            while (optionSelected == "0")
            {
                printHeader();
                Console.WriteLine("------------------------");
                Console.WriteLine("(1) Students");
                Console.WriteLine("(2) Staff");
                Console.WriteLine("(3) Courses");
                Console.WriteLine("(4) Grades");
                Console.WriteLine("(5) Exit");
                Console.WriteLine("------------------------");
                optionSelected = Console.ReadLine();
                Console.Clear();
                switch (optionSelected)
                {
                    case "1":
                        while (optionSelected == "1")
                        {
                            Utils.Utils.PrintMenuStudent();                                               
                            string optionStudent = Console.ReadLine();
                            switch (optionStudent)
                            {
                                case "1":
                                    Utils.Utils.addStudent(listOfStudents);
                                    break;
                                case "2":

                                    earnCredits(listOfStudents);
                                    break;
                                case "3":
                                    printHeader();
                                    Utils.Utils.PrintListOfStudents(listOfStudents);
                                    break;
                                case "4":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("Option entered is not Valid");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }    
                        break;
                    case "2":
                        while (optionSelected == "2")
                        {
                            Utils.Utils.PrintMenuTeacher();
                            string optionTeacher = Console.ReadLine();
                            switch (optionTeacher)
                            {
                                case "1":
                                    Utils.Utils.addTeacher();
                                    break;
                                case "2":
                                    viewTeacherInformation(listOfTeachers);
                                    break;
                                case "3":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("");
                                    Console.WriteLine("Option entered is not Valid");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }
                        break;
                    case "3":
                        while (optionSelected == "3")
                        {
                            
                            Utils.Utils.PrintMenuCourses();
                            string optionCourse = Console.ReadLine();
                            switch (optionCourse)
                            {
                                case "1":
                                    Utils.Utils.createCourse();
                                    break;
                                case "2":
                                    EnrollStudent(listOfStudents, listOfCourses); 

                                    break;
                                case "3":
                                    optionSelected = "0";
                                    break;
                                case "4":
                                    FindCourseByID(listOfCourses);
                                    //optionSelected = "0";
                                    break;
                                case "5":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("Option entered is not Valid");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }
                        //optionSelected = "0";
                        break;
                    case "4":
                        while (optionSelected == "4")
                        {

                            Utils.Utils.PrintMenuGrades();
                            string optionCourse = Console.ReadLine();
                            switch (optionCourse)
                            {
                                case "1":
                                    //Grade Course
                                    
                                    break;
                                case "2":
                                    //List Course Grades
                                    printGrades(listOfCourses);
                                    break;
                                case "3":
                                    //List Approved Students
                                    break;
                                case "4":
                                    // List Failed Students
                                    break;
                                case "5":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("Option entered is not Valid");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }

                        break;
                    default:
                        Console.WriteLine("Option entered is not Valid");
                        optionSelected = "0";
                        break;
                }
            }
            Console.WriteLine("<<<Thanks!!!>>>");
            Thread.Sleep(2500);
        }

        

        static void CreatedTestData(List<Student> listOfStudentsAux, List<Teacher> listOfTeachersAux, List<Course> listOfCoursesAux)
        {

            DateTime bdt;
            DateTime edt;
            //Courses 30001 'Introduction to programming' 
            bdt = new DateTime(2001, 02, 05);
            edt = new DateTime(2022, 10, 15);
            


            Teacher teacher = new Teacher(20001, "Jose", "Perez", "Main Street #422", "4654846", "Maths", "No Specialization", 4400, bdt, edt);
            listOfTeachersAux.Add(teacher);
            
            Course course = new Course(30001, "Maths", 55, teacher, "10:00-12:00", "Introduction to programming", "Ready", 80, 70);
            listOfCoursesAux.Add(course);
            
            //Students
            bdt = new DateTime(2010, 10, 31);
            edt = new DateTime(2023, 12, 20);
            Student student = new Student(10001, "Alan", "Parker", "Heroinas #220", "61605204", "Phisics", bdt, edt, 80, 50);
            listOfStudentsAux.Add(student);
            Grade grade = new Grade(student, course, 80);
            student.addGrade(grade);


            bdt = new DateTime(2011, 02, 05);
            edt = new DateTime(2022, 10, 15);
            student = new Student(10002, "Liz", "Rous", "America #550", "6158460", "Maths", bdt, edt, 50, 40);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            grade = new Grade(student, course, 70);
            student.addGrade(grade);

            bdt = new DateTime(2010, 03, 05);
            edt = new DateTime(2023, 11, 16);
            student = new Student(10003, "Alan", "Ortega", "Libertador Bolivar #450", "7156460", "Maths", bdt, edt, 80, 50);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            grade = new Grade(student, course, 78);
            student.addGrade(grade);

            bdt = new DateTime(2009, 04, 08);
            edt = new DateTime(2024, 10, 16);
            student = new Student(10004, "Liam", "Clarence", "Second Street #450", "7145460", "Informatic", bdt, edt, 90, 60);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            grade = new Grade(student, course, 65);
            student.addGrade(grade);
            //End Courses 30001 'Introduction to programming' 

            //Course 30002 'Physics 101'
            teacher = new Teacher(20002, "Alice", "Clark", "Main Street #422", "4654846", "Maths", "Physics", 4200, bdt, edt);
            listOfTeachersAux.Add(teacher);

            course = new Course(30002, "Basic Physics", 55, teacher, "10:00-12:00", "Physics 101", "Ready", 80, 70);
            listOfCoursesAux.Add(course);
            course.enrollStudent(listOfStudentsAux[2]);
            grade = new Grade(listOfStudentsAux[2], course, 82);
            listOfStudentsAux[2].addGrade(grade);

            //End Course 30002 'Physics 101 
        }

        static void EnrollStudent(List<Student> listOfStudentsAux, List<Course> listOfCourseAux)//, List<Course> listOfCourseAux)
        {
            //Found Student by ID 
            List<Student> listOfStudentsFound = new List<Student>();
            string studentIdToSearch = string.Empty;
            string studentIdAux = string.Empty;
            int studentId2Aux = 0;
            bool flagStudentFound = false;
            Student studentFound = null;

            while (!flagStudentFound)
            {
                printHeader();
                Console.WriteLine("*********Search Student*********" + Environment.NewLine);
                Console.WriteLine("Enter the Student ID you want to Enroll: ");
                studentIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(studentIdToSearch) && isInt(studentIdToSearch))
                {
                    foreach (Student studentAux in listOfStudentsAux)
                    {
                        studentId2Aux = studentAux.studentID;

                        if (studentId2Aux == int.Parse(studentIdToSearch))
                        {
                            listOfStudentsFound.Add(studentAux);
                        }

                    }
                    if (listOfStudentsFound.Count > 0)
                    {
                        foreach (Student item in listOfStudentsFound)
                        {
                            Console.WriteLine("");
                            item.PrintStudentData();
                            studentFound = item;
                        }
                        flagStudentFound = true;
                        Console.WriteLine("**************");
                        Console.WriteLine("Student Found!");
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                        //Thread.Sleep(1000);

                    }
                    else
                    {
                        studentIdToSearch = string.Empty;
                        flagStudentFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Student with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            //End Found Student by ID

            //Found Course by ID 
            List<Course> listOfCoursesFound = new List<Course>();
            string courseIdToSearch = string.Empty;
            string courseIdAux = string.Empty;
            int courseId2Aux = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the 'ID' of the 'Course' were you want to enroll the Student'" + studentFound.studentFirstName + " " + studentFound.studentLastName + "'");
                courseIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseId2Aux = item.courseId;

                        if (courseId2Aux == int.Parse(courseIdToSearch))
                        {
                            listOfCoursesFound.Add(item);
                        }

                    }
                    if (listOfCoursesFound.Count > 0)
                    {
                        foreach (Course item in listOfCoursesFound)
                        {
                            Console.WriteLine("");
                            item.PrintCourseData();
                            courseFound = item; 
                        }
                        flagCourseFound = true;
                        Console.WriteLine("**************");
                        Console.WriteLine("Course Found!");
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                        //Thread.Sleep(1000)
                    }
                    else
                    {
                        courseIdToSearch = string.Empty;
                        flagCourseFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Course with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();


                    }
                }
            }
            //End Found Course by ID 

            //Enroll Student to the Course
            if (studentFound != null && courseFound != null)
            {
                if (studentFound.gradePointAvg> courseFound.minGPA)
                {
                    courseFound.enrollStudent(studentFound);
                    printHeader();
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("The Student '" + studentFound.studentFirstName +" "+ studentFound.studentLastName + "' was succefully Enrolled!");
                    Console.WriteLine("-----------------------------------------------" + Environment.NewLine);
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadKey();
                }
                else
                {
                    printHeader();
                    Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' do not have the 'Average Grade Points' required to enroll in the Course");
                    Console.WriteLine("------------------------------------------");
                    Console.WriteLine("Student 'Grade Points Average':         " + studentFound.gradePointAvg);
                    Console.WriteLine("Course 'Required Average Grade Points': " + courseFound.minGPA);
                    Console.WriteLine("------------------------------------------"+ Environment.NewLine);
                    Console.WriteLine("Press Any key to continue...");
                    Console.ReadKey();
                }
            }
            
        }
        //Print Header
        static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("************************" + Environment.NewLine);
            Console.WriteLine("School Management System" + Environment.NewLine);
            Console.WriteLine("************************" + Environment.NewLine);
            //Console.WriteLine("<<<<Choose an Option>>>>");
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

        static void FindCourseByID(List<Course> listOfCourseAux)
        {
            //Found Course by ID 
            List<Course> listOfCoursesFound = new List<Course>();
            string courseIdToSearch = string.Empty;
            string courseIdAux = string.Empty;
            int courseId2Aux = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the Course ID you want display the information ");
                courseIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseId2Aux = item.courseId;

                        if (courseId2Aux == int.Parse(courseIdToSearch))
                        {
                            listOfCoursesFound.Add(item);
                        }

                    }
                    if (listOfCoursesFound.Count > 0)
                    {
                        foreach (Course item in listOfCoursesFound)
                        {
                            Console.WriteLine("");
                            item.PrintCourseData();
                            courseFound = item;
                        }
                        flagCourseFound = true;
                        Console.WriteLine("**************");
                        Console.WriteLine("Course Found!");
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                        //Thread.Sleep(1000);
                        
                        
                        string printStudentsFlag = "0";
                        while (printStudentsFlag == "0")
                        {
                            
                            printHeader();
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("Would you like to print the list of students who belong to this Course?");
                            Console.WriteLine("-----------------------------------------------------------------------" + Environment.NewLine);
                            Console.WriteLine("(1) Yes");
                            Console.WriteLine("(2) No");
                            printStudentsFlag = Console.ReadLine();

                            switch (printStudentsFlag)
                            {
                                case "1":
                                    printHeader();
                                    courseFound.printStudents();
                                    Console.WriteLine("----------------------------");
                                    Console.WriteLine("Press Any key to continue...");
                                    Console.ReadKey();

                                    break;
                                case "2":
                                    break;
                                default:
                                    printHeader();
                                    Console.WriteLine("-----------------------");
                                    Console.WriteLine("The Option is not valid");
                                    break;

                            }                        

                        }
            


                    }
                    else
                    {
                        courseIdToSearch = string.Empty;
                        flagCourseFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Course with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Thread.Sleep(2000);
                        //Console.WriteLine("Press any key to back to the Menu...");
                        //Console.ReadKey();


                    }
                }
            }
            //End Found Course by ID
        }

        private static void viewTeacherInformation(List<Teacher> listOfTeachers)
        {
            //Found Teacher by ID 
            List<Teacher> listOfTeacherFound = new List<Teacher>();
            string teacherIdToSearch = string.Empty;
            string teacherIdAux = string.Empty;
            int teacherId2Aux = 0;
            bool flagTeacherFound = false;
            Teacher teacherFound = null;

            while (!flagTeacherFound)
            {
                printHeader();
                Console.WriteLine("*********Search Teacher*********" + Environment.NewLine);
                Console.WriteLine("Enter the 'Teacher ID'that you want to display the information ");
                teacherIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(teacherIdToSearch) && isInt(teacherIdToSearch))
                {
                    foreach (Teacher item in listOfTeachers)
                    {
                        teacherId2Aux = item.teacherID;

                        if (teacherId2Aux == int.Parse(teacherIdToSearch))
                        {
                            listOfTeacherFound.Add(item);
                        }

                    }
                    if (listOfTeacherFound.Count > 0)
                    {
                        printHeader();
                        foreach (Teacher item in listOfTeacherFound)
                        {
                            Console.WriteLine("");
                            item.PrintTeacherData();
                            teacherFound = item;
                        }
                        flagTeacherFound = true;
                        Console.WriteLine("**************");
                        Console.WriteLine("Teacher Found!");
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                        //Thread.Sleep(1000);
                    }
                    else
                    {
                        teacherIdToSearch = string.Empty;
                        flagTeacherFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Teacher with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                        //Console.WriteLine("Press any key to back to the Menu...");
                        //Console.ReadKey();


                    }
                }
            }
            //End Found Course by ID


        }

        static void earnCredits(List<Student> listOfStudentsAux)
        {
            //Found Student by ID 
            List<Student> listOfStudentsFound = new List<Student>();
            string studentIdToSearch = string.Empty;
            string studentIdAux = string.Empty;
            int studentId2Aux = 0;
            bool flagStudentFound = false;
            bool creditsValidation = false;
            Student studentFound = null;
            string numberOfCredits = string.Empty;

            while (!flagStudentFound)
            {
                printHeader();
                Console.WriteLine("*********Search Student*********" + Environment.NewLine);
                Console.WriteLine("Enter the Student ID that you want to Earn Credits: ");
                studentIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(studentIdToSearch) && isInt(studentIdToSearch))
                {
                    foreach (Student studentAux in listOfStudentsAux)
                    {
                        studentId2Aux = studentAux.studentID;

                        if (studentId2Aux == int.Parse(studentIdToSearch))
                        {
                            listOfStudentsFound.Add(studentAux);
                        }

                    }
                    if (listOfStudentsFound.Count > 0)
                    {
                        foreach (Student item in listOfStudentsFound)
                        {
                            Console.WriteLine("");
                            item.PrintStudentData();
                            studentFound = item;
                        }
                        flagStudentFound = true;

                        while (!creditsValidation)
                        {
                            Console.WriteLine("***************************************************");
                            Console.WriteLine("Please enter the Number of Credits you want to earn");
                            numberOfCredits = Console.ReadLine();
                            if (!string.IsNullOrEmpty(numberOfCredits) && isInt(numberOfCredits) && int.Parse(numberOfCredits)>0)
                            {
                                studentFound.creditsEarned = studentFound.creditsEarned + int.Parse(numberOfCredits);
                                printHeader();
                                studentFound.PrintStudentData();
                                Console.WriteLine("******************************" + Environment.NewLine);
                                Console.WriteLine("Credits was Added to the Student" + Environment.NewLine);
                                Console.WriteLine("Press Any key to continue...");
                                Console.ReadKey();
                                creditsValidation = true;
                            }
                            else
                            {
                                printHeader();
                                studentFound.PrintStudentData();
                                Console.WriteLine("***************************************************");
                                Console.WriteLine("The Value Enter is Empty or Invalid");
                                Console.WriteLine("Please enter the Number of Credits you want to earn");
                                Console.WriteLine("Press Any key to continue...");
                                Console.ReadKey();
                                creditsValidation = false;
                            }
                        }
                        //Console.WriteLine("Press Any key to continue...");
                        //Console.ReadKey();
                        //Thread.Sleep(1000);

                    }
                    else
                    {
                        studentIdToSearch = string.Empty;
                        flagStudentFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Student with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            //End Found Student by ID

        }

        static void printGrades(List<Course> listOfCourseAux)
        {

            //Found Course by ID 
            List<Course> listOfCoursesFound = new List<Course>();
            string courseIdToSearch = string.Empty;
            string courseIdAux = string.Empty;
            int courseId2Aux = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the Course ID that you want to display the Grades");
                courseIdToSearch = Console.ReadLine();
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseId2Aux = item.courseId;

                        if (courseId2Aux == int.Parse(courseIdToSearch))
                        {
                            listOfCoursesFound.Add(item);
                        }

                    }
                    if (listOfCoursesFound.Count > 0)
                    {
                        foreach (Course item in listOfCoursesFound)
                        {
                            Console.WriteLine("");
                            item.PrintCourseData();
                            courseFound = item;
                        }
                        flagCourseFound = true;                        
                        Console.WriteLine("**************");
                        Console.WriteLine("Course Found!");
                        //Console.WriteLine("Press Any key to continue...");
                        //Console.ReadKey();
                        courseFound.printStudentsGrades();
                    }
                    else
                    {
                        courseIdToSearch = string.Empty;
                        flagCourseFound = false;
                        printHeader();
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("No Course with that ID was found");
                        Console.WriteLine("---------------------------------" + Environment.NewLine);
                        Thread.Sleep(2000);
                        //Console.WriteLine("Press any key to back to the Menu...");
                        //Console.ReadKey();


                    }
                }
            }
            //End Found Course by ID

        }

    }
}
