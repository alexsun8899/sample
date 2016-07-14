using Sample.AppService.ParserService.AbstractBase.DataExtractor;
using Sample.AppService.ParserService.AbstractBase.ParserLogic;
using Sample.CrossCutting.DTO;
using System;

namespace Sample.ApplicationServices.Modules.Parser
{
    public class ParserAppService : IParserAppService
    {
        readonly IParserLogic _parserLogic;
        readonly IParserDataExtractor _parserDataExtractor;

        public ParserAppService(IParserLogic parserLogic, IParserDataExtractor parserDataExtractor)
        {
            _parserLogic = parserLogic;
            _parserDataExtractor = parserDataExtractor;
        }

        public ResponseDTO<string> FindLinkPositions(string data, string domain)
        {
            var response = new ResponseDTO<string>();
            try
            {
                var parserLogic = _parserLogic.ConfigLogic();
                var result = _parserDataExtractor.ExtractData(parserLogic, data, domain);
                response.Result = result;
                response.IsCompleted = true;
                response.HasError = false;
            }
            catch (Exception ex)
            {
                response.IsCompleted = false;
                response.HasError = true;
                response.IsErrorProcessed = true;
                response.ErrorMessage = ex.Message;
            }
            return response;
        }

    }
}
