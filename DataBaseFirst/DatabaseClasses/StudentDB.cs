using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.DatabaseClasses
{
    class StudentDB
    {
        private DBFirstContext _context;

        public StudentDB()
        {
            _context = new DBFirstContext();
        }
        public void SubjectInsert(string name)
        {
            try
            {
                if (_context.Subjects.Any(s=>s.SubjectName==name))
                {
                    Console.WriteLine("Subject exists!");
                }
                else
                {
                    _context.Subjects.Add(new Subject { SubjectName = name });
                    _context.SaveChanges();

                    Console.WriteLine("Subject OK!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void StudentInsert(string LastName, string FirstName, string card, List<Subject> subjects)
        {
            try
            {
                if (_context.Students.Any(s=>s.StudentCard == card))
                {
                    Console.WriteLine("Student exists!");
                }
                else
                {
                    Student student = new Student
                    {
                        LastName = LastName,
                        FirstName = FirstName,
                        StudentCard = card
                    };

                    foreach (Subject subject in subjects)
                    {
                        if (_context.Subjects.Any(s => s.SubjectName == subject.SubjectName))
                        {
                            student.Subjects.Add(_context.Subjects.First(s => s.SubjectName == subject.SubjectName));          
                        }
                        else
                        {
                            student.Subjects.Add(subject);
                        }
                    }
                    _context.Students.Add(student);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
        public void StudentUpdate(string number, List<Subject> subjects)
        {
            Student student = _context.Students.SingleOrDefault(s => s.StudentCard == number);

            if (student != null)
            {
                student.Subjects.Clear();

                foreach (Subject subject in subjects)
                {
                    if (_context.Subjects.Any(s => s.SubjectName == subject.SubjectName))
                    {
                        student.Subjects.Add(_context.Subjects.First(s => s.SubjectName == subject.SubjectName));
                    }
                    else
                    {
                        student.Subjects.Add(subject);
                    }
                }
                _context.Entry(student).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }
        public void StudentDelete(string card)
        {
            Student student = _context.Students.FirstOrDefault(s => s.StudentCard == card);
            if (student != null)
            {
                _context.Entry(student).Collection(s => s.Subjects).Load();

                _context.Students.Remove(student);
                _context.SaveChanges();

                Console.WriteLine("Student has been deleted!");
            }
            else
            {
                Console.WriteLine("Student not exists!");
            }
        }
        public void Show()
        {
            foreach (Student student in _context.Students)
            {
                //Console.WriteLine(student);
                foreach (Subject subject in student.Subjects)
                {
                    Console.WriteLine($"\t{subject.SubjectName}");
                }
                Console.WriteLine("\n--------------------------------------\n");
            }
        }
    }
}
