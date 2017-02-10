namespace UnforgottenRealms.Common.Messaging
{
    public interface IEventHandler<T>
    {
        void Handle(T @event);
    }
}
