using System.Diagnostics;

namespace SimpleSharpBoy;

[DebuggerDisplay("{Value, nq} = {Value, h}")]
public struct Bit16Value : IEquatable<Bit16Value>, IEquatable<ushort>
{
    public Bit8Value High;
    public Bit8Value Low;

    public Bit16Value(ushort value) : this()
    {
        Value = value;
    }

    public ushort Value
    {
        readonly get => (ushort)(Low.Value | (High.Value << 8));
        set
        {
            High = (byte)(value >> 8);
            Low = (byte)(0x00FF & value);
        }

    }
    public override string ToString() => Value.ToString();
    public static implicit operator Bit16Value(ushort a) => new() { Value = a };
    public static explicit operator ushort(Bit16Value a) => a.Value;
    public static implicit operator Bit8Value(Bit16Value a) => a.Low;
    public static explicit operator Bit16Value(Bit8Value a) => a.Value;

    public static bool operator ==(Bit16Value a, Bit16Value b) => a.Value == b.Value;
    public static bool operator !=(Bit16Value a, Bit16Value b) => a.Value != b.Value;
    public static Bit16Value operator +(Bit16Value a, Bit16Value b) => new() { Value = (ushort)(a.Value + b.Value) };
    public static Bit16Value operator +(Bit16Value a, int inc) => new() { Value = (ushort)(a.Value + inc) };
    public static Bit16Value operator ++(Bit16Value a) => new() { Value = (ushort)(a.Value + 1) };
    public static Bit16Value operator -(Bit16Value a, int inc) => new() { Value = (ushort)(a.Value - inc) };
    public static Bit16Value operator --(Bit16Value a) => new() { Value = (ushort)(a.Value - 1) };
    public static Bit16Value operator &(int a, Bit16Value b) => new() { Value = (ushort)(a & b.Value) };
    public static Bit16Value operator &(Bit16Value a, int b) => new() { Value = (ushort)(a.Value & b) };
    public static Bit16Value operator >>(Bit16Value a, int b) => new() { Value = (ushort)(a.Value >> b) };

    public override bool Equals(object? other)
    {
        if (other == default)
        {
            return false;
        }

        if (other is Bit16Value bit16Obj)
        {
            return Equals(bit16Obj);
        }

        return false;
    }

    public override int GetHashCode() => Value.GetHashCode();

    public bool Equals(Bit16Value other) => this == other;

    public bool Equals(ushort other) => other == Value;
}
