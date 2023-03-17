using System.Runtime.Serialization;

namespace TDD.CleanArchitecture.Exceptions
{
    public class DataAccessErrorException : Exception , ISerializable
    {
        public DataAccessErrorException():base("學生不存在"){}
        public DataAccessErrorException(string message) : base(message) { }
    }
}
