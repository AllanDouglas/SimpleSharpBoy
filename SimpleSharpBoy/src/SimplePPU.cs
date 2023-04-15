using Raylib_cs;
using Color = Raylib_cs.Color;

namespace SimpleSharpBoy;

public sealed partial class SimplePPU : IPPU
{
    private const int AMOUNT_OF_TILES = 384;
    private static readonly int SCALE = 4;
    private static readonly int TILE_SCALE = 8 / SCALE;
    private static Color Transparent = new(0, 0, 0, 0);
    private static readonly Color[] PALETTE = new Color[]
    {
        new(236, 230, 210, 255),
        new(165, 161, 147,255 ),
        new(94, 92, 84, 255),
        new(18, 21, 65, 255)
    };

    private readonly IBus<Bit8Value, Bit16Value> _bus;
    private readonly bool _isDebugMode;

    public event Action<bool>? OnSwitch = null;

    public SimplePPU(IBus<Bit8Value, Bit16Value> bus, bool debugMode = false)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _isDebugMode = debugMode;
        Raylib.InitWindow(160 * SCALE, 144 * SCALE, "Simple PPU");
        Raylib.SetTargetFPS(120);
        Raylib.SetWindowTitle(debugMode ? "Debug Window" : "Main Window");

        OnSwitch?.Invoke(true);
    }

    public void Close()
    {
        if (Raylib.IsWindowReady())
        {
            Raylib.CloseWindow();
            OnSwitch?.Invoke(false);
        }
    }

    public void Update()
    {
        if (!Raylib.WindowShouldClose())
        {
            if (!_isDebugMode)
            {
                MainDraw();
                return;
            }

            DebugDraw();
            return;
        }

        OnSwitch?.Invoke(false);
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

                tile[addrs] = new() { HighByte = b1, LowByte = b2 };
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

    private static void MainDraw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.WHITE);

        Raylib.DrawText("Main Window", 12, 12, 20, Color.BLACK);

        Raylib.EndDrawing();
    }

}