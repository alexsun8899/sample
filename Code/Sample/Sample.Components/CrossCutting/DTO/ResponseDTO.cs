using System.Runtime.Serialization;

namespace Sample.CrossCutting.DTO
{
    [DataContract(Name = "ResponseDTO{0}")]
    public class ResponseDTO<T> : BaseResponseDTO
    {
        [DataMember]
        public T Result { get; set; }
    }

}
