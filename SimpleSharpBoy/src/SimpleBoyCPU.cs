namespace SimpleSharpBoy;

public sealed partial class SimpleBoyCPU : ICPU
{
    private delegate void Instruction();
    private static readonly Instruction NOT_IMPlEMENTED = EMPTY;
    private static void EMPTY() { }
    private bool _debug = true;
    private bool _interruptEnable;
    private Registers _registers;
    private Clock _clock;
    private bool _halted;
    private Bit16Value _lastPC;
    private Bit8Value _lastOP;
    private Instruction _lastFunction = NOT_IMPlEMENTED;
    private readonly IBus<Bit8Value, Bit16Value> _bus;
    private readonly Dictionary<byte, Instruction> _map = new();
    private long _ticks;
    public Registers CpuRegisters => _registers;

    public SimpleBoyCPU(IBus<Bit8Value, Bit16Value> bus, bool debug = false)
    {
        _bus = bus;
        _debug = debug;
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
            FetchInstruction();
            ExecuteInstruction();
            EmulateCycles();
            if (_debug)
            {
                DumpLastExecutedInstruction();
            }
        }

        void FetchInstruction()
        {
            _lastPC = _registers.PC;
            _lastOP = Fetch();
        }

        void ExecuteInstruction()
        {
            _lastFunction = Decode(_lastOP);
            _lastFunction.Invoke();
        }

        void EmulateCycles()
        {
            var time = TimeSpan.FromMicroseconds(0.25 * _clock.cycles);
            _ticks += _clock.cycles;
            _clock.cycles = 0;
            Thread.Sleep(time);
        }
    }

    public void DumpLastExecutedInstruction()
        => Console.WriteLine(string.Format("PC {0,-5:X} | OP {1,-4:X} | FUNC {2,15:X} | REG {3,25}",
                                      _lastPC.Value, _lastOP.Value, _lastFunction.Method.Name, _registers));

    private Instruction Decode(Bit8Value op)
    {
        if (_map.TryGetValue(op.Value, out var instruction))
        {
            return instruction;
        }

        DumpLastExecutedInstruction();
        throw new NotImplementedException($"INSTRUCTION {op.Value:X} NOT IMPLEMENTED YET");
        // return NOT_IMPlEMENTED;
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