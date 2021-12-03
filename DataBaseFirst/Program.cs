using DataBaseFirst.DatabaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentDB student = new StudentDB();
            //student.SubjectInsert("C#");
            /*student.StudentInsert("Walker", "Jonny", "76216731", new List<Subject> {

                new Subject{SubjectName = "JavaScript"},
                new Subject{SubjectName = "C#"}
            });
            student.StudentInsert("Shapar", "Alex", "76216731", new List<Subject> {

                new Subject{SubjectName = "ADO.NET"},
                new Subject{SubjectName = "WPF"}
            });*/
            student.StudentUpdate("7DA6216731", new List<Subject> {

                new Subject{SubjectName = "ADO.NET"},
                new Subject{SubjectName = "WPF"},
                new Subject{SubjectName = "HTML"}
            });

            student.StudentDelete("76216731");
            student.Show();
            Console.ReadLine();
        }
    }
}
