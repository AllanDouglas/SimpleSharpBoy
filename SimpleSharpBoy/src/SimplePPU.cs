using Raylib_cs;
using Color = Raylib_cs.Color;

namespace SimpleSharpBoy;

public sealed partial class SimplePPU : IPPU
{
    private const int WIDTH = 160;
    private const int HEIGHT = 144;
    private const int AMOUNT_OF_TILES = 384;
    private static readonly int SCALE = 4;
    private static readonly int TILE_SCALE = 8 / SCALE;
    private static Color Transparent = new(0, 0, 0, 0);

    private static readonly Color[] PALETTE =
    {
        new(236, 230, 210, 255),
        new(165, 161, 147,255 ),
        new(94, 92, 84, 255),
        new(18, 21, 65, 255)
    };
    private readonly ILDC _lcd;
    private readonly IBus<Bit8Value, Bit16Value> _bus;
    private readonly bool _isDebugMode;

    private int _modeClock = 0;
    private LCD_Mode _mode;
    private int _line, _scroll_X, _scroll_Y;

    public event Action<bool>? OnPowerSwitch = null;

    public SimplePPU(ILDC lcd, IBus<Bit8Value, Bit16Value> bus, bool debugMode = false)
    {
        _lcd = lcd;
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _isDebugMode = debugMode;

        Raylib.InitWindow(WIDTH * SCALE, HEIGHT * SCALE, "Simple PPU");
        Raylib.SetTargetFPS(60);
        Raylib.SetWindowTitle(debugMode ? "Debug Window" : "Main Window");

        OnPowerSwitch?.Invoke(true);
    }

    public void Close()
    {
        if (Raylib.IsWindowReady())
        {
            Raylib.CloseWindow();
            OnPowerSwitch?.Invoke(false);
        }
    }

    public void Update()
    {
        if (!Raylib.WindowShouldClose())
        {
            if (_isDebugMode)
            {
                DebugDraw();
            }
            else
            {
                MainDraw();
            }

            return;
        }

        OnPowerSwitch?.Invoke(false);
    }

    private void RenderLine()
    {
        // Console.WriteLine("render line");
    }

    private void DebugDraw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.GRAY);

        Span<Tile> tiles = stackalloc Tile[AMOUNT_OF_TILES];
        LoadTiles(ref tiles);

        var index = 0;
        for (int y = 0; y < 24; y++)
        {
            for (int x = 0; x < 16; x++)
            {
                DrawTile(x, y, tiles[index++]);
            }
        }

        Raylib.EndDrawing();
    }

    private void LoadTiles(ref Span<Tile> tiles)
    {

        for (int i = 0; i < AMOUNT_OF_TILES; i++)
        {
            var offset = i * 16;
            var tile = new Tile();
            for (int addrs = 0; addrs < 8; addrs++)
            {
                var b1 = _bus.Read((ushort)(0x8000 + offset));
                var b2 = _bus.Read(address: (ushort)(0x8000 + offset + 1));

                tile[addrs] = new() { High = b1, Low = b2 };
                offset += 2;
            }
            tiles[i] = tile;
        }


    }

    private static void DrawTile(int x, int y, Tile tile)
    {
        x *= SCALE * TILE_SCALE;
        y *= SCALE * TILE_SCALE;

        for (int col = 0; col < 8; col++)
        {
            for (int row = 0; row < 8; row++)
            {
                Raylib.DrawRectangle(
                    (x + row) * SCALE,
                    (y + col) * SCALE,
                    SCALE,
                    SCALE,
                    tile.GetColorIndex(row, col));
            }
        }
    }

    private void MainDraw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        Span<Tile> tiles = stackalloc Tile[AMOUNT_OF_TILES];
        LoadTiles(ref tiles);

        var index = 0;
        for (int y = 0; y < 24; y++)
        {
            for (int x = 0; x < 16; x++)
            {
                DrawTile(x, y, tiles[index++]);
            }
        }

        Raylib.EndDrawing();
    }

    public void Tick(Registers snapshot)
    {
        if (_isDebugMode)
        {
            return;
        }

        _modeClock += snapshot.t;

        switch (_mode)
        {
            case LCD_Mode.HORIZONTAL_BLANK:

                if (_modeClock >= 204)
                {
                    _modeClock = 0;
                    _lcd.Ly++;
                    if (_line == 143)
                    {
                        _mode = LCD_Mode.VERTICAL_BLANK;
                        Repaint();
                        _lcd.Ly++;
                    }
                    else
                    {
                        _mode = LCD_Mode.ACCESSING_OAM;
                    }
                }
                break;
            case LCD_Mode.VERTICAL_BLANK:
                if (_modeClock >= 456)
                {
                    _modeClock = 0;
                    _lcd.Ly++;
                    if (_lcd.Ly > 153)
                    {
                        _lcd.Ly = 0;
                        _mode = LCD_Mode.ACCESSING_OAM;
                    }
                }
                break;

            case LCD_Mode.ACCESSING_OAM:
                if (_modeClock >= 80)
                {
                    _mode = LCD_Mode.ACCESSING_VRAM;
                    _modeClock = 0;
                }
                break;

            case LCD_Mode.ACCESSING_VRAM:
                if (_modeClock >= 172)
                {
                    _modeClock = 0;
                    _mode = LCD_Mode.HORIZONTAL_BLANK;

                    RenderLine();
                }
                break;

        }
    }

    private void Repaint()
    {
        // Console.WriteLine("##################### VBLANK ##############");
    }
}