namespace SimpleSharpBoy;

public interface IPowerSwitcherDispatcher
{
    event Action<bool> OnPowerSwitch;
}