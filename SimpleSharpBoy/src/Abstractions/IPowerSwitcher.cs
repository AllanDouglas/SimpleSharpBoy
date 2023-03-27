namespace SimpleSharpBoy;

public interface IPowerSwitcherDispatcher
{
    event Action<bool> OnSwitch;
}