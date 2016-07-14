
using Sample.CrossCutting.Common.Helpers;

namespace Sample.AppService.ParserService.AbstractBase.ParserLogic
{
    public abstract class ParserLogicBase : IParserLogic
    {
        public abstract RegexHelper ConfigLogic();
    }
}
