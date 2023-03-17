using TDD.CleanArchitecture.Models;

namespace TDD.CleanArchitecture.Repository
{
    public interface IStudentRepository
    {
        public List<Student> Find(long studentID);
    }
}
