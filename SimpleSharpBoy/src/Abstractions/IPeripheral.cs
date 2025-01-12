namespace SimpleSharpBoy;

public interface IPeripheral
{
    public void Tick(Registers snapshot);
}