using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School
{
    internal class Grade
    {
        Guid id { get; set; }
        internal Student student { get; set; }
        internal Course course { get; set; }
        internal double score { get; set; }

        public Grade(Student studentAux, Course courseAux, double scoreAux) 
        {
            id = Guid.NewGuid();
            student = studentAux;
            course = courseAux;
            score = scoreAux;                   
        }

        public void printGrade()
        {
            student.PrintStudentBasicData();
            Console.WriteLine("Score:       " + score);
            if (score >= course.approvalScore)
            { 
                Console.WriteLine("Status:      Course Approved" + Environment.NewLine);
            }
            else
            {
                Console.WriteLine("Status:      Course Failed" + Environment.NewLine); 
            }                     
            Console.WriteLine("******************************" + Environment.NewLine);            
        }
    }
}
