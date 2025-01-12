namespace SimpleSharpBoy;
public sealed class Bus16Bit : IBus<Bit8Value, Bit16Value>
{
    private readonly byte[] _memory;
    private readonly SortedList<ushort, IBusConnector<Bit8Value, Bit16Value>> _io = new();
    public Bus16Bit(params IBusConnector<Bit8Value, Bit16Value>[] busConnectors)
    {
        _memory = new byte[65_536];

        if (busConnectors is not null)
        {
            foreach (var item in busConnectors)
            {
                Connect(item);
            }
        }

    }

    public byte Read(in ushort address) => _memory[address];
    public void Write(in ushort address, byte value) => _memory[address] = value;

    public Bit8Value Read(in Bit16Value address)
    {
        if (TryGetConnector(in address, out var connector))
        {
            return connector.Read(address);
        }

        return Read(address.Value);
    }

    public void Write(in Bit16Value address, Bit8Value value)
    {
        if (TryGetConnector(in address, out var connector))
        {
            connector.Write(address, value);
            return;
        }
    
        Write(address.Value, value.Value);
    }

    private bool TryGetConnector(in Bit16Value address, out IBusConnector<Bit8Value, Bit16Value> output)
    {
        output = default;
        foreach (var item in _io)
        {
            if (address.Value >= item.Value.StartAddress && address.Value < (item.Value.StartAddress + item.Value.Length))
            {
                output = item.Value;
                return true;
            }
        }

        return false;


    }

    public void Connect(IBusConnector<Bit8Value, Bit16Value> connector)
    {
        _io.Add(connector.StartAddress, connector);
    }
}