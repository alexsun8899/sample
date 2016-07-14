using System.Runtime.Serialization;

namespace Sample.CrossCutting.DTO
{
    [DataContract(Name = "BaseDTO{0}")]
    public class BaseDTO
    {
        public BaseDTO(){}
    }
}
