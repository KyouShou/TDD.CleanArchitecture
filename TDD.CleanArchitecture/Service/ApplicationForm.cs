namespace TDD.CleanArchitecture.Service
{
    public class ApplicationForm
    {
        public long StudentID { get; }
        public long ScholarshipID { get; }

        public ApplicationForm(long studentID, long scholarshipID)
        {
            this.StudentID = studentID;
            this.ScholarshipID = scholarshipID;
        }
    }
}