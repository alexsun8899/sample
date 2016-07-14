using System.Runtime.Serialization;

namespace Sample.CrossCutting.DTO
{
    [DataContract(Name = "BaseResponseDTO{0}")]
    public class BaseResponseDTO
    {
        public BaseResponseDTO()
        {
            HasError = false;
            IsErrorProcessed = false;
            IsCompleted = true;
        }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public bool IsErrorProcessed { get; set; }

        [DataMember]
        public bool IsCompleted { get; set; }

        [DataMember]
        public bool IsValid { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
