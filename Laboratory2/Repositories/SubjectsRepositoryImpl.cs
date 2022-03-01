using System.Collections.Generic;
using System.Runtime.InteropServices;
using Laboratory2.Models;

namespace Laboratory2.Repositories
{
    public class SubjectsRepositoryImpl : ISubjectsRepository
    {
        private List<Subject> _subjects = new List<Subject>();
        
        private int _nextSubjectId = 10;
        private int NextSubjectId => _nextSubjectId++;
        
        
        public void AddOrUpdate(Subject subject)
        {
            var index = _subjects.FindIndex(subjectItem => subjectItem.Id == subject.Id);
            if (index == -1)
            {
                if (subject.Id == -1)
                {
                    subject.Id = NextSubjectId;
                }
                _subjects.Add(subject);
            }
            else
            {
                _subjects[index] = subject;
            }
        }

        public void Delete(Subject subject)
        {
            _subjects.Remove(subject);
        }

        public void DeleteAt(int id)
        {
            var index = _subjects.FindIndex(subjectItem => subjectItem.Id == id);
            if (index == -1) return;
            _subjects.RemoveAt(index);
        }

        public void DeleteAll()
        {
            _subjects.Clear();
        }

        public List<Subject> All() => _subjects;
        
        public Subject ById(int subjectId) => _subjects.Find(subject => subject.Id == subjectId);
    }
}