using Sample.AppService.ReceiverService.AbstractBase.ReceiverSource;
using Sample.CrossCutting.Common.ConfigObjects.Constants;

namespace Sample.AppService.ReceiverService.Google
{
    public class GoogleReceiverSource : ReceiverSourceBase
    {
        public override string ConfigSource()
        {
            return string.Format("{0}", Constants.GOOGLE_URL);
;        }
    }
}
