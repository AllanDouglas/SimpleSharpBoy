namespace SimpleSharpBoy;

public sealed class SimpleConsole
{
    private readonly ICPU _cpu;
    private readonly IDisplay _ppu;
    private readonly SimpleDMA _dma;
    private bool _powerOn;

    public SimpleConsole(ICPU cpu, IDisplay display, SimpleDMA dma)
    {
        _cpu = cpu;
        _ppu = display;
        _dma = dma;

        display.OnSwitch += DisplaySwitchHandler;
    }

    private void DisplaySwitchHandler(bool state)
    {
        _ppu.OnSwitch -= DisplaySwitchHandler;

        if (!state && _powerOn)
        {
            PowerOff();
        }
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
                try
                {
                    _cpu.Tick();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        });

        while (_powerOn)
        {
            _ppu.Update();
            _dma.Tick();
        }
    }
    public void PowerOff()
    {
        _powerOn = false;
        _ppu.Close();
    }
}