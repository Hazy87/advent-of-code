namespace Template.Interfaces;

public interface IInputService
{
    Task<string[]> GetLines();
}