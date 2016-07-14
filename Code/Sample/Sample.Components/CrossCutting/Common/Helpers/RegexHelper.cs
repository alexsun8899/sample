using System.Text.RegularExpressions;

namespace Sample.CrossCutting.Common.Helpers
{
    public class RegexHelper
    {
        private Regex parsingRegex;

        public RegexHelper(string parsingExpression)
        {
            parsingRegex = new Regex(parsingExpression);
        }

        // returns null if the parser cannot parse the given text
        public RegexHelperResult Parse(string text)
        {
            MatchCollection matches = parsingRegex.Matches(text);

            if (matches.Count == 0)
                return null;

            return new RegexHelperResult(matches, text);
        }

        public bool IsMatch(string text)
        {
            if (text == null)
                text = "";
            Match match = parsingRegex.Match(text);
            return match.Success;
        }
    }
}
