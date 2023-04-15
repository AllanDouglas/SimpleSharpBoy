namespace SimpleSharpBoy;

public interface IPPU : IPowerSwitcherDispatcher
{
    void Update();
    void Close();
}
