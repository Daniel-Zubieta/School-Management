﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualBasic;
using School.Utils;

namespace School
{
    public class School
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
                                    //Add Student
                                    Utils.Utils.addStudent(listOfStudents);
                                    break;
                                case "2":
                                    //Earn Credits
                                    earnCredits(listOfStudents);
                                    break;
                                case "3":
                                    //View Student Information
                                    printHeader();
                                    Utils.Utils.PrintListOfStudents(listOfStudents);
                                    break;
                                case "4":
                                    optionSelected = "0";
                                    break;
                                case "x":
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
                                    //Add Teacher
                                    Utils.Utils.addTeacher(listOfTeachers);
                                    break;
                                case "2":
                                    //View Teacher Information
                                    viewTeacherInformation(listOfTeachers);
                                    break;
                                case "3":
                                    optionSelected = "0";
                                    break;
                                case "x":
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
                                    //Create Course
                                    Utils.Utils.createCourse(listOfCourses);
                                    break;
                                case "2":
                                    //Enroll Student in Course
                                    EnrollStudent(listOfStudents, listOfCourses); 
                                    break;
                                case "3":
                                    //Assign Teacher to Course
                                    assignTeacherToCourse(listOfTeachers, listOfCourses);
                                    break;
                                case "4":
                                    // View Course Information
                                    FindCourseByID(listOfCourses);
                                    break;
                                case "5":
                                    printAllCourses(listOfCourses);
                                    break;
                                case "6":
                                    optionSelected = "0";
                                    break;
                                case "x":
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
                                    GradeCourse(listOfStudents, listOfCourses);
                                    break;
                                case "2":
                                    //List Course Grades
                                    printGrades(listOfCourses);
                                    break;
                                case "3":
                                    //List Approved Students
                                    printApprovedStudentsGrades(listOfCourses);
                                    break;
                                case "4":
                                    // List Failed Students
                                    printFailedStudentsGrades(listOfCourses);
                                    break;
                                case "5":
                                    optionSelected = "0";
                                    break;
                                case "x":
                                    break;
                                default:
                                    Console.WriteLine("Option entered is not Valid");
                                    Thread.Sleep(2500);
                                    break;
                            }
                        }
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("Option entered is not Valid");
                        optionSelected = "0";
                        break;
                }
            }
            Console.WriteLine("***************");
            Console.WriteLine("<<<Good Bye>>>");
            Console.WriteLine("<<<<Thanks>>>>");
            Console.WriteLine("***************");
            Thread.Sleep(2500);
        }

        private static void printAllCourses(List<Course> listOfCoursesAux)
        {
            printHeader();
            foreach (Course course in listOfCoursesAux)
            {
                course.PrintCourseData();
            }
            Console.WriteLine("Press Any key to continue...");
            Console.ReadKey();
        }

        private static void GradeCourse(List<Student> listOfStudentsAux, List<Course> listOfCourseAux)
        {
            //Found Course by ID 
            List<Course> listOfCoursesFound = new List<Course>();
            string courseIdToSearch = string.Empty;
            string courseIdAux = string.Empty;
            int courseIdAux2 = 0;
            int studentIdAux3 = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the 'ID' of the 'Course' were you want to Score a Student");
                courseIdToSearch = Console.ReadLine();
                if (courseIdToSearch == "x") { return; }
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseIdAux2 = item.courseId;

                        if (courseIdAux2 == int.Parse(courseIdToSearch))
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

            //Found Student by ID 
            List<Student> listOfStudentsFound = new List<Student>();
            string studentIdToSearch = string.Empty;
            string studentIdAux = string.Empty;
            int studentId2Aux = 0;
            bool flagStudentFound = false;
            Student studentFound = null;
            bool studentIsAlreadyEnrolled = false;

            while (!flagStudentFound)
            {
                printHeader();
                Console.WriteLine("*********Search Student*********" + Environment.NewLine);
                Console.WriteLine("Enter the Student ID you want to Grade: ");
                studentIdToSearch = Console.ReadLine();
                if (studentIdToSearch == "x") { return; }
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

            //Verify if the belong to the Course
            bool studentBelong = false;
            bool studentScored = false;
            string gradeAux = string.Empty;
            Grade gradeFound = null;
            string optionO = string.Empty;
            foreach (Student itemS in courseFound.ListOfStudents)
            {
                if (itemS.studentID == studentFound.studentID)
                {
                    studentBelong = true;
                }
            }
            if (studentBelong)
            {
                ////
                foreach (Grade gradeS in studentFound.ListOfGrades)
                {
                    if (gradeS.course.courseId == courseFound.courseId)
                    {
                        studentScored = true;
                        gradeFound= gradeS;
                    }
                }

                if (studentScored)
                {
                    while (string.IsNullOrEmpty(optionO))
                    {
                        printHeader();
                        Console.WriteLine("The Student is already scored in this Course" + Environment.NewLine);
                        Console.WriteLine("Do you want to Overwrite the current Score?");
                        Console.WriteLine("(1) Yes");
                        Console.WriteLine("(2) No");
                        optionO = Console.ReadLine();

                        switch (optionO)
                        {
                            case "1":
                                printHeader();
                                Console.WriteLine("Please enter the Grade for the Student: " + Environment.NewLine);
                                Console.WriteLine(studentFound.studentFirstName + " " + studentFound.studentLastName);
                                gradeAux = Console.ReadLine();
                                if (isDouble(gradeAux))
                                {
                                    if (double.Parse(gradeAux) >= 0 && double.Parse(gradeAux) <= 100)
                                    {
                                        gradeFound.score = double.Parse(gradeAux);
                                        gradeFound.printGrade();
                                        Console.WriteLine("Press Any key to continue...");
                                        Console.ReadKey();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Value Should be between 0 and 100");
                                        gradeAux = string.Empty;
                                        Thread.Sleep(2000);
                                    }


                                }
                                else
                                {
                                    Console.WriteLine("Value entered is Empty or Invalid");
                                    gradeAux = string.Empty;
                                    Thread.Sleep(2000);
                                }
                                break;
                            case "2":
                                return;
                            default:
                                optionO = string.Empty;
                                break;
                        }
                        
                    }
                    
                }
                else
                {
                    while (string.IsNullOrEmpty(gradeAux))
                    {
                        printHeader();
                        Console.WriteLine("Please enter the Grade for the Student: ");
                        Console.WriteLine(studentFound.studentFirstName + " " + studentFound.studentLastName);
                        gradeAux = Console.ReadLine();
                        if (isDouble(gradeAux))
                        {
                            if (double.Parse(gradeAux) >= 0 && double.Parse(gradeAux) <= 100)
                            {
                                Grade gradeStudent = new Grade(studentFound, courseFound, double.Parse(gradeAux));
                                studentFound.addGrade(gradeStudent);
                                gradeStudent.printGrade();
                                Console.WriteLine("Press Any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Value Should be between 0 and 100");
                                gradeAux = string.Empty;
                                Thread.Sleep(2000);
                            }


                        }
                        else
                        {
                            Console.WriteLine("Value entered is Empty or Invalid");
                            gradeAux = string.Empty;
                            Thread.Sleep(2000);
                        }
                    }
                }

                
            }
            else
            {
                printHeader();
                Console.WriteLine("*************************************************");
                Console.WriteLine("The student does not belong to the Course entered");
                Console.WriteLine("Press Any key to continue...");
                Console.ReadKey();
            }

        }

        private static void assignTeacherToCourse(List<Teacher> listOfTeachers, List<Course> listOfCourseAux)
        {
            //Found Course by ID 
            List<Course> listOfCoursesFound = new List<Course>();
            string courseIdToSearch = string.Empty;
            string courseIdAux = string.Empty;
            string instructorAux = string.Empty;
            int courseIdAux2 = 0;
            int studentIdAux3 = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the 'ID' of the 'Course' were you want to enroll the Teacher");
                courseIdToSearch = Console.ReadLine();
                if (courseIdToSearch == "x") { return; }
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseIdAux2 = item.courseId;

                        if (courseIdAux2 == int.Parse(courseIdToSearch))
                        {
                            listOfCoursesFound.Add(item);
                        }

                    }
                    if (listOfCoursesFound.Count > 0)
                    {
                        foreach (Course item in listOfCoursesFound)
                        {
                            item.PrintCourseData();
                            courseFound = item;

                            if (!courseFound.instructorStatus())
                            {
                                flagCourseFound = true;
                                Console.WriteLine("**************");
                                Console.WriteLine("Course Found!");
                                Console.WriteLine("Press Any key to continue...");
                                Console.ReadKey();

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
                                    if (teacherIdToSearch == "x") { return; }
                                    if (!string.IsNullOrEmpty(teacherIdToSearch) && isInt(teacherIdToSearch))
                                    {
                                        foreach (Teacher itemT in listOfTeachers)
                                        {
                                            teacherId2Aux = itemT.teacherID;

                                            if (teacherId2Aux == int.Parse(teacherIdToSearch))
                                            {
                                                listOfTeacherFound.Add(itemT);
                                            }

                                        }
                                        if (listOfTeacherFound.Count > 0)
                                        {
                                            printHeader();
                                            foreach (Teacher itemT in listOfTeacherFound)
                                            {
                                                Console.WriteLine("");
                                                itemT.PrintTeacherData();
                                                teacherFound = itemT;
                                            }
                                            flagTeacherFound = true;
                                            Console.WriteLine("**************");
                                            Console.WriteLine("Teacher Found!");
                                            Console.WriteLine("Press Any key to continue...");
                                            Console.ReadKey();

                                            courseFound.Instructor = teacherFound;
                                            courseFound.haveInstructor= true;
                                            printHeader();
                                            Console.WriteLine("---------------------------------");
                                            Console.WriteLine("Teacher: '" + teacherFound.teacherFirstName + "" + teacherFound.teacherLastName);
                                            Console.WriteLine("Was Assigned as Instructor to the Course:");
                                            courseFound.PrintCourseData();
                                            Console.WriteLine("---------------------------------" + Environment.NewLine);
                                            Console.WriteLine("Press Any key to continue...");
                                            Console.ReadKey();
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
                            }
                            else
                            {
                                flagCourseFound = true;
                                Console.WriteLine("**************");
                                Console.WriteLine("The Course already have an Intructor Assigned");
                                Console.WriteLine("Press Any key to continue...");
                                Console.ReadKey();
                            }
                        }
                        
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

        }

        private static void CreatedTestData(List<Student> listOfStudentsAux, List<Teacher> listOfTeachersAux, List<Course> listOfCoursesAux)
        {

            DateTime bdt;
            DateTime edt;
            //Courses 30001 'Introduction to programming' 
            bdt = new DateTime(2001, 02, 05);
            edt = new DateTime(2022, 10, 15);
            


            Teacher teacher = new Teacher(20001, "Jose", "Perez", "Main Street #422", "4654846", "Tech", "Networking", 4400, bdt, edt);
            listOfTeachersAux.Add(teacher);
            
            Course course = new Course(30001, "Introduction to programming", 65, teacher, "10:00-12:00", "Introduction to programming 301", "Ready", 80, 70);
            listOfCoursesAux.Add(course);
            
            //Students
            bdt = new DateTime(2010, 10, 31);
            edt = new DateTime(2023, 12, 20);
            Student student = new Student(10001, "Alan", "Parker", "Heroinas #220", "6160520", "Informatic", bdt, edt, 80, 50);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            Grade grade = new Grade(student, course, 80);
            student.addGrade(grade);


            bdt = new DateTime(2011, 02, 05);
            edt = new DateTime(2022, 10, 15);
            student = new Student(10002, "Liz", "Rous", "America #550", "6158460", "Technology", bdt, edt, 90, 60);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            grade = new Grade(student, course, 82);
            student.addGrade(grade);

            bdt = new DateTime(2010, 03, 05);
            edt = new DateTime(2023, 11, 16);
            student = new Student(10003, "Santiago", "Ortega", "Libertador Bolivar #450", "7156460", "Technology", bdt, edt, 80, 60);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            //grade = new Grade(student, course, 78);
            //student.addGrade(grade);

            bdt = new DateTime(2009, 04, 08);
            edt = new DateTime(2024, 10, 16);
            student = new Student(10004, "Liam", "Clarence", "Second Street #450", "6145460", "Informatic", bdt, edt, 90, 60);
            listOfStudentsAux.Add(student);
            course.enrollStudent(student);
            grade = new Grade(student, course, 65);
            student.addGrade(grade);
            //End Courses 30001 'Introduction to programming' 

            //Course 30002 'Physics 101'
            teacher = new Teacher(20002, "Alice", "Clark", "Main Street #600", "70765506", "Tech", "Programming", 4200, bdt, edt);
            listOfTeachersAux.Add(teacher);

            course = new Course(30002, "Networks", 55, teacher, "11:00-12:30", "Networks 101", "Ready", 80, 60);
            listOfCoursesAux.Add(course);
            course.enrollStudent(listOfStudentsAux[2]);
            grade = new Grade(listOfStudentsAux[2], course, 82);
            listOfStudentsAux[2].addGrade(grade);

            //End Course 30002 'Physics 101 

            bdt = new DateTime(2008, 05, 08);
            edt = new DateTime(2024, 10, 16);
            student = new Student(10005, "John", "Miranda", "Thrid Street #500", "7145480", "Informatic", bdt, edt, 90, 50);
            listOfStudentsAux.Add(student);

            bdt = new DateTime(2008, 05, 08);
            edt = new DateTime(2024, 10, 16);
            student = new Student(10006, "Victor", "Casale", "Juan de la Rosa #10", "6445480", "Technology", bdt, edt, 90, 100);
            listOfStudentsAux.Add(student);
        }

        private static void EnrollStudent(List<Student> listOfStudentsAux, List<Course> listOfCourseAux)//, List<Course> listOfCourseAux)
        {
            //Found Student by ID 
            List<Student> listOfStudentsFound = new List<Student>();
            string studentIdToSearch = string.Empty;
            string studentIdAux = string.Empty;
            int studentId2Aux = 0;
            bool flagStudentFound = false;
            Student studentFound = null;
            bool studentIsAlreadyEnrolled = false;

            while (!flagStudentFound)
            {
                printHeader();
                Console.WriteLine("*********Search Student*********" + Environment.NewLine);
                Console.WriteLine("Enter the Student ID you want to Enroll: ");
                studentIdToSearch = Console.ReadLine();
                if (studentIdToSearch == "x") { return; }
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
            int courseIdAux2 = 0;
            int studentIdAux3 = 0;
            bool flagCourseFound = false;
            Course courseFound = null;

            while (!flagCourseFound)
            {
                printHeader();
                Console.WriteLine("*********Search Course*********" + Environment.NewLine);
                Console.WriteLine("Enter the 'ID' of the 'Course' were you want to enroll the Student'" + studentFound.studentFirstName + " " + studentFound.studentLastName + "'");
                courseIdToSearch = Console.ReadLine();
                if (courseIdToSearch == "x") { return; }
                if (!string.IsNullOrEmpty(courseIdToSearch) && isInt(courseIdToSearch))
                {
                    foreach (Course item in listOfCourseAux)
                    {
                        courseIdAux2 = item.courseId;

                        if (courseIdAux2 == int.Parse(courseIdToSearch))
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

            //Verify is the stundet is already enrolled in the Course
            foreach (Student studentAux in courseFound.ListOfStudents)
            {
                studentIdAux3 = studentAux.studentID;

                if (studentIdAux3 == studentFound.studentID)
                {
                    studentIsAlreadyEnrolled = true;
                }

            }
            if (studentIsAlreadyEnrolled)
            {
                printHeader();
                Console.WriteLine("---------------------------------");
                Console.WriteLine("The Student:");
                Console.WriteLine(studentFound.studentFirstName + " " + studentFound.studentLastName + Environment.NewLine);
                Console.WriteLine("Is already Enrolled in the Course:");
                Console.WriteLine(courseFound.courseName);
                Console.WriteLine("---------------------------------" + Environment.NewLine);
                Console.WriteLine("Press Any key to continue...");
                Console.ReadKey();
            }
            //End Verify is the stundet is already enrolled in the Course
            else
            {
                if (studentFound != null && courseFound != null)
                {
                    if (studentFound.gradePointAvg >= courseFound.minGPA)
                    {
                        printHeader();
                        Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' HAVE the 'Average Grade Points' required to enroll in the Course");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student 'Grade Points Average':         " + studentFound.gradePointAvg);
                        Console.WriteLine("Course 'Required Average Grade Points': " + courseFound.minGPA);
                        Console.WriteLine("------------------------------------------" + Environment.NewLine);
                        if (studentFound.creditsEarned >= courseFound.credits)
                        {
                            Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' HAVE Enough 'Credits' to be enrolled in the Course");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Student Current 'Credits': " + studentFound.creditsEarned);
                            Console.WriteLine("Course Credits Required:   " + courseFound.credits);
                            Console.WriteLine("------------------------------------------" + Environment.NewLine);
                            courseFound.enrollStudent(studentFound);
                            studentFound.substractCredits(courseFound.credits);
                            Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' was succefully Enrolled!");
                            Console.WriteLine("Student Current 'Credits':  " + studentFound.creditsEarned);
                            Console.WriteLine("Press Any key to continue...");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' Do NOT have Enough 'Credits' to be enrolled in the Course");
                            Console.WriteLine("------------------------------------------");
                            Console.WriteLine("Student Current 'Credits': " + studentFound.creditsEarned);
                            Console.WriteLine("Course Credits Required:   " + courseFound.credits);
                            Console.WriteLine("------------------------------------------" + Environment.NewLine);
                            Console.WriteLine("Press Any key to continue...");
                            Console.ReadKey();
                        }
                        //printHeader();
                        //Console.WriteLine("-----------------------------------------------");
                        //Console.WriteLine("The Student '" + studentFound.studentFirstName +" "+ studentFound.studentLastName + "' was succefully Enrolled!");
                        //Console.WriteLine("-----------------------------------------------" + Environment.NewLine);
                        //Console.WriteLine("Press Any key to continue...");
                        //Console.ReadKey();
                    }
                    else
                    {
                        printHeader();
                        Console.WriteLine("The Student '" + studentFound.studentFirstName + " " + studentFound.studentLastName + "' do NOT have the 'Average Grade Points' required to enroll in the Course");
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine("Student 'Grade Points Average':         " + studentFound.gradePointAvg);
                        Console.WriteLine("Course 'Required Average Grade Points': " + courseFound.minGPA);
                        Console.WriteLine("------------------------------------------" + Environment.NewLine);
                        Console.WriteLine("Press Any key to continue...");
                        Console.ReadKey();
                    }
                }
            }

            //Enroll Student to the Course
            
            
        }
        //Print Header
        private static void printHeader()
        {
            Console.Clear();
            Console.WriteLine("************************");
            Console.WriteLine("School Management System");
            Console.WriteLine("************************");
            Console.WriteLine("<Press x to return Menu>" + Environment.NewLine);
            //Console.WriteLine("<<<<Choose an Option>>>>");
        }
        private static bool isInt(string intInString)
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

        private static void FindCourseByID(List<Course> listOfCourseAux)
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
                if (courseIdToSearch=="x") { break; }
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
                            if (printStudentsFlag == "x") { return; }

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
                if (teacherIdToSearch == "x") { return; }
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

        private static void earnCredits(List<Student> listOfStudentsAux)
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
                if (studentIdToSearch == "x") { return; }
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
                            if (numberOfCredits == "x") { return; }
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

        private static void printGrades(List<Course> listOfCourseAux)
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
                if (courseIdToSearch == "x") { return; }
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

        private static void printApprovedStudentsGrades(List<Course> listOfCourseAux)
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
                if (courseIdToSearch == "x") { return; }
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
                        Console.WriteLine("<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>");
                        courseFound.printApprovedStudentsGrades();
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
                    }
                }
                else
                {
                    courseIdToSearch = string.Empty;
                    flagCourseFound = false;
                    printHeader();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("The Value entered is Empty or Invalid");
                    Console.WriteLine("<<<<<<<<<Please Try Again>>>>>>>>>>>>");
                    Console.WriteLine("-------------------------------------" + Environment.NewLine);
                    Thread.Sleep(2500);
                }
            }
            //End Found Course by ID

        }

        private static void printFailedStudentsGrades(List<Course> listOfCourseAux)
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
                Console.WriteLine("******Search Course*****" + Environment.NewLine);
                Console.WriteLine("Enter the Course ID that you want to display the Grades");
                courseIdToSearch = Console.ReadLine();
                if (courseIdToSearch == "x") { return; }
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
                        Console.WriteLine("<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>");
                        courseFound.printFailedStudentsGrades();
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
                    }
                }
                else
                {
                    courseIdToSearch = string.Empty;
                    flagCourseFound = false;
                    printHeader();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine("The Value entered is Empty or Invalid");
                    Console.WriteLine("<<<<<<<<<Please Try Again>>>>>>>>>>>>");
                    Console.WriteLine("-------------------------------------" + Environment.NewLine);
                    Thread.Sleep(2500);
                }
            }
            //End Found Course by ID

        }
    }
}
