using Sample.AppService.ReceiverService.AbstractBase.ReceiverLogic;

namespace Sample.AppService.ReceiverService.Google
{
    public class GoogleReceiverLogic : ReceiverLogicBase
    {
        public override string ConfigStdSearchCriteria()
        {
            //To save time, I use start, num, output and keyword as default criteria. However, this criteria should be created by configuration manager.
            return "/search?num=100&q={0}";
        }

        public override string ConfigExtSearchCriteria()
        {
            //just one thought :)
            return "custom - Google Search API";
        }
    }
}
