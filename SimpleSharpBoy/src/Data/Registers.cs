namespace SimpleSharpBoy;


public struct Registers
{
    public ushort m, t;
    public Bit16Value PC, SP, AF, BC, DE, HL;

    public Bit8Value A
    {
        readonly get => AF.High;
        set => AF.High = value;
    }

    public Bit8Value F
    {
        readonly get => AF.Low;
        set => AF.Low = value;
    }

    public Bit8Value B
    {
        readonly get => BC.High;
        set => BC.High = value;
    }

    public Bit8Value C
    {
        readonly get => BC.Low;
        set => BC.Low = value;
    }

    public Bit8Value D
    {
        readonly get => DE.High;
        set => DE.High = value;
    }

    public Bit8Value E
    {
        readonly get => DE.Low;
        set => DE.Low = value;
    }

    public Bit8Value H
    {
        readonly get => HL.High;
        set => HL.High = value;
    }

    public Bit8Value L
    {
        readonly get => HL.Low;
        set => HL.Low = value;
    }

    public bool FlagN
    {
        readonly get => (F & (byte)Flags.N) > 0;
        set => F = GetNewValue(F, Flags.N, value);
    }
    public bool FlagH
    {
        readonly get => (F & (byte)Flags.H) > 0;
        set => F = GetNewValue(F, Flags.H, value);
    }
    public bool FlagC
    {
        readonly get => (F & (byte)Flags.C) > 0;
        set => F = GetNewValue(F, Flags.C, value);
    }
    public bool FlagZ
    {
        readonly get => (F & (byte)Flags.Z) > 0;
        set => F = GetNewValue(F, Flags.Z, value);
    }

    private static Bit8Value GetNewValue(Bit8Value reg, Flags flag, bool value) => (byte)(value
        ? (byte)reg | (byte)flag
        : ((byte)reg & ((byte)reg ^ (byte)flag)));

    public override string ToString() => $"AF {AF.Value:X}, BC {BC.Value:X}, DE {DE.Value:X}, HL {HL.Value:X}, SP {SP.Value:X}, PC {PC.Value:X}";

}
