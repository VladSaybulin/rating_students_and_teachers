using System;
using System.Windows.Forms;
using Laboratory2.Forms;
using Laboratory2.Models;
using Laboratory2.Repositories;

namespace Laboratory2
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HomeForm(GetStudentRepository(), GetTeacherRepository(), GetSubjectRepository()));
        }
        
        private static ISubjectsRepository GetSubjectRepository()
        {
            var subjectsRepository = new SubjectsRepositoryImpl();
            
            subjectsRepository.AddOrUpdate(new Subject("Matlab", 0));
            subjectsRepository.AddOrUpdate(new Subject("Ин. язык", 1));
            subjectsRepository.AddOrUpdate(new Subject("Программирование", 2));
            subjectsRepository.AddOrUpdate(new Subject("История", 3));
            subjectsRepository.AddOrUpdate(new Subject("Информатика", 4));
            subjectsRepository.AddOrUpdate(new Subject("АВМ", 5));

            return subjectsRepository;
        }

        private static ITeachersRepository GetTeacherRepository()
        {
            var teacherRepository = new TeachersRepositoryImpl();

            var teacher1 = new Teacher("Елена", "Филлипова", "Борисовна", 0);
            teacher1.SubjectsId.Add(0);

            var teacher2 = new Teacher("Андрей", "Женса", "Вячеславович", 1);
            teacher2.SubjectsId.Add(4);
            teacher2.SubjectsId.Add(2);

            var teacher3 = new Teacher("Сергей", "Дударов", "Павлович", 2);
            teacher3.SubjectsId.Add(5);

            var teacher4 = new Teacher("Оксана", "Ласовская", "Александровна", 3);

            
            teacherRepository.AddOrUpdate(teacher1);
            teacherRepository.AddOrUpdate(teacher2);
            teacherRepository.AddOrUpdate(teacher3);
            teacherRepository.AddOrUpdate(teacher4);

            return teacherRepository;
        }

        private static IStudentsRepository GetStudentRepository()
        {
            var studentsRepository = new StudentRepositoryImpl();

            var student1 = new Student("Владислав", "Сайбулин", "Александрович", 0);
            student1.SubjectGrades.Add(new SubjectGrade(0, 70));
            student1.SubjectGrades.Add(new SubjectGrade(1, 54));
            student1.SubjectGrades.Add(new SubjectGrade(2, 87));

            var student2 = new Student("Ренат", "Габдрахманов", "Дамирович", 1);
            student2.SubjectGrades.Add(new SubjectGrade(0, 81));
            student2.SubjectGrades.Add(new SubjectGrade(1, 89));
            student2.SubjectGrades.Add(new SubjectGrade(2, 74));

            var student3 = new Student("Алексей", "Сидоров", "Генадьевич", 2);
            student3.SubjectGrades.Add(new SubjectGrade(1, 85));
            student3.SubjectGrades.Add(new SubjectGrade(3, 69));
            student3.SubjectGrades.Add(new SubjectGrade(4, 78));

            var student4 = new Student("Александр", "Пушной", "Борисович", 4);
            
            studentsRepository.AddOrUpdate(student1);
            studentsRepository.AddOrUpdate(student2);
            studentsRepository.AddOrUpdate(student3);
            studentsRepository.AddOrUpdate(student4);

            return studentsRepository;
        }
        
        
    }
}