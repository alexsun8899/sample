using System.ServiceModel;

namespace Sample.DistributedServices.Core.Services
{
    using ApplicationServices.Modules.Parser;
    using ApplicationServices.Modules.Receiver;
    using CrossCutting.DTO;
    using CrossCutting.DTO.Modules.Receiver;
    using Sample.DistributedServices.Core.IServices;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public partial class CoreService : ICoreService
    {
        readonly IReceiverAppService _receiverAppService;
        readonly IParserAppService _parserAppService;

        public CoreService(IReceiverAppService receiverAppService, IParserAppService parserAppService)
        {
            _receiverAppService = receiverAppService;
            _parserAppService = parserAppService;
        }

        /// <summary>
        /// returns a string 
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public string Echo(string str)
        {
            return str;
        }

        public ResponseDTO<string> GetKeywordPosition(SearchDTO dto)
        {
            //1. Config data provider and download search result
            var response = new ResponseDTO<string>();
            var rawData = _receiverAppService.RetrieveData(dto.Keyword);

            //2. parser search result 
            var result = _parserAppService.FindLinkPositions(rawData.Result, dto.Domain);

            response.Result = result.Result;
            response.IsCompleted = true;
            response.HasError = false;

            return response;
        }
    }
}
