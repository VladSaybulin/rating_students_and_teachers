using System.Collections.Generic;
using System.Linq;
using Laboratory2.Models;

namespace Laboratory2.Repositories
{
    public class TeachersRepositoryImpl : ITeachersRepository
    {

        private List<Teacher> _teachers = new List<Teacher>();
        
        private int _nextTeacherId = 10;
        private int NextTeacherId => _nextTeacherId++;
        
        public void AddOrUpdate(Teacher teacher)
        {
            var index = _teachers.FindIndex(teacherItem => teacherItem.Id == teacher.Id);
            if (index == -1)
            {
                if (teacher.Id == -1)
                {
                    teacher.Id = NextTeacherId;
                }
                _teachers.Add(teacher);
            }
            else
            {
                _teachers[index] = teacher;
            }
        }

        public void Delete(Teacher teacher)
        {
            _teachers.Remove(teacher);
        }

        public void DeleteAt(int id)
        {
            var index = _teachers.FindIndex(subjectItem => subjectItem.Id == id);
            if (index == -1) return;
            _teachers.RemoveAt(index);
        }

        public void DeleteAll()
        {
            _teachers.Clear();
        }

        public List<Teacher> All() => _teachers;

        public List<Teacher> BySubject(int subjectId) => _teachers
            .Where(teacher => teacher.SubjectsId.Any(id => id == subjectId))
            .ToList();

        public Teacher ById(int teacherId) => _teachers.Find(teacher => teacher.Id == teacherId);
    }
}