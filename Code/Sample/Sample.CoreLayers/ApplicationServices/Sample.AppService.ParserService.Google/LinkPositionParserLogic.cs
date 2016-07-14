using Sample.AppService.ParserService.AbstractBase.ParserLogic;
using Sample.CrossCutting.Common.Helpers;

namespace Sample.AppService.ParserService.Google
{
    public class LinkPositionParserLogic : ParserLogicBase
    {
        public override RegexHelper ConfigLogic()
        {
            var regex = new RegexHelper("(?'Group1'<h3 class=\"r\"><a href=\"/url\\?q=)(?'Group2'\\w+[a-zA-Z0-9.\\-?=/:]*)");
            return regex;
        }
    }
}
