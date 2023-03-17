namespace TDD.CleanArchitecture.Exceptions
{
    public class ScholarshipNotExistException : Exception
    {
        public ScholarshipNotExistException() : base("獎學金不存在") { }
        public ScholarshipNotExistException(string message) : base(message) { }
    }
}
