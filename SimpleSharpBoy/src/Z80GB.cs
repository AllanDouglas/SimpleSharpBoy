namespace SimpleSharpBoy;

public sealed partial class Z80GB : ICPU
{
    private delegate void Instruction();
    private Registers _registers;
    private Clock _clock;
    private bool _halted;
    private Bit16Value _lastPC;
    private Bit8Value _lastOP;
    private readonly IBus<Bit8Value, Bit16Value> _bus;
    private readonly Dictionary<byte, Instruction> _map = new();

    public Registers CpuRegisters => _registers;

    public Z80GB(IBus<Bit8Value, Bit16Value> bus)
    {
        _bus = bus;
        InitInstructions();
    }


    public void Reset()
    {
        _registers.PC = 0x0100;
        _registers.SP = 0xFFFE;
        _registers.AF = 0x1180;
        _registers.BC = 0;
        _registers.DE = 0xFF56;
        _registers.m = _registers.t = 0;


        // initial LCD state
        _bus.Write(0xFF40, 91);
        _bus.Write(0xFF41, 81);
        _bus.Write(0xFF42, 0);
        _bus.Write(0xFF43, 0);
        _bus.Write(0xFF44, 0x90);
        _bus.Write(0xFF45, 0);
        _bus.Write(0xFF46, 0xFC);
        _bus.Write(0xFF47, 0);
        _bus.Write(0xFF48, 0);
        _bus.Write(0xFF49, 0);
        _bus.Write(0xFF4A, 0);
        _bus.Write(0xFF4B, 0);

    }

    public void Halt()
    {
        _halted = true;
    }

    public void Tick()
    {

        if (!_halted)
        {
            _lastPC = _registers.PC;
            _lastOP = Fetch();


            var function = Decode(_lastOP);

            function.Invoke();
        }

        // DumpLastExecutedInstruction();

    }

    private void DumpLastExecutedInstruction()
    {
        Console.WriteLine(string.Format("PC {0,-5:X} | OP {1,-4:X} | REG {2,10}",
                                      _lastPC.Value, _lastOP.Value, _registers));
    }

    private Instruction Decode(Bit8Value op)
    {
        if (_map.TryGetValue(op.Value, out var instruction))
        {
            return instruction;
        }
        DumpLastExecutedInstruction();
        throw new NotImplementedException($"INSTRUCTION {op.Value:X} NOT IMPLEMENTED YET");
    }
    private Bit8Value Fetch() => _bus.Read(_registers.PC++);

    private partial void InitInstructions();

    private struct Clock
    {
        public ushort size, cycles;
    }

    [Flags]
    private enum Flags
    {
        Z = 1 << 7,
        N = 1 << 6,
        H = 1 << 5,
        C = 1 << 4
    }

}