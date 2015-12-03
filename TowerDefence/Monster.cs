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
    class Monster
    {
        Texture2D tex;
        public Vector2 pos;
        public Rectangle hitBox;
        
        public Monster(Texture2D tex, Vector2 startPos)
        {
            this.pos = startPos;
            this.tex = tex;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void update(Vector2 dest)            //Skicka med coordinates från splineklassen
        {
            pos = dest;
            this.hitBox = new Rectangle((int)pos.X, (int)pos.Y, tex.Width, tex.Height);
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(tex, pos, Color.White);
        }
    }
}
