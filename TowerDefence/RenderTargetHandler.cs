using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spline;

namespace TowerDefence
{
    class RenderTargetHandler
    {
        public RenderTarget2D renderTarget;
        GraphicsDevice gd;
        public RenderTargetHandler(GraphicsDevice gd, int width, int height)
        {
            this.gd = gd;
            renderTarget = new RenderTarget2D(gd, width, height); 
        }
        public void updateRenderTarget(SpriteBatch sb, Texture2D tex, Vector2 pos)
        {
            gd.SetRenderTarget(renderTarget);
            gd.Clear(Color.Transparent);

            sb.Begin();
            sb.Draw(tex, pos, Color.White);
            sb.End();

            gd.SetRenderTarget(null);

        }
    }
}
