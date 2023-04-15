using Raylib_cs;

namespace SimpleSharpBoy;

public sealed class SimpleLCD : ILDC, IBusConnector<Bit8Value, Bit16Value>
{
    private static readonly Color[] PALETTE = new Color[]
    {
        new(236, 230, 210, 255),
        new(165, 161, 147,255 ),
        new(94, 92, 84, 255),
        new(18, 21, 65, 255)
    };


    private readonly Bit8Value[] _data;

    public SimpleLCD()
    {
        _data = new Bit8Value[Length];

        Control = (LDC_Control)0x91;
        BgPalette = 0xFC;

    }

    public LDC_Control Control
    {
        get => (LDC_Control)Read(0xFF40).Value;
        set => Write(0xFF40, (byte)value);
    }

    public LCD_Mode Mode
    {
        get => (LCD_Mode)(Read(0xff41) & 0b0000_0011).Value;
        set
        {
            var current = (Read(0xff41) & 0b1111_1100).Value;
            var result = current | (byte)value;

            Write(0xff41, (byte)result);
        }
    }

    public LCD_Stat Stat
    {
        get => (LCD_Stat)(Read(0xff41) & 0b1111_1100).Value;
        set
        {
            var current = (Read(0xff41) & 0b0000_0011).Value;
            var result = current | ((byte)value & 0b1111_1100);
            Write(0xff41, (byte)result);
        }
    }

    public Bit8Value ScrollX => Read(0xff43);
    public Bit8Value ScrollY => Read(0xff42);
    public Bit8Value Ly => Read(0xff44);
    public Bit8Value LyCompare => Read(0xff45);
    public Bit8Value DMA => Read(0xff46);
    public Bit8Value BgPalette
    {
        get => Read(0xff47);
        set => Write(0xff47, value);
    }
    public Bit8Value[] ObjPalette { get; }
    public Color[] BackgroundColors => throw new NotImplementedException();
    public Color[] SpriteColorsOne => throw new NotImplementedException();
    public Color[] SpriteColorsTwo => throw new NotImplementedException();
    public ushort StartAddress => 0xFF40;
    public ushort Length => 11;
    public Bit8Value WindowPosX => Read(0xff4b);
    public Bit8Value WindowPosY => Read(0xff4a);
    public Bit8Value Read(Bit16Value address) => _data[GetAddress(address).Value];
    public void Write(Bit16Value address, Bit8Value value) => _data[GetAddress(address).Value] = value;
    private Bit16Value GetAddress(Bit16Value address) => address - StartAddress;

}
