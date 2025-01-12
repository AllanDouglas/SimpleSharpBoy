namespace SimpleSharpBoy;

public sealed class SimpleConsole
{
    private readonly ICPU _cpu;
    private readonly IPPU _ppu;
    private readonly ILDC _lcd;
    private readonly SimpleDMA _dma;
    private bool _powerOn;

    public SimpleConsole(ICPU cpu, IPPU display, ILDC lcd)
    {
        _cpu = cpu;
        _ppu = display;
        _lcd = lcd;

        display.OnPowerSwitch += DisplaySwitchHandler;
    }

    private void DisplaySwitchHandler(bool state)
    {
        _ppu.OnPowerSwitch -= DisplaySwitchHandler;

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
                    throw;
                }
            }
        });

        while (_powerOn)
        {
            _ppu.Update();
            _lcd.Update();
        }
    }
    public void PowerOff()
    {
        _powerOn = false;
        _ppu.Close();
    }
}