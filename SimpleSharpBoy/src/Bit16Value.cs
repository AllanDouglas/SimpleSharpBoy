using System.Numerics;

namespace SimpleSharpBoy;

public struct Bit16Value : IEquatable<Bit16Value>, IEquatable<ushort>
{
    public Bit8Value HighByte;
    public Bit8Value LowByte;

    public ushort Value
    {
        get => (ushort)(LowByte.Value | (HighByte.Value << 8));
        set
        {
            HighByte = (byte)(value >> 8);
            LowByte = (byte)(0x00FF & value);
        }

    }
    public override string ToString() => Value.ToString();
    public static implicit operator Bit16Value(ushort a) => new() { Value = a };
    public static explicit operator ushort(Bit16Value a) => a.Value;
    public static implicit operator Bit8Value(Bit16Value a) => a.LowByte;
    public static explicit operator Bit16Value(Bit8Value a) => a.Value;

    public static bool operator ==(Bit16Value a, Bit16Value b) => a.Value == b.Value;
    public static bool operator !=(Bit16Value a, Bit16Value b) => a.Value != b.Value;
    public static Bit16Value operator +(Bit16Value a, int inc) => new() { Value = (ushort)(a.Value + inc) };
    public static Bit16Value operator ++(Bit16Value a) => new() { Value = (ushort)(a.Value + 1) };
    public static Bit16Value operator -(Bit16Value a, int inc) => new() { Value = (ushort)(a.Value - inc) };
    public static Bit16Value operator --(Bit16Value a) => new() { Value = (ushort)(a.Value - 1) };
    public static Bit16Value operator &(int a, Bit16Value b) => new() { Value = (ushort)(a & b.Value) };
    public static Bit16Value operator &(Bit16Value a, int b) => new() { Value = (ushort)(a.Value & b) };
    public static Bit16Value operator >>(Bit16Value a, int b) => new() { Value = (ushort)(a.Value >> b) };

    public override bool Equals(object obj)
    {
        if (obj == default)
        {
            return false;
        }

        if (obj is Bit16Value bit16Obj)
        {
            return Equals(bit16Obj);
        }

        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public bool Equals(Bit16Value other) => this == other;

    public bool Equals(ushort other) => other == Value;
}
