using System.Collections.Generic;
using System.Linq;
using Laboratory2.Models;

namespace Laboratory2.Repositories
{
    public class StudentRepositoryImpl : IStudentsRepository
    {
        private List<Student> _students = new List<Student>();
        
        private int _nextStudentId = 10;
        private int NextStudentId => _nextStudentId++;

        public void AddOrUpdate(Student student)
        {
            var index = _students.FindIndex(studentItem => studentItem.Id == student.Id);
            if (index == -1)
            {
                if (student.Id == -1)
                {
                    student.Id = NextStudentId;
                }
                _students.Add(student);
            }
            else
            {
                _students[index] = student;
            }
        }

        public void Delete(Student student)
        {
            _students.Remove(student);
        }

        public void DeleteAt(int id)
        {
            var index = _students.FindIndex(studentItem => studentItem.Id == id);
            if (index == -1) return;
            _students.RemoveAt(index);
        }

        public void DeleteAll()
        {
            _students.Clear();
        }

        public List<Student> All() => _students;

        public List<Student> BySubjectId(int subjectId) => _students
            .Where(student => student.SubjectGrades.Any(subjectGrade => subjectGrade.SubjectId == subjectId))
            .ToList();

        public Student ById(int studentId) => _students.Find(student => student.Id == studentId);
    }
}