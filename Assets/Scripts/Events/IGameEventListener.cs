namespace BSOD.Events
{
    public interface IGameEventListener
    {
        void OnEventRaised();
    }

    public interface IGameEventListener<T>
    {
        void OnEventRaised(T value);
    }
}
