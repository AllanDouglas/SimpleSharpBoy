namespace SimpleSharpBoy;

public interface IBus<TValue, TAddress>
{
    TValue Read(TAddress address);
    void Write(TAddress address, TValue value);
    void Load(byte[] data);
}
