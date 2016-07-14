
namespace Sample.AppService.ReceiverService.AbstractBase.ReceiverLogic
{
    public abstract class ReceiverLogicBase : IReceiverLogic
    {
        public abstract string ConfigStdSearchCriteria();

        public abstract string ConfigExtSearchCriteria();
    }
}
