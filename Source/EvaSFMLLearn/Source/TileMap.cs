#region Copyright

//(c) SFML Tutorial https://www.sfml-dev.org/tutorials/2.5/graphics-vertex-array.php

#endregion

#region Using

using SFML.Graphics;
using SFML.System;

#endregion

namespace Eva.Sfml.Learn
{
    #region Class BaseTileMap

    public class CTileMap : Transformable, Drawable
    {
        #region Variables

        private VertexArray m_vertices;
        private Texture m_tileset;

        #endregion

        #region Constructors

        public CTileMap(string tileset, Vector2u tileSize, int[] tiles, int width, int height)
        {
            m_tileset = new Texture(tileset);
            m_vertices = new VertexArray();
            m_vertices.PrimitiveType = PrimitiveType.Quads;
            m_vertices.Resize((uint)(width * height * 4));

            // populate the vertex array, with one quad per tile
            for (int i = 0; i < width; ++i)
                for (int j = 0; j < height; ++j)
                {
                    // get the current tile number
                    int tileNumber = tiles[i + j * width];

                    // find its position in the tileset texture
                    int tu = tileNumber % (int)(m_tileset.Size.X / tileSize.X);
                    int tv = (int)(tileNumber / (m_tileset.Size.X / tileSize.X));

                    // get a pointer to the current tile's quad [0]
                    Vector2f Position = new Vector2f(i * tileSize.X, j * tileSize.Y);
                    Vector2f TexCoords = new Vector2f(tu * tileSize.X, tv * tileSize.Y);
                    Vertex quad = new Vertex(Position, TexCoords);
                    m_vertices.Append(quad);

                    Position = new Vector2f((i + 1) * tileSize.X, j * tileSize.Y);
                    TexCoords = new Vector2f((tu + 1) * tileSize.X, tv * tileSize.Y);
                    quad = new Vertex(Position, TexCoords);
                    m_vertices.Append(quad);

                    Position = new Vector2f((i + 1) * tileSize.X, (j + 1) * tileSize.Y);
                    TexCoords = new Vector2f((tu + 1) * tileSize.X, (tv + 1) * tileSize.Y);
                    quad = new Vertex(Position, TexCoords);
                    m_vertices.Append(quad);

                    Position = new Vector2f(i * tileSize.X, (j + 1) * tileSize.Y);
                    TexCoords = new Vector2f(tu * tileSize.X, (tv + 1) * tileSize.Y);
                    quad = new Vertex(Position, TexCoords);
                    m_vertices.Append(quad);
                }
        }

        #endregion

        #region Drawable implementation

        public void Draw(RenderTarget target, RenderStates states)
        {
            // apply the transform
            states.Transform *= Transform;

            // apply the tileset texture
            states.Texture = m_tileset;

            // draw the vertex array
            target.Draw(m_vertices, states);
        }

        #endregion
    }

    #endregion
}
