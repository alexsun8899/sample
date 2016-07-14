using System.Text.RegularExpressions;

namespace Sample.CrossCutting.Common.Helpers
{
    public class RegexHelperResult
    {
        public MatchCollection match;
        public string text;

        public RegexHelperResult(MatchCollection match, string text)
        {
            this.match = match;
            this.text = text;
        }
    }
}
