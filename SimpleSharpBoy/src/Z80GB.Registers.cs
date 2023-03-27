namespace SimpleSharpBoy;

public sealed partial class SimpleBoyCPU
{
    public struct Registers
    {
        public ushort m, t;
        public Bit16Value PC, SP, AF, BC, DE, HL;

        public Bit8Value A
        {
            get => AF.HighByte;
            set => AF.HighByte = value;
        }

        public Bit8Value F
        {
            get => AF.LowByte;
            set => AF.LowByte = value;
        }

        public Bit8Value B
        {
            get => BC.HighByte;
            set => BC.HighByte = value;
        }

        public Bit8Value C
        {
            get => BC.LowByte;
            set => BC.LowByte = value;
        }

        public Bit8Value D
        {
            get => DE.HighByte;
            set => DE.HighByte = value;
        }

        public Bit8Value E
        {
            get => DE.LowByte;
            set => DE.LowByte = value;
        }

        public Bit8Value H
        {
            get => HL.HighByte;
            set => HL.HighByte = value;
        }

        public Bit8Value L
        {
            get => HL.LowByte;
            set => HL.LowByte = value;
        }

        public bool FlagN
        {
            get => (F & (byte)Flags.N) > 0;
            set => F = GetNewValue(F, Flags.N, value);
        }
        public bool FlagH
        {
            get => (F & (byte)Flags.H) > 0;
            set => F = GetNewValue(F, Flags.H, value);
        }
        public bool FlagC
        {
            get => (F & (byte)Flags.C) > 0;
            set => F = GetNewValue(F, Flags.C, value);
        }
        public bool FlagZ
        {
            get => (F & (byte)Flags.Z) > 0;
            set => F = GetNewValue(F, Flags.Z, value);
        }

        private static Bit8Value GetNewValue(Bit8Value reg, Flags flag, bool value) => (byte)(value
            ? (byte)reg | (byte)flag
            : ((byte)reg & ((byte)reg ^ (byte)flag)));

        public override string ToString() => $"AF {AF.Value:X}, BC {BC.Value:X}, DE {DE.Value:X}, HL {HL.Value:X}, SP {SP.Value:X}, PC {PC.Value:X}";

    }

}
