namespace TrashBucked.Scripts
{
    public interface IInteractable : IAction, IInitialization

    {
        bool IsInteractable { get; }
    }
}