using Sample.AppService.ParserService.AbstractBase.DataExtractor;
using Sample.CrossCutting.Common.Helpers;
using System.Collections.Generic;

namespace Sample.AppService.ParserService.Google
{
    public class LinkPositionParserDataExtractor : ParserDataExtractorBase
    {
        public override string ExtractData(RegexHelper regex, string data, string domain)
        {
            var result = new List<int>();
            if (regex.IsMatch(data))
            {
                var matches = regex.Parse(data).match;
                for (int i = 0; i < matches.Count; i++)
                {
                    string match = matches[i].Groups[2].Value;
                    if (match.Contains(domain))
                        result.Add(i);
                }
            }
            return string.Join(", ", result);
        }

        public override string CleanData(string data) { return string.Empty;  } //clean data?

        public override string AnalyzeData(string data) { return string.Empty;  } //analyze data and format data?
    }
}
