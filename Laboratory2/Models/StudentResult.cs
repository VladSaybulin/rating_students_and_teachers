namespace Laboratory2.Models
{
    public class StudentResult
    {
        public Student Student { get; set; }
        public int Gpa { get; set; }

        public StudentResult(Student student, int gpa)
        {
            Student = student;
            Gpa = gpa;
        }
    }
}