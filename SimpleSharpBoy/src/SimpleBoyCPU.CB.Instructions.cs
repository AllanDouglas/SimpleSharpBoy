namespace SimpleSharpBoy;
public sealed partial class SimpleBoyCPU
{
    readonly Dictionary<byte, Action> _cbMap = [];

    private partial void InitCBInstructions()
    {
        _cbMap.Add(0x10, STOP_N);
        _cbMap.Add(0x11, RL_C);
        _cbMap.Add(0x14, RL_L);
        _cbMap.Add(0x15, RL_H);
        _cbMap.Add(0x16, RL_ADDRESS_HL);
        _cbMap.Add(0x17, RR_B);
        _cbMap.Add(0x19, RR_C);
        _cbMap.Add(0x21, SLA_C);
        _cbMap.Add(0x1A, RR_D);
        _cbMap.Add(0x1B, SRA_E);
        _cbMap.Add(0x25, SLA_L);
        _cbMap.Add(0x26, SLA_ADDRESS_HL);
        _cbMap.Add(0x27, SLA_A);
        _cbMap.Add(0x38, SRL_B);
        _cbMap.Add(0x37, SWAP_A);
        _cbMap.Add(0x3F, SRL_A);
        _cbMap.Add(0x5C, BIT_3_H);
        _cbMap.Add(0x5F, BIT_3_A);
        _cbMap.Add(0x67, BIT_4_A);
        _cbMap.Add(0x64, BIT_4_H);
        _cbMap.Add(0xA4, RES_4_H);
    }

    private void STOP_N()
    {
        var data = Fetch();
        if (data == 0)
        {
            _halted = true;
        }

        Console.WriteLine("Sleep mode not implemented");
    }
    private void RES_4_H() => ResetBit(4, ref _registers.HL.High);
    private void SWAP_A() => _registers.A = SwapNibbles(_registers.A);
    private void BIT_3_H() => BitOperation(_registers.H, 3);
    private void BIT_3_A() => BitOperation(_registers.A, 3);
    private void BIT_4_A() => BitOperation(_registers.A, 4);
    private void BIT_4_H() => BitOperation(_registers.H, 4);
    private void RL_C() => RotateLeft(ref _registers.BC.Low);
    private void RL_L() => RotateLeft(ref _registers.HL.Low);
    private void RL_H() => RotateLeft(ref _registers.HL.High);
    private void RL_ADDRESS_HL()
    {
        var data = _bus.Read(_registers.HL);
        RotateLeft(ref data);
        _clock.cycles = 16;
        _bus.Write(_registers.HL, data);
    }

    private void SRA_E() => ShiftRightArithmetic(ref _registers.DE.Low);
    private void RR_E() => RightRotation(ref _registers.DE.Low);
    private void SLA_A() => ShiftLeftArithmetic(ref _registers.AF.High);
    private void RR_B() => RightRotation(ref _registers.BC.High);
    private void RR_C() => RightRotation(ref _registers.BC.Low);
    private void RR_D() => RightRotation(ref _registers.DE.High);
    private void SLA_L() => ShiftLeftArithmetic(ref _registers.HL.Low);
    private void SLA_ADDRESS_HL()
    {
        var data = _bus.Read(_registers.HL);
        ShiftLeftArithmetic(ref data);
        _clock.cycles = 16;
        _bus.Write(_registers.HL, data);
    }

    private void SLA_C() => ShiftLeftArithmetic(ref _registers.BC.Low);
    private void SRL_B() => ShiftRightLogical(ref _registers.BC.High);
    private void SRL_A() => ShiftRightLogical(ref _registers.AF.High);

    private void ResetBit(byte bit, ref Bit8Value regValue)
    {
        var bitMask = 1 << bit;
        regValue.Value = (byte)(regValue.Value & bitMask);
        _clock.cycles = 8;

    }

    private void BitOperation(Bit8Value regValue, byte bit, ushort cycles = 8)
    {
        _registers.FlagH = true;
        _registers.FlagN = false;

        var bitMask = 1 << bit;

        var value = regValue.Value & bitMask;

        _registers.FlagZ = value == 0;
        _clock.cycles += cycles;
    }

    private Bit8Value SwapNibbles(Bit8Value value)
    {
        var low = (byte)(value.Value & 0b0000_1111);
        var hi = (byte)(value.Value & 0b1111_0000);
        var result = (byte)(low | hi);
        _clock.cycles = 8;

        _registers.FlagZ = result == 0;
        _registers.FlagC = false;
        _registers.FlagH = false;
        _registers.FlagN = false;

        return result;
    }


}