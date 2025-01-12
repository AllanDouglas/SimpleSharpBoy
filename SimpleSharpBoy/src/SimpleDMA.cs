namespace SimpleSharpBoy;

public sealed class SimpleDMA : IBusConnector<Bit8Value, Bit16Value>
{
    private bool _running;
    private Bit8Value _currentByte;
    private Bit8Value _currentValue;
    private IBus<Bit8Value, Bit16Value> _bus;

    public SimpleDMA(IBus<Bit8Value, Bit16Value> bus)
    {
        _bus = bus;
    }

    public ushort StartAddress => 0xFF46;
    public ushort Length => 1;

    public Bit8Value Read(Bit16Value address) => _currentByte;

    public void Write(Bit16Value address, Bit8Value value)
    {
        _currentValue = value;
        _currentByte = 0;
        _running = true;
    }

    public void Tick()
    {
        if (!_running)
            return;

        var address = new Bit16Value((ushort)(_currentValue.Value * 0x100 + _currentByte.Value));
        var value = _bus.Read(address);
        _bus.Write(new() { High = 0xFE, Low = _currentValue }, value);

        _currentByte++;

        _running = _currentByte < 0xA0;
    }
}