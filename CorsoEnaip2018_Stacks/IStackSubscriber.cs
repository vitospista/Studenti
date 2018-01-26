namespace CorsoEnaip2018_Stacks
{
    public interface IStackSubscriber<T>
    {
        void HandlePut(Stack<T> sender, T element);
        void HandlePop(Stack<T> sender, T element);
    }
}
