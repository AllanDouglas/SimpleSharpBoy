using Raylib_cs;
using Color = Raylib_cs.Color;

namespace SimpleSharpBoy;

public sealed class SimplePPU : IDisplay
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

    private struct Tile
    {
        private Bit16Value row0, row1, row2, row3, row4, row5, row6, row7;

        public Color GetColorIndex(int row, int column)
        {
            var value = this[column];
            row = 7 - row;
            var pos = 1 << row;

            var index = ((value.HighByte.Value & pos) >> row) + ((value.LowByte.Value & pos) >> row);

            return PALETTE[index];
        }

        public Bit16Value this[int index]
        {
            get => index switch
            {
                0 => row0,
                1 => row1,
                2 => row2,
                3 => row3,
                4 => row4,
                5 => row5,
                6 => row6,
                7 => row7,
                _ => throw new IndexOutOfRangeException(),
            };
            set
            {
                switch (index)
                {
                    case 0:
                        row0 = value;
                        break;
                    case 1:
                        row1 = value;
                        break;
                    case 2:
                        row2 = value;
                        break;
                    case 3:
                        row3 = value;
                        break;
                    case 4:
                        row4 = value;
                        break;
                    case 5:
                        row5 = value;
                        break;
                    case 6:
                        row6 = value;
                        break;
                    case 7:
                        row7 = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }

            }
        }
    }

}