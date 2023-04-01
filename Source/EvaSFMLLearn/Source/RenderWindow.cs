#region Copyright

//(c) Created by Eva

#endregion

#region Using

using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;

#endregion

namespace Eva.Sfml.Learn
{
    #region Class CRenderWindow

    public class CRenderWindow : RenderWindow
    {
        #region Variables

        public List<Drawable> arDrawableItems = new List<Drawable>();

        #endregion

        #region Constructors

        public CRenderWindow(IntPtr handle) : base(handle)
        {
        }

        public CRenderWindow(VideoMode mode, string title) : base(mode, title)
        {
        }

        public CRenderWindow(IntPtr Handle, ContextSettings settings) : base(Handle, settings)
        {
        }

        public CRenderWindow(VideoMode mode, string title, Styles style) : base(mode, title, style)
        {
        }

        public CRenderWindow(VideoMode mode, string title, Styles style, ContextSettings settings) : base(mode, title, style, settings)
        {
        }

        #endregion

        #region Public methods

        public bool IsPollEvent(out Event eventToFill)
        {
            return base.PollEvent(out eventToFill);
        }

        public void Draw()
        {
            Clear();
            foreach (Drawable pDrawItem in arDrawableItems)
            {
                Draw(pDrawItem);
            }
            Display();
        }

        #endregion
    }

    #endregion
}
