namespace SimpleSharpBoy;

public interface IDisplay : IPowerSwitcherDispatcher
{
    void Update();
    void Close();
}
