namespace SimpleSharpBoy;

public sealed class SimpleSharpConsole
{
    private readonly ICPU _cpu;
    private readonly IDisplayer _ppu;
    private bool _powerOn;

    public SimpleSharpConsole(ICPU cpu, IDisplayer displayer)
    {
        _cpu = cpu;
        _ppu = displayer;
    }

    public void Reset()
    {
        _cpu.Reset();
    }

    public void PowerOn()
    {
        Reset();
        _powerOn = true;

        Task.Run(() =>
        {
            while (_powerOn)
            {
                _ppu.Update();
            }
        });


        while (_powerOn)
        {
            _cpu.Tick();
        }

        _ppu.Close();
    }
    public void PowerOff() => _powerOn = false;
}