using Sample.CrossCutting.DTO;
using Sample.CrossCutting.DTO.Modules.Receiver;

namespace Sample.ApplicationServices.Modules.Receiver
{
    public interface  IReceiverAppService
    {
        ResponseDTO<string> RetrieveData(string keyword);
    }
}
