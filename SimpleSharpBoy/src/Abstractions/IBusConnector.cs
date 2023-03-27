namespace SimpleSharpBoy;

public interface IBusConnector<TValue, TAddress>
{
    ushort StartAddress { get; }
    ushort Length { get; }
    TValue Read(TAddress address);
    void Write(TAddress address, TValue value);
}