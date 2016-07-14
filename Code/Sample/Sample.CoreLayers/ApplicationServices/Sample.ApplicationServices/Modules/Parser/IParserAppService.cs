using Sample.CrossCutting.DTO;

namespace Sample.ApplicationServices.Modules.Parser
{
    public interface IParserAppService
    {
        ResponseDTO<string> FindLinkPositions(string rawData, string domain);
    }
}
