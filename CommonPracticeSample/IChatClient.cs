namespace CommonPracticeSample
{
    public interface IChatClient
    {
        Task BroadcastMessage(string name, string message);
        Task GroupMessage(string message);
    }
}
