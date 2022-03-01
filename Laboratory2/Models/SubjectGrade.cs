namespace Laboratory2.Models
{
    public class SubjectGrade
    {
        public int SubjectId { get; set; }
        public int Grade { get; set; }

        public SubjectGrade(int subjectId, int grade)
        {
            SubjectId = subjectId;
            Grade = grade;
        }
    }
}