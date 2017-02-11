namespace UnforgottenRealms.Common
{
    public class AtomicReference<T>
    {
        public T Value { get; set; }

        public AtomicReference()
        {
        }

        public AtomicReference(T value)
        {
            Value = value;
        }
    }
}
