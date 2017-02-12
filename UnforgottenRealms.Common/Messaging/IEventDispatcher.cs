namespace UnforgottenRealms.Common.Messaging
{
    public interface IEventDispatcher
    {
        Bus Bus { get; }

        bool Acknowledge();
    }
}
