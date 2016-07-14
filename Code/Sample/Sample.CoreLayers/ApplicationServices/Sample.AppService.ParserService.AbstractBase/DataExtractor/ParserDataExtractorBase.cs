
using Sample.CrossCutting.Common.Helpers;

namespace Sample.AppService.ParserService.AbstractBase.DataExtractor
{
    public abstract class ParserDataExtractorBase : IParserDataExtractor
    {
        public abstract string CleanData(string data);

        public abstract string AnalyzeData(string data);

        public abstract string ExtractData(RegexHelper regex, string data, string domain);
    }
}
