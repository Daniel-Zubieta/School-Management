using System;
using System.Collections.Generic;
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
            CreatedTestData(listOfStudents);
            



            while (optionSelected == "0")
            {
                Console.Clear();
                Console.WriteLine("******************************" + Environment.NewLine);
                Console.WriteLine("***School Management System***" + Environment.NewLine);
                Console.WriteLine("       Welcome" + Environment.NewLine);
                Console.WriteLine("************************" + Environment.NewLine);
                Console.WriteLine("<<<Elija una Sucursal>>>");
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
                                    Utils.Utils.addStudent();
                                    break;
                                case "2":
                                        
                                    break;
                                case "3":
                                    Console.Clear();
                                    Console.WriteLine("******************************");
                                    Console.WriteLine("***School Management System***" + Environment.NewLine);
                                    Utils.Utils.PrintListOfStudents(listOfStudents);
                                    break;
                                case "4":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("La Opcion ingresada no es valida");
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

                                    break;
                                case "3":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("La Opcion ingresada no es valida");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }
                        break;
                    case "3":
                        while (optionSelected == "3")
                        {
                            Utils.Utils.PrintMenuCourses();
                            string optionTeacher = Console.ReadLine();
                            switch (optionTeacher)
                            {
                                case "1":
                                    Utils.Utils.createCourse();
                                    break;
                                case "2":
                                    //Enroll Student
                                    break;
                                case "3":
                                    optionSelected = "0";
                                    break;
                                case "4":
                                    optionSelected = "0";
                                    break;
                                case "5":
                                    optionSelected = "0";
                                    break;
                                default:
                                    Console.WriteLine("La Opcion ingresada no es valida");
                                    Thread.Sleep(1500);
                                    break;
                            }
                        }
                        //optionSelected = "0";
                        break;
                    case "4":
                        optionSelected = "4";
                        break;
                    default:
                        Console.WriteLine("La Opcion ingresada no es valida");
                        optionSelected = "0";
                        break;
                }
            }
            Console.WriteLine("<<<Thanks!!!>>>");
            Thread.Sleep(2500);
        }
        static void CreatedTestData(List<Student> listOfStudentsAux)
        {
            DateTime bdt = new DateTime(2010, 10, 31);
            DateTime edt = new DateTime(2023, 12, 20);
            Student student = new Student(10001 ,"Alan", "Parker", "Heroinas #220", "61605204", "Phisics", bdt, edt);
            listOfStudentsAux.Add(student);


            bdt = new DateTime(2011, 02, 05);
            edt = new DateTime(2022, 10, 15);
            student = new Student(10002, "Liz", "Rous", "America #550", "6158460", "Maths", bdt, edt);
            listOfStudentsAux.Add(student);

            bdt = new DateTime(2010, 03, 05);
            edt = new DateTime(2023, 11, 16);
            student = new Student(10003, "Alan", "Ortega", "Libertador Bolivar #450", "7156460", "Maths", bdt, edt);
            listOfStudentsAux.Add(student);
        }
    }
}
