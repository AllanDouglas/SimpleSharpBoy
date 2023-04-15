namespace SimpleSharpBoy;

[Flags]
public enum LDC_Control
{
    BG_AND_WINDOW_ENABLE = 1,
    OBJ_ENABLE = 1 << 1,
    OBJ_SIZE = 1 << 2,
    BG_TILE_MAP_AREA = 1 << 3,
    BG_AND_WINDOW_TILE_DATA_AREA = 1 << 4,
    WINDOW_ENABLE = 1 << 5,
    WINDOW_TILE_MAP_AREA = 1 << 6,
    LCD_AND_PPU_ENABLED = 1 << 7
}
