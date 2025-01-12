namespace SimpleSharpBoy;

public interface IPPU : IPowerSwitcherDispatcher, IPeripheral
{
    void Update();
    void Close();
}
