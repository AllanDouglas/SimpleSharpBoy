using Color = Raylib_cs.Color;

namespace SimpleSharpBoy;

public sealed partial class SimplePPU
{
    private struct Tile
    {
        private Bit16Value row0, row1, row2, row3, row4, row5, row6, row7;

        public Color GetColorIndex(int row, int column)
        {
            var value = this[column];
            row = 7 - row;
            var pos = 1 << row;

            var index = ((value.High.Value & pos) >> row) + ((value.Low.Value & pos) >> row);

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