namespace Sample.AppService.ReceiverService.AbstractBase.ReceiverRetriever
{
    public interface IReceiverRetriever
    {
        void ConfigClient();

        string RetrieveRawData(string searchQuery);
    }
}
