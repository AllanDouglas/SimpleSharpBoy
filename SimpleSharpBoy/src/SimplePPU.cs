using Raylib_cs;

namespace SimpleSharpBoy;

public sealed class SimplePPU : IDisplayer
{
    private readonly IBus<Bit8Value, Bit16Value> _bus;
    private readonly bool _isDebugMode;
    // private readonly Pixel[] _frameBuffer = new Pixel[23040];

    public SimplePPU(IBus<Bit8Value, Bit16Value> bus, bool debugMode = false)
    {
        _bus = bus ?? throw new ArgumentNullException(nameof(bus));
        _isDebugMode = debugMode;
        Raylib.InitWindow(160, 144, "Simple PPU");
        Raylib.SetTargetFPS(60);
        Raylib.SetWindowTitle(debugMode ? "Debug Window" : "Main Window");

    }

    public void Close() => Raylib.CloseWindow();

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
    }

    private void DebugDraw()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.GRAY);

        Span<Tile> tiles = stackalloc Tile[127];

        for (int i = 0; i < 127; i++)
        {
            var offset = i * 16;
            var tile = new Tile();
            for (int addrs = 0; addrs < 8; addrs += 2)
            {
                var b1 = _bus.Read((ushort)(0x8000 + offset));
                var b2 = _bus.Read((ushort)(0x8000 + offset + 1));

                tile[addrs] = new() { HighByte = b1, LowByte = b2 };
            }
            tiles[i] = tile;
        }


        Raylib.EndDrawing();
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
                    default:
                        throw new IndexOutOfRangeException();
                }

            }
        }
    }

    // private struct Pixel
    // {
    //     public byte r, g, b, a;
    // }
}