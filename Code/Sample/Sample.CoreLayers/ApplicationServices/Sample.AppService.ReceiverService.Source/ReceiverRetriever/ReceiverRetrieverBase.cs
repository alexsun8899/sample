

namespace Sample.AppService.ReceiverService.AbstractBase.ReceiverRetriever
{
    public abstract class ReceiverRetrieverBase : IReceiverRetriever
    {
        public abstract void ConfigClient();

        public abstract string RetrieveRawData(string keyword);
    }
}
