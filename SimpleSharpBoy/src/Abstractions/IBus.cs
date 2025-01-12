namespace SimpleSharpBoy;

public interface IBus<TValue, TAddress>
 where TAddress : struct
 where TValue : struct
{
    TValue Read(in TAddress address);
    void Write(in TAddress address, TValue value);
    void Connect(IBusConnector<TValue, TAddress> connector);

}
