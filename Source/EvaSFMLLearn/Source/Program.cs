#region Copyright

//(c) SFML Tutorial https://www.sfml-dev.org/tutorials/2.5/graphics-vertex-array.php

#endregion

#region Using

using Eva.Sfml.Learn;
using SFML.System;
using SFML.Window;

#endregion

namespace SnakeSFML
{
    #region Class CProgram

    public class CProgram
    {
        private static void Main(string[] args)
        {
            CLearn.TileMapLearn();
        }
    }

    #endregion

    #region Class CLearn

    public static class CLearn
    {
        #region Public methods

        public static void TileMapLearn()
        {
            CBaseRenderWindow window = new CBaseRenderWindow(new VideoMode(512, 256), "Tilemap");
            int[] level =
                {
                        0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 2, 0, 0, 0, 0,
                        1, 1, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3,
                        0, 1, 0, 0, 2, 0, 3, 3, 3, 0, 1, 1, 1, 0, 0, 0,
                        0, 1, 1, 0, 3, 3, 3, 0, 0, 0, 1, 1, 1, 2, 0, 0,
                        0, 0, 1, 0, 3, 0, 2, 2, 0, 0, 1, 1, 1, 1, 2, 0,
                        2, 0, 1, 0, 3, 0, 2, 2, 2, 0, 1, 1, 1, 1, 1, 1,
                        0, 0, 1, 0, 3, 2, 2, 2, 0, 0, 0, 0, 1, 1, 1, 1,
                };
            BaseTileMap map = new BaseTileMap("tileset.png", new Vector2u(32, 32), level, 16, 8);
            window.arDrawableItems.Add(map);
            Event pEvent;
            while (window.IsOpen)
            {
                bool bCheck = window.IsPollEvent(out pEvent);
                window.Draw();
                if (bCheck)
                {
                    // "close requested" event: we close the window
                    if (pEvent.Type == EventType.Closed)
                    {
                        window.Close();
                    }
                }
            }
        }

        #endregion
    }

    #endregion
}