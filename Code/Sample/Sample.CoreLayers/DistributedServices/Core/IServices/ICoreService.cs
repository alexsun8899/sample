
using System.ServiceModel;

namespace Sample.DistributedServices.Core.IServices
{
    using Sample.CrossCutting.DTO;
    using Sample.CrossCutting.DTO.Modules.Receiver;

    [ServiceContract]
    public interface ICoreService
    {
        [OperationContract]
        string Echo(string str);

        [OperationContract]
        ResponseDTO<string> GetKeywordPosition(SearchDTO dto);
    }
}
