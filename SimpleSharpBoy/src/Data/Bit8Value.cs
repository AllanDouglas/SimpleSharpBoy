using System.Diagnostics;

namespace SimpleSharpBoy;

[DebuggerDisplay("{Value, nq} = {Value, h}")]
public struct Bit8Value : IEquatable<Bit8Value>, IEquatable<byte>, IEquatable<sbyte>
{
    public byte Value { get; set; }

    public Bit8Value(byte value)
    {
        Value = value;
    }

    public override readonly string ToString() => Value.ToString();
    public static implicit operator Bit8Value(byte a) => new() { Value = a };
    public static explicit operator byte(Bit8Value a) => a.Value;
    public static explicit operator Bit16Value(Bit8Value a) => new() { High = a.Value };
    public static implicit operator Bit8Value(Bit16Value a) => a.High;
    public static explicit operator sbyte(Bit8Value value) => (sbyte)value.Value;
    public static bool operator ==(Bit8Value a, Bit8Value b) => a.Value == b.Value;
    public static bool operator !=(Bit8Value a, Bit8Value b) => a.Value != b.Value;
    public static Bit8Value operator |(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value | b.Value) };
    public static Bit16Value operator |(Bit8Value a, Bit16Value b) => new() { Value = (ushort)(a.Value | b.Value) };
    public static Bit8Value operator &(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value & b.Value) };
    public static Bit8Value operator +(Bit8Value a, int b) => new() { Value = (byte)(a.Value + b) };
    public static Bit8Value operator ++(Bit8Value a) => new() { Value = ++a.Value };
    public static Bit8Value operator -(Bit8Value a, int b) => new() { Value = (byte)(a.Value - b) };
    public static Bit8Value operator --(Bit8Value a) => new() { Value = (byte)(a.Value - 1) };
    public static Bit8Value operator ^(Bit8Value a, int b) => new() { Value = (byte)(a.Value ^ b) };
    public static Bit8Value operator ^(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value ^ b.Value) };
    public static Bit8Value operator +(Bit8Value a, byte b) => new() { Value = (byte)(a.Value + b) };
    public static Bit8Value operator -(Bit8Value a, byte b) => new() { Value = (byte)(a.Value - b) };
    public static Bit8Value operator ^(Bit8Value a, byte b) => new() { Value = (byte)(a.Value ^ b) };
    public static Bit8Value operator *(Bit8Value a, int b) => new() { Value = (byte)(a.Value * b) };
    public static Bit8Value operator /(Bit8Value a, int b) => new() { Value = (byte)(a.Value / b) };
    public static Bit8Value operator *(Bit8Value a, byte b) => new() { Value = (byte)(a.Value * b) };
    public static Bit8Value operator /(Bit8Value a, byte b) => new() { Value = (byte)(a.Value / b) };
    public static Bit8Value operator +(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value + b.Value) };
    public static Bit8Value operator -(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value - b.Value) };
    public static Bit8Value operator *(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value * b.Value) };
    public static Bit8Value operator /(Bit8Value a, Bit8Value b) => new() { Value = (byte)(a.Value / b.Value) };
    public static bool operator >(Bit8Value a, int b) => a.Value > b;
    public static bool operator >(Bit8Value a, byte b) => a.Value > b;
    public static bool operator <(Bit8Value a, byte b) => a.Value < b;
    public static bool operator <(Bit8Value a, int b) => a.Value < b;
    public static bool operator >(Bit8Value a, Bit8Value b) => a.Value > b.Value;
    public static bool operator <(Bit8Value a, Bit8Value b) => a.Value < b.Value;
    public static Bit16Value operator <<(Bit8Value a, int b) => new() { Value = (ushort)(a.Value << b) };
    public static Bit8Value operator <<(Bit8Value a, byte b) => new() { Value = (byte)(a.Value << b) };
    public static Bit8Value operator >>(Bit8Value a, int b) => new() { Value = (byte)(a.Value >> b) };


    public override readonly bool Equals(object? other)
    {
        if (other is null)
        {
            return false;
        }

        if (other is Bit8Value bit8Value)
        {
            return Equals(bit8Value);
        }

        return false;

    }

    public override readonly int GetHashCode() => Value.GetHashCode();

    public readonly bool Equals(Bit8Value other) => other == this;

    public readonly bool Equals(sbyte other) => other == (sbyte)Value;

    public readonly bool Equals(byte other) => Value == other;
}
