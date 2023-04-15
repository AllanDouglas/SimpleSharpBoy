namespace SimpleSharpBoy;
public sealed partial class SimpleBoyCPU
{
    Dictionary<byte, Action> _cbMap = new();

    private partial void InitInstructions()
    {
        _map.Add(0x00, NOP);
        _map.Add(0x01, LD_BC_NN);
        _map.Add(0x02, LD_ADDRS_BC_A);
        _map.Add(0x03, INC_BC);
        _map.Add(0x04, INC_B);
        _map.Add(0x05, DEC_B);
        _map.Add(0x06, LD_B_N);
        _map.Add(0x07, RLCA);
        _map.Add(0x08, LD_ADDRS_NN_SP);
        _map.Add(0x09, ADD_HL_BC);
        _map.Add(0x0A, LD_A_ADDRS_BC);
        _map.Add(0x0B, DEC_BC);
        _map.Add(0x0C, INC_C);
        _map.Add(0x0D, DEC_C);
        _map.Add(0x0E, LD_C_N);
        _map.Add(0x0F, RRCA);

        _map.Add(0x10, STOP);
        _map.Add(0x11, LD_DE_NN);
        _map.Add(0x12, LD_ADDRS_DE_A);
        _map.Add(0x13, INC_DE);
        _map.Add(0x14, INC_D);
        _map.Add(0x15, DEC_D);
        _map.Add(0x16, LD_D_N);
        _map.Add(0x17, RLA);
        _map.Add(0x18, JR_NN);
        _map.Add(0x19, ADD_HL_DE);
        _map.Add(0x1A, LD_A_ADDRS_DE);
        _map.Add(0x1B, DEC_DE);
        _map.Add(0x1C, INC_E);
        _map.Add(0x1D, DEC_E);
        _map.Add(0x1E, LD_E_N);
        _map.Add(0x1F, RRA);

        _map.Add(0x20, JR_NZ_N);
        _map.Add(0x21, LD_HL_NN);
        _map.Add(0x22, LDI_ADDRS_HL_A);
        _map.Add(0x23, INC_HL);
        _map.Add(0x24, INC_H);
        _map.Add(0x25, DEC_H);
        _map.Add(0x26, LD_H_N);
        _map.Add(0x27, DAA);
        _map.Add(0x28, JR_Z_N);
        _map.Add(0x29, ADD_HL_HL);
        _map.Add(0x2A, LDI_A_ADDRS_HL);
        _map.Add(0x2B, DEC_HL);
        _map.Add(0x2C, INC_L);
        _map.Add(0x2D, DEC_L);
        _map.Add(0x2E, LD_L_N);
        _map.Add(0x2F, CPL);

        _map.Add(0x30, JR_NC_N);
        _map.Add(0x31, LD_SP_NN);
        _map.Add(0x32, LDD_ADDRS_HL_A);
        _map.Add(0x33, INC_SP);
        _map.Add(0x34, INC_ADDRS_HL);
        _map.Add(0x35, DEC_ADDRS_HL);
        _map.Add(0x36, LD_ADDRS_HL_N);
        _map.Add(0x37, SCF);
        _map.Add(0x38, JR_C_N);
        _map.Add(0x39, ADD_HL_SP);
        _map.Add(0x3A, LDD_A_ADDRS_HL);
        _map.Add(0x3B, DEC_SP);
        _map.Add(0x3C, INC_A);
        _map.Add(0x3D, DEC_A);
        _map.Add(0x3E, LD_A_N);
        _map.Add(0x3F, CCF);


        _map.Add(0x40, LD_B_B);
        _map.Add(0x41, LD_B_C);
        _map.Add(0x42, LD_B_D);
        _map.Add(0x43, LD_B_E);
        _map.Add(0x44, LD_B_H);
        _map.Add(0x45, LD_B_L);
        _map.Add(0x46, LD_B_ADDRS_HL);
        _map.Add(0x47, LD_B_A);
        _map.Add(0x48, LD_C_B);
        _map.Add(0x49, LD_C_C);
        _map.Add(0x4A, LD_C_D);
        _map.Add(0x4B, LD_C_E);
        _map.Add(0x4C, LD_C_H);
        _map.Add(0x4D, LD_C_L);
        _map.Add(0x4E, LD_C_ADDRS_HL);
        _map.Add(0x4F, LD_C_A);

        _map.Add(0x50, LD_D_B);
        _map.Add(0x51, LD_D_C);
        _map.Add(0x52, LD_D_D);
        _map.Add(0x53, LD_D_E);
        _map.Add(0x54, LD_D_H);
        _map.Add(0x55, LD_D_L);
        _map.Add(0x56, LD_D_ADDRS_HL);
        _map.Add(0x57, LD_D_A);
        _map.Add(0x58, LD_E_B);
        _map.Add(0x59, LD_E_C);
        _map.Add(0x5A, LD_E_D);
        _map.Add(0x5B, LD_E_E);
        _map.Add(0x5C, LD_E_H);
        _map.Add(0x5D, LD_E_L);
        _map.Add(0x5E, LD_E_ADDRS_HL);
        _map.Add(0x5F, LD_E_A);

        _map.Add(0x60, LD_H_B);
        _map.Add(0x61, LD_H_C);
        _map.Add(0x62, LD_H_D);
        _map.Add(0x63, LD_H_E);
        _map.Add(0x64, LD_H_H);
        _map.Add(0x65, LD_H_L);
        _map.Add(0x66, LD_H_ADDRS_HL);
        _map.Add(0x67, LD_H_A);
        _map.Add(0x68, LD_L_B);
        _map.Add(0x69, LD_L_C);
        _map.Add(0x6A, LD_L_D);
        _map.Add(0x6B, LD_L_E);
        _map.Add(0x6C, LD_L_H);
        _map.Add(0x6D, LD_L_L);
        _map.Add(0x6E, LD_L_ADDRS_HL);
        _map.Add(0x6F, LD_L_A);

        _map.Add(0x70, LD_ADDRS_HL_B);
        _map.Add(0x71, LD_ADDRS_HL_C);
        _map.Add(0x72, LD_ADDRS_HL_D);
        _map.Add(0x73, LD_ADDRS_HL_E);
        _map.Add(0x74, LD_ADDRS_HL_H);
        _map.Add(0x75, LD_ADDRS_HL_L);
        _map.Add(0x76, HALT);
        _map.Add(0x77, LD_ADDRS_HL_A);
        _map.Add(0x78, LD_A_B);
        _map.Add(0x79, LD_A_C);
        _map.Add(0x7A, LD_A_D);
        _map.Add(0x7B, LD_A_E);
        _map.Add(0x7C, LD_A_H);
        _map.Add(0x7D, LD_A_L);
        _map.Add(0x7E, LD_A_ADDRS_HL);
        _map.Add(0x7F, LD_A_A);

        _map.Add(0x80, ADD_A_B);
        _map.Add(0x81, ADD_A_C);
        _map.Add(0x82, ADD_A_D);
        _map.Add(0x83, ADD_A_E);
        _map.Add(0x84, ADD_A_H);
        _map.Add(0x85, ADD_A_L);
        _map.Add(0x86, ADD_A_ADDRS_HL);
        _map.Add(0x87, ADD_A_A);
        _map.Add(0x88, ADC_A_B);
        _map.Add(0x89, ADC_A_C);
        _map.Add(0x8A, ADC_A_D);
        _map.Add(0x8B, ADC_A_E);
        _map.Add(0x8C, ADC_A_H);
        _map.Add(0x8D, ADC_A_L);
        _map.Add(0x8E, ADC_A_ADDRS_HL);
        _map.Add(0x8F, ADC_A_A);

        _map.Add(0xA9, XOR_C);
        _map.Add(0xAD, XOR_L);
        _map.Add(0xAE, XOR_ADDRS_HL);
        _map.Add(0xAF, XOR_A);

        _map.Add(0xB0, OR_B);
        _map.Add(0xB1, OR_C);
        _map.Add(0xB6, OR_ADDRS_HL);
        _map.Add(0xB7, OR_A);

        _map.Add(0xC1, POP_BC);
        _map.Add(0xC2, JP_NZ_NN);
        _map.Add(0xC3, JP_NN);
        _map.Add(0xC4, CALL_NZ_NN);
        _map.Add(0xC5, PUSH_BC);
        _map.Add(0xC6, ADD_A_N);
        _map.Add(0xC8, RET_Z);
        _map.Add(0xC9, RET);
        _map.Add(0xCD, CALL_NN);
        _map.Add(0xCB, CB);
        _map.Add(0xCE, ADC_N);

        _map.Add(0xD0, RET_NC);
        _map.Add(0xD1, POP_DE);
        _map.Add(0xD5, PUSH_DE);
        _map.Add(0xD6, SUB_N);
        _map.Add(0xD8, RET_C);

        _map.Add(0xE0, LDH_N_A);
        _map.Add(0xE1, POP_HL);
        _map.Add(0xE4, NOT_IMPlEMENTED);
        _map.Add(0xE5, PUSH_HL);
        _map.Add(0xE6, AND_N);
        _map.Add(0xE9, JP_HL);
        _map.Add(0xEA, LD_nn_A);
        _map.Add(0xEE, XOR_N);

        _map.Add(0xF0, LDH_A_N);
        _map.Add(0xF3, DI);
        _map.Add(0xF1, POP_AF);
        _map.Add(0xF5, PUSH_AF);
        _map.Add(0xF8, LD_HL_SP_PLUS_N);
        _map.Add(0xFA, LD_A_NN);
        _map.Add(0xFB, EI);
        _map.Add(0xFE, CP_A_N);

        _cbMap.Add(0x19, RR_C);
        _cbMap.Add(0x1A, RR_D);
        _cbMap.Add(0x1B, SRA_E);
        _cbMap.Add(0x25, SLA_L);
        _cbMap.Add(0x27, SLA_A);
        _cbMap.Add(0x38, SRL_B);

    }

    private void LD_HL_SP_PLUS_N()
    {
        _registers.FlagN = false;
        _registers.FlagZ = false;

        var value = (sbyte)Fetch();

        var result = _registers.SP.Value + (ushort)value;

        _registers.FlagC = result > 0xffff;
        _registers.FlagH = ((_registers.SP.Value & 0x0fff) + (value & 0x0fff)) > 0xfff;

        LoadToReg(ref _registers.HL, (ushort)result, 12);
    }

    private void JP_NZ_NN() => ConditionalJump(!_registers.FlagZ);
    private void ADC_A_A() => Adc(_registers.A);
    private void ADC_A_ADDRS_HL() => Adc(_bus.Read(_registers.HL), 8);
    private void ADC_A_L() => Adc(_registers.L);
    private void ADC_A_H() => Adc(_registers.H);
    private void ADC_A_E() => Adc(_registers.E);
    private void ADC_A_D() => Adc(_registers.D);
    private void ADC_A_C() => Adc(_registers.C);
    private void ADC_A_B() => Adc(_registers.B);
    private void ADD_A_A() => Add(ref _registers.AF.HighByte, _registers.A);
    private void ADD_A_L() => Add(ref _registers.AF.HighByte, _registers.L);
    private void ADD_A_ADDRS_HL() => Add(ref _registers.AF.HighByte, _bus.Read(_registers.HL), 8);
    private void ADD_A_H() => Add(ref _registers.AF.HighByte, _registers.H);
    private void ADD_A_E() => Add(ref _registers.AF.HighByte, _registers.E);
    private void ADD_A_D() => Add(ref _registers.AF.HighByte, _registers.D);
    private void ADD_A_C() => Add(ref _registers.AF.HighByte, _registers.C);
    private void ADD_A_B() => Add(ref _registers.AF.HighByte, _registers.B);
    private void LD_ADDRS_HL_N() => LoadToBus(_registers.HL, Fetch());
    private void DEC_HL() => DecReg(ref _registers.HL);
    private void LD_E_N() => LoadToReg(ref _registers.DE.LowByte, Fetch(), 12);
    private void ADD_HL_DE() => Add(ref _registers.HL, _registers.DE);
    private void RLA() => RotateLeft(ref _registers.AF.HighByte);
    private void LD_D_N() => LoadToReg(ref _registers.DE.HighByte, Fetch(), 12);
    private void RRCA() => RotateRight(ref _registers.AF.HighByte);
    private void INC_C() => IncReg(ref _registers.BC.LowByte);
    private void DEC_BC() => DecReg(ref _registers.BC);
    private void LD_A_ADDRS_BC() => LoadToReg(ref _registers.AF.HighByte, _bus.Read(_registers.BC));
    private void ADD_HL_BC() => Add(ref _registers.HL, _registers.BC);
    private void LD_A_A() => LoadToReg(ref _registers.AF.HighByte, _registers.A);
    private void LD_ADDRS_HL_L() => LoadToBus(in _registers.HL, _registers.L);
    private void LD_ADDRS_HL_H() => LoadToBus(in _registers.HL, _registers.H);
    private void LD_L_L() => LoadToReg(ref _registers.HL.LowByte, _registers.L);
    private void LD_L_H() => LoadToReg(ref _registers.HL.LowByte, _registers.H);
    private void LD_L_E() => LoadToReg(ref _registers.HL.LowByte, _registers.E);
    private void LD_L_D() => LoadToReg(ref _registers.HL.LowByte, _registers.D);
    private void LD_L_C() => LoadToReg(ref _registers.HL.LowByte, _registers.C);
    private void LD_L_B() => LoadToReg(ref _registers.HL.LowByte, _registers.B);
    private void LD_H_L() => LoadToReg(ref _registers.HL.HighByte, _registers.L);
    private void LD_H_H() => LoadToReg(ref _registers.HL.HighByte, _registers.H);
    private void LD_H_E() => LoadToReg(ref _registers.HL.HighByte, _registers.E);
    private void LD_H_D() => LoadToReg(ref _registers.HL.HighByte, _registers.D);
    private void LD_H_C() => LoadToReg(ref _registers.HL.HighByte, _registers.C);
    private void LD_H_B() => LoadToReg(ref _registers.HL.HighByte, _registers.B);
    private void LD_E_ADDRS_HL() => LoadToReg(ref _registers.DE.LowByte, _bus.Read(_registers.HL), 8);
    private void LD_E_H() => LoadToReg(ref _registers.DE.LowByte, _registers.H);
    private void LD_E_E() => LoadToReg(ref _registers.DE.LowByte, _registers.E);
    private void LD_E_D() => LoadToReg(ref _registers.DE.LowByte, _registers.D);
    private void LD_E_C() => LoadToReg(ref _registers.DE.LowByte, _registers.C);
    private void LD_E_B() => LoadToReg(ref _registers.DE.LowByte, _registers.B);
    private void LD_D_L() => LoadToReg(ref _registers.DE.HighByte, _registers.L);
    private void LD_D_H() => LoadToReg(ref _registers.DE.HighByte, _registers.H);
    private void LD_D_E() => LoadToReg(ref _registers.DE.HighByte, _registers.E);
    private void LD_D_D() => LoadToReg(ref _registers.DE.HighByte, _registers.D);
    private void LD_D_C() => LoadToReg(ref _registers.DE.HighByte, _registers.C);
    private void LD_D_B() => LoadToReg(ref _registers.DE.HighByte, _registers.B);
    private void LD_C_L() => LoadToReg(ref _registers.BC.LowByte, _registers.L);
    private void LD_C_H() => LoadToReg(ref _registers.BC.LowByte, _registers.H);
    private void LD_C_E() => LoadToReg(ref _registers.BC.LowByte, _registers.E);
    private void LD_C_D() => LoadToReg(ref _registers.BC.LowByte, _registers.D);
    private void LD_C_C() => LoadToReg(ref _registers.BC.LowByte, _registers.C);
    private void LD_C_B() => LoadToReg(ref _registers.BC.LowByte, _registers.B);
    private void LD_B_L() => LoadToReg(ref _registers.BC.HighByte, _registers.L);
    private void LD_B_H() => LoadToReg(ref _registers.BC.HighByte, _registers.H);
    private void LD_B_E() => LoadToReg(ref _registers.BC.HighByte, _registers.E);
    private void LD_B_D() => LoadToReg(ref _registers.BC.HighByte, _registers.D);
    private void LD_B_C() => LoadToReg(ref _registers.BC.HighByte, _registers.C);
    private void OR_B() => Or(_registers.B);
    private void LD_H_A() => LoadToReg(ref _registers.HL.HighByte, _registers.A);
    private void LD_A_ADDRS_HL() => LoadToReg(ref _registers.AF.HighByte, _bus.Read(_registers.HL), 8);
    private void XOR_L() => Xor(_registers.L);
    private void LD_B_B() => LoadToReg(ref _registers.BC.HighByte, _registers.BC.HighByte);
    private void LD_ADDRS_HL_E() => LoadToBus(in _registers.HL, _registers.E);
    private void SRA_E() => ShiftRightArithmetic(ref _registers.DE.LowByte);
    private void RR_E() => RightRotation(ref _registers.DE.LowByte);
    private void SLA_A() => ShiftLeftArithmetic(ref _registers.AF.HighByte);
    private void LD_E_L() => LoadToReg(ref _registers.DE.LowByte, _registers.L);
    private void XOR_A() => Xor(_registers.A);
    private void LD_L_N() => LoadToReg(ref _registers.HL.LowByte, Fetch(), 8);
    private void JP_HL() => Jump(_registers.HL, 4);
    private void DEC_DE() => DecReg(ref _registers.DE);
    private void DEC_E() => DecReg(ref _registers.DE.LowByte);
    private void ADD_HL_HL() => Add(ref _registers.HL, _registers.HL, 8);
    private void LD_L_A() => LoadToReg(ref _registers.HL.LowByte, _registers.A);
    private void LD_L_ADDRS_HL() => LoadToReg(ref _registers.HL.LowByte, _bus.Read(_registers.HL), 8);
    private void DEC_ADDRS_HL() => DecFromBus(in _registers.HL);
    private void OR_ADDRS_HL() => Or(_bus.Read(_registers.HL));
    private void DEC_A() => DecReg(ref _registers.AF.HighByte);
    private void RET_NC() => ConditionalRet(!_registers.FlagC);
    private void RET_Z() => ConditionalRet(!_registers.FlagZ);
    private void ADC_N() => Adc(Fetch(), 8);
    private void POP_DE() => PopReg(ref _registers.DE);
    private void DEC_D() => DecReg(ref _registers.DE.HighByte);
    private void DEC_H() => DecReg(ref _registers.HL.HighByte);
    private void LD_A_E() => LoadToReg(ref _registers.AF.HighByte, _registers.E);
    private void LD_D_A() => LoadToReg(ref _registers.DE.HighByte, _registers.A);
    private void LD_A_D() => LoadToReg(ref _registers.AF.HighByte, _registers.D);
    private void LD_C_A() => LoadToReg(ref _registers.BC.LowByte, _registers.A);
    private void LD_A_C() => LoadToReg(ref _registers.AF.HighByte, _registers.C);
    private void XOR_N() => Xor(Fetch(), 8);
    private void LD_E_A() => LoadToReg(ref _registers.DE.LowByte, _registers.A);
    private void JR_NC_N() => ConditionalRelativeJump(!_registers.FlagC);
    private void RRA() => RightRotation(ref _registers.AF.HighByte, 4);
    private void RR_D() => RightRotation(ref _registers.DE.HighByte);
    private void RR_C() => RightRotation(ref _registers.BC.LowByte);
    private void SLA_L() => ShiftLeftArithmetic(ref _registers.HL.LowByte);
    private void SRL_B() => ShiftRightLogical(ref _registers.BC.HighByte);
    private void CB() { _clock.cycles += 4; _cbMap[Fetch().Value].Invoke(); }
    private void LD_H_N() => LoadToReg(ref _registers.HL.HighByte, Fetch(), 8);
    private void XOR_ADDRS_HL() => Xor(_bus.Read(_registers.HL), 8);
    private void LD_D_ADDRS_HL() => LoadToReg(ref _registers.DE.HighByte, _bus.Read(_registers.HL), 8);
    private void LD_C_ADDRS_HL() => LoadToReg(ref _registers.BC.LowByte, _bus.Read(_registers.HL), 8);
    private void DEC_L() => DecReg(ref _registers.HL.LowByte);
    private void LD_B_ADDRS_HL() => LoadToReg(ref _registers.BC.HighByte, _bus.Read(_registers.HL), 8);
    private void PUSH_DE() => PushReg(in _registers.DE);
    private void OR_A() => Or(_registers.A | _registers.A);
    private void SUB_N() => Sub(ref _registers.AF.HighByte, Fetch(), 8);
    private void ADD_A_N() => Add(ref _registers.AF.HighByte, Fetch(), 8);
    private void RET_C() => ConditionalRet(_registers.FlagC);
    private void LD_H_ADDRS_HL() => LoadToReg(ref _registers.HL.HighByte, _bus.Read(_registers.HL), 8);
    private void XOR_C() => Xor(_registers.C);
    private void INC_DE() => IncReg(ref _registers.DE);
    private void INC_H() => IncReg(ref _registers.HL.HighByte);
    private void INC_L() => IncReg(ref _registers.HL.LowByte);
    private void LD_A_ADDRS_DE() => LoadToReg(ref _registers.AF.HighByte, _bus.Read(_registers.DE));
    private void LD_ADDRS_HL_A() => LoadToBus(in _registers.HL, _registers.A);
    private void LD_ADDRS_HL_B() => LoadToBus(in _registers.HL, _registers.B);
    private void LD_ADDRS_HL_C() => LoadToBus(in _registers.HL, _registers.C);
    private void LD_ADDRS_HL_D() => LoadToBus(in _registers.HL, _registers.D);
    private void LD_B_N() => LoadToReg(ref _registers.BC.HighByte, Fetch(), 8);
    private void DEC_B() => DecReg(ref _registers.BC.HighByte);
    private void INC_B() => IncReg(ref _registers.BC.HighByte);
    private void INC_BC() => IncReg(ref _registers.BC);
    private void DEC_C() => DecReg(ref _registers.BC.LowByte);
    private void INC_D() => IncReg(ref _registers.DE.HighByte);
    private void INC_E() => IncReg(ref _registers.DE.LowByte);
    private void LD_ADDRS_DE_A() => LoadRegValueToRegADDRS(_registers.DE, _registers.A);
    private void LD_C_N() => LoadToReg(ref _registers.BC.LowByte, Fetch(), 8);
    private void LD_DE_NN() => LoadToReg(ref _registers.DE, new Bit16Value() { LowByte = Fetch(), HighByte = Fetch() });
    private void LD_B_A() => LoadToReg(ref _registers.BC.HighByte, in _registers.AF.HighByte);
    private void POP_BC() => PopReg(ref _registers.BC);
    private void JR_NZ_N() => ConditionalRelativeJump(_registers.FlagZ == false);
    private void LDH_A_N() => LoadToReg(ref _registers.AF.HighByte,
        _bus.Read((ushort)(0xFF00 + Fetch().Value)), 12);
    private void JR_Z_N() => ConditionalRelativeJump(_registers.FlagZ);
    private void OR_C() => Or(_registers.A | _registers.C);
    private void LD_A_B() => LoadToReg(ref _registers.AF.HighByte, in _registers.BC.HighByte);
    private void PUSH_BC() => PushReg(_registers.BC);
    private void INC_HL() => IncReg(ref _registers.HL);
    private void POP_AF() => PopReg(ref _registers.AF);
    private void INC_A() => IncReg(ref _registers.AF.HighByte);
    private void DEC_SP() => DecReg(ref _registers.SP);
    private void ADD_HL_SP() => Add(ref _registers.HL, _registers.SP);
    private void JR_C_N() => ConditionalRelativeJump(_registers.FlagC);
    private void PUSH_AF() => PushReg(_registers.AF);
    private void POP_HL() => PopReg(ref _registers.HL);
    private void PUSH_HL() => PushReg(_registers.HL);
    private void EI()
    {
        _interruptEnable = true;
        _clock.cycles += 4;
    }
    private void LDD_A_ADDRS_HL()
    {
        LoadToReg(ref _registers.AF.HighByte, _bus.Read(_registers.HL), 8);
        _registers.HL--;
    }
    private void SCF()
    {
        _registers.FlagC = true;
        _clock.cycles += 4;
    }

    private void CCF()
    {
        _registers.FlagC = !_registers.FlagC;
        _clock.cycles += 4;
    }
    private void INC_ADDRS_HL()
    {
        var current = _bus.Read(_registers.HL);
        var value = current + 1;
        _registers.FlagZ = value == 0;
        _registers.FlagN = false;
        _registers.FlagH = _registers.FlagH = ((current.Value & 0x0fff) + (value.Value & 0x0fff)) > 0xfff;

        _bus.Write(_registers.HL, value);
        _clock.cycles += 12;
    }

    private void CPL()
    {
        _registers.A = (byte)~_registers.A.Value;
        _registers.FlagZ = _registers.A == 0;
        _registers.FlagN = true;
        _registers.FlagH = true;
    }

    private void LDD_ADDRS_HL_A()
    {
        _bus.Write(_registers.HL, _registers.A);
        _registers.HL--;
        _clock.cycles += 8;
    }
    private void CALL_NZ_NN()
    {
        var lo = Fetch();
        var hi = Fetch();
        byte cycles = 12;
        if (!_registers.FlagZ)
        {
            _bus.Write((ushort)(_registers.SP - 1), _registers.PC.HighByte);
            _bus.Write((ushort)(_registers.SP - 2), _registers.PC.LowByte);

            _registers.SP -= 2;
            _registers.PC = new() { HighByte = hi, LowByte = lo };
            cycles = 24;
        }

        _clock.cycles += cycles;
    }

    private void AND_N() => AndReg(Fetch(), 8);
    private void LD_A_NN() => LoadToReg(ref _registers.AF.HighByte, _bus.Read(new()
    {
        LowByte = Fetch(),
        HighByte = Fetch()
    }), 16);


    private void CP_A_N()
    {
        var b1 = Fetch();
        var current = _registers.A;

        var result = current - b1;

        _registers.FlagN = true;
        _registers.FlagZ = result == 0;
        _registers.FlagC = b1 > current;
        _registers.FlagH = current.Value <= 0xf && (_registers.FlagC || result.Value > 0xf);

        _clock.cycles += 8;
    }


    private void LDI_A_ADDRS_HL()
    {
        _registers.A = _bus.Read(_registers.HL);
        _registers.HL++;
        _clock.cycles += 8;
    }

    private void LDI_ADDRS_HL_A()
    {
        _bus.Write(_registers.HL, _registers.A);
        _registers.HL++;
        _clock.cycles += 8;
    }

    private void STOP()
    {
        _clock.cycles += 12;
        Halt();
    }

    private void JR_NN()
    {
        var b1 = (sbyte)Fetch();
        var address = _registers.PC + new Bit16Value() { Value = (ushort)b1 };
        Jump(address, 12);
    }

    private void LD_A_H() => LoadToReg(ref _registers.AF.HighByte, _registers.H);
    private void LD_A_L() => LoadToReg(ref _registers.AF.HighByte, _registers.L);

    private void CALL_NN()
    {
        var lo = Fetch();
        var hi = Fetch();

        var pcH = (byte)(_registers.PC >> 8);
        var pcL = (byte)(0x00ff & _registers.PC);

        _bus.Write((ushort)(_registers.SP - 1), pcH);
        _bus.Write((ushort)(_registers.SP - 2), pcL);

        _registers.SP -= 2;
        _registers.PC = (ushort)(lo | (hi << 8));
        _clock.cycles += 24;
    }

    private void LD_HL_NN() => LoadToReg(ref _registers.HL, new() { LowByte = Fetch(), HighByte = Fetch() });
    private void LDH_N_A()
    {
        var lo = Fetch().Value;
        _bus.Write((ushort)(0xFF00 + lo), _registers.A);
        _clock.cycles += 12;
    }
    private void LD_A_N() => LoadToReg(ref _registers.AF.HighByte, Fetch(), 8);

    private void LD_nn_A()
    {
        var b1 = Fetch();
        var b2 = Fetch();
        _bus.Write((ushort)(b1 | (b2 << 8)), _registers.A);
        _clock.cycles += 16;
    }

    private void LD_SP_NN() => LoadToReg(ref _registers.SP, new() { LowByte = Fetch(), HighByte = Fetch() });

    private void DI()
    {
        _interruptEnable = false;
        _clock.cycles += 4;
    }

    private void RET()
    {
        var b1 = _bus.Read(_registers.SP++);
        var b2 = _bus.Read(_registers.SP++);

        _registers.PC = (ushort)(b1 | (b2 << 8));
        _clock.cycles += 16;

    }

    private void INC_SP() => IncReg(ref _registers.SP);
    private void JP_NN() => Jump(new() { LowByte = Fetch(), HighByte = Fetch() });
    private void Jump(Bit16Value address, byte cycles = 16)
    {
        _registers.PC = address;
        _clock.cycles += cycles;
    }

    private void LD_ADDRS_NN_SP()
    {
        var address = new Bit16Value() { LowByte = Fetch(), HighByte = Fetch() };
        _bus.Write(address, _registers.SP.LowByte);
        _bus.Write(address + 1, _registers.SP.LowByte);

        _clock.cycles += 20;
    }

    private void RLCA() => RotateLeft(ref _registers.AF.HighByte, 4);

    private void HALT()
    {
        _clock.cycles += 4;
        Halt();
    }

    private void NOP() => _clock.cycles += 4;
    private void LD_BC_NN() => LoadToReg(ref _registers.BC, new()
    {
        LowByte = Fetch(),
        HighByte = Fetch()
    });

    private void LD_ADDRS_BC_A() => LoadRegValueToRegADDRS(_registers.BC, _registers.A);
    private void DAA()
    {

        byte regA = _registers.A.Value;

        bool flagH = _registers.FlagH;
        bool flagN = _registers.FlagN;
        bool flagC = _registers.FlagC;

        bool newFlagH = false;
        bool newFlagC = false;

        int daa = 0;

        if (flagN)
        {
            if (flagH)
                daa = -0x06;
            if (flagC)
                daa -= 0x60;
        }
        else
        {
            if (flagH || (regA & 0x0F) > 0x09 || daa >= 0x06)
            {
                daa += 0x06;
                newFlagH = true;
            }

            if (flagC || regA > 0x99 || daa >= 0x60)
            {
                daa += 0x60;
                newFlagC = true;
            }
        }
        regA += (byte)daa;

        _registers.A += (byte)daa;
        _registers.FlagZ = regA == 0;
        _registers.FlagH = newFlagH;
        _registers.FlagC = newFlagC;
    }

    private void LoadRegValueToRegADDRS(Bit16Value addrs, Bit8Value value)
    {
        _bus.Write(addrs, value);
        _clock.cycles += 8;
    }

    private void LoadToReg(ref Bit16Value reg, in Bit16Value value, ushort cycles = 12)
    {
        reg = value;
        _clock.cycles += cycles;
    }

    private void LoadToReg(ref Bit8Value reg, in Bit8Value value, ushort cycles = 4)
    {
        reg = value.Value;
        _clock.cycles += cycles;
    }

    private void LoadToBus(in Bit16Value address, in Bit8Value value, ushort cycles = 8)
    {
        _bus.Write(address, value);
        _clock.cycles += cycles;
    }

    private void IncReg(ref Bit16Value reg)
    {
        reg++;
        _clock.cycles += 8;
    }
    private void IncReg(ref Bit8Value reg)
    {
        var value = reg + 1;

        _registers.FlagN = false;
        _registers.FlagZ = value == 0;
        _registers.FlagH = reg.Value <= 0xf && value > 0xf;

        reg = value;
        _clock.cycles += 4;
    }

    private void DecReg(ref Bit16Value reg)
    {
        reg--;
        _clock.cycles += 8;
    }
    private void DecReg(ref Bit8Value reg)
    {
        var value = reg - 1;

        _registers.FlagN = true;
        _registers.FlagZ = value == 0;
        _registers.FlagH = reg.Value > 0xf && value.Value <= 0xf;

        reg = value;
        _clock.cycles += 4;
    }

    private void AndReg(in Bit8Value value, byte cycles = 4)
    {
        _registers.A &= value;
        _registers.FlagZ = _registers.A == 0;
        _registers.FlagC = false;
        _registers.FlagN = false;
        _registers.FlagH = true;
        _clock.cycles += cycles;
    }


    private void Xor(Bit8Value value, byte cycles = 4)
    {
        _registers.A ^= value;

        _registers.FlagZ = _registers.A == 0;
        _registers.FlagC = false;
        _registers.FlagN = false;
        _registers.FlagH = false;

        _clock.cycles += cycles;
    }

    private void PushReg(in Bit16Value reg)
    {
        _bus.Write((ushort)(_registers.SP - 1), reg.HighByte);
        _bus.Write((ushort)(_registers.SP - 2), reg.LowByte);
        _registers.SP -= 2;

        _clock.cycles += 16;
    }
    private void PopReg(ref Bit16Value reg)
    {
        var lo = _bus.Read(_registers.SP);
        var hi = _bus.Read((ushort)(_registers.SP + 1));
        reg = new() { HighByte = hi, LowByte = lo };
        _registers.SP += 2;
        _clock.cycles += 12;
    }

    private void Add(ref Bit8Value reg, Bit8Value b1, byte cycles = 4)
    {
        Bit8Value current = reg;
        var result = current.Value + b1.Value;

        _registers.FlagN = false;
        _registers.FlagZ = result == 0;
        _registers.FlagC = result > byte.MaxValue;
        _registers.FlagH = (current.Value & 0xf) + (b1.Value & 0xf) > 0xf;

        reg = (byte)result;
        _clock.cycles += cycles;
    }

    private void Add(ref Bit16Value reg, Bit16Value value, byte cycles = 4)
    {
        var current = reg;
        var result = current.Value + value.Value;

        _registers.FlagN = false;
        _registers.FlagC = result > 0xffff;
        _registers.FlagH = ((current.Value & 0x0fff) + (value.Value & 0x0fff)) > 0xfff;

        reg = (ushort)result;
        _clock.cycles += cycles;
    }
    private void Sub(ref Bit8Value reg, Bit8Value value, byte cycles = 4)
    {
        Bit8Value current = reg;
        var result = current - value;

        _registers.FlagN = true;
        _registers.FlagZ = result == 0;
        _registers.FlagC = value > current;
        _registers.FlagH = (current.Value & 0xf) + (value.Value & 0xf) > 0xf;
        reg = result;
        _clock.cycles = cycles;
    }
    private void Or(Bit8Value value)
    {
        _registers.FlagZ = value == 0;
        _registers.FlagC = _registers.FlagH = _registers.FlagN = false;

        _registers.A = value;

        _clock.cycles += 4;
    }

    private void ShiftRightLogical(ref Bit8Value reg)
    {
        var value = reg >> 1;

        _registers.FlagN = false;
        _registers.FlagH = false;
        _registers.FlagZ = value == 0;
        _registers.FlagC = (reg.Value & 0b0000_0001) == 1;

        reg = value;
        _clock.cycles += 8;
    }

    private void ShiftLeftArithmetic(ref Bit8Value reg)
    {
        var value = reg << (byte)1;

        _registers.FlagN = false;
        _registers.FlagH = false;
        _registers.FlagZ = value == 0;
        _registers.FlagC = (reg.Value & 0b1000_0000) == 1;

        reg = value;
        _clock.cycles += 8;
    }

    private void ShiftRightArithmetic(ref Bit8Value reg)
    {
        var currentBit7 = reg.Value & 0b1000_0000;

        var value = reg >> 1;

        _registers.FlagN = false;
        _registers.FlagH = false;
        _registers.FlagZ = value == 0;
        _registers.FlagC = (reg.Value & 0b0000_0001) == 1;

        reg = (byte)(value.Value | currentBit7);

        _clock.cycles += 8;
    }


    private void RightRotation(ref Bit8Value reg, byte cycles = 8)
    {
        var value = reg >> 1 | (reg << (byte)7);

        _registers.FlagN = false;
        _registers.FlagH = false;
        _registers.FlagZ = value == 0;
        _registers.FlagC = (reg.Value & 0b0000_0001) == 1;

        reg = value;
        _clock.cycles += cycles;

    }
    private void ConditionalRelativeJump(bool condition)
    {
        ushort cycles = 8;

        if (condition)
        {
            var b1 = (sbyte)Fetch();
            _registers.PC = (ushort)(_registers.PC + b1);
            cycles = 12;
        }
        else
        {
            _registers.PC++;
        }
        _clock.cycles += cycles;
    }

    private void ConditionalJump(bool condition)
    {
        ushort cycles = 12;

        if (condition)
        {

            _registers.PC = new()
            {
                LowByte = Fetch(),
                HighByte = Fetch()
            };
            cycles = 16;
        }
        else
        {
            _registers.PC += 2;
        }
        _clock.cycles += cycles;
    }

    private void Adc(Bit8Value value, ushort cycles = 4)
    {
        var cy = _registers.F & (byte)Flags.C;
        value = _registers.A + value + cy;
        _registers.FlagZ = value == 0;
        _registers.FlagN = false;
        _registers.FlagH = _registers.A.Value <= 0xF && value > 0xF;
        _registers.FlagC = value > byte.MaxValue || cy != (value & 0b1000_0000);
        _registers.A = value;
        _clock.cycles += cycles;
    }


    private void ConditionalRet(bool condition)
    {
        _clock.cycles += 4;
        if (condition)
        {
            RET();
            return;
        }

        _clock.cycles += 4;
    }


    private void DecFromBus(in Bit16Value reg)
    {
        var value = _bus.Read(reg) - 1;

        _registers.FlagN = true;
        _registers.FlagZ = value == 0;
        _registers.FlagH = reg.Value > 0xf && value.Value <= 0xf;

        _bus.Write(reg, value);
        _clock.cycles += 12;
    }
    private void RotateLeft(ref Bit8Value reg, byte cycles = 4)
    {

        var hBit = reg.Value & 0b1000_0000;
        var value = (reg.Value << 1) | (hBit >> 7);

        _registers.FlagC = hBit > 0;
        _registers.FlagN = _registers.FlagH = _registers.FlagZ = false;

        reg = (byte)value;
        _clock.cycles += cycles;
    }

    private void RotateRight(ref Bit8Value reg, byte cycles = 4)
    {

        var hBit = reg.Value & 0b0000_0001;
        var value = (reg.Value >> 1) | hBit;

        _registers.FlagC = hBit > 0;
        _registers.FlagN = _registers.FlagH = _registers.FlagZ = false;

        reg = (byte)value;
        _clock.cycles += cycles;
    }



}