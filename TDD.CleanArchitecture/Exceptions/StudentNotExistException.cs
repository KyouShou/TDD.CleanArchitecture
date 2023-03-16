using System.Runtime.Serialization;

namespace TDD.CleanArchitecture.Exceptions
{
    public class StudentNotExistException : Exception , ISerializable
    {
        public StudentNotExistException():base("學生不存在"){}
        public StudentNotExistException(string message) : base(message) { }
    }
}
