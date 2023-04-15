namespace SimpleSharpBoy;

[Flags]
public enum LCD_Stat
{
    LYC_EQUAL_LY_FLAG = 1 << 2,
    MODE_0 = 1 << 3,
    MODE_1 = 1 << 4,
    MODE_5 = 1 << 5,
    LYC_EQUAL_LY = 1 << 6
}
