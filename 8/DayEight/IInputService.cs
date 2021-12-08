public interface IInputService
{
    Task<IEnumerable<Input>> GetInput();
}