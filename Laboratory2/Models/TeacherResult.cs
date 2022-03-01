namespace Laboratory2.Models
{
    public class TeacherResult
    {

        public Teacher Teacher { get; set; }
        public int Gpa { get; set; }
        
        public TeacherResult(Teacher teacher, int gpa)
        {
            Gpa = gpa;
            Teacher = teacher;
        }
        
    }
}