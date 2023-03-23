namespace SimpleSharpBoy;

public sealed class Bus16Bit : IBus<Bit8Value, Bit16Value>
{
    private readonly byte[] _memory;

    public Bus16Bit()
    {
        _memory = new byte[65_536];
    }

    public byte Read(ushort address) => _memory[address];
    public void Write(ushort address, byte value) => _memory[address] = value;
    public void Load(byte[] data) => Array.Copy(data, _memory, data.Length - 1);

    public Bit8Value Read(Bit16Value address) => Read(address.Value);
    public void Write(Bit16Value address, Bit8Value value) => Write(address.Value, value.Value);
}