using Sample.CrossCutting.Common.Helpers;

namespace Sample.AppService.ParserService.AbstractBase.DataExtractor
{ 
    public interface IParserDataExtractor
    {
        string ExtractData(RegexHelper regex, string data, string domain);
    }
}
