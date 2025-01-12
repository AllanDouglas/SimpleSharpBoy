using Raylib_cs;

namespace SimpleSharpBoy;

public interface ILDC
{
    LDC_Control Control { get; }
    LCD_Mode Mode { get; }
    LCD_Stat Stat { get; }

    Bit8Value ScrollX { get; }
    Bit8Value ScrollY { get; }
    Bit8Value Ly { get; set; }
    Bit8Value LyCompare { get; }
    Bit8Value WindowPosX { get; }
    Bit8Value WindowPosY { get; }
    Bit8Value DMA { get; }
    Bit8Value BgPalette { get; }
    Bit8Value[] ObjPalette { get; }

    Color[] BackgroundColors { get; }
    Color[] SpriteColorsOne { get; }
    Color[] SpriteColorsTwo { get; }

    void Update();
}
